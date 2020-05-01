using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication_lesson22_API.Models;

namespace WebApplication_lesson22_API.Controllers
{
    [ApiController]
    [Route("cities")]
    public class CitiesController : ControllerBase
    {
        private CitiesDataStore _store;
        public CitiesController()
        {
            _store = CitiesDataStore.GetInstance();
        }

        //[HttpGet("")] //скобках пишется дополнительный путь, чтобы попасть в GET
        //localhost:xxxxx/cities
        [HttpGet]
        public IActionResult GetCities()
        {
            //var model = new[] { 1, 2, 3 }; //Модель!
            //return new JsonResult(model); //view этой модели
            if (_store.Cities == null)
                return NotFound();

            return Ok(_store.Cities);
        }

        [HttpGet("{id}", Name = "GetCityById")]
        public IActionResult GetCity(int id)
        {
            var city = _store.Cities.FirstOrDefault(x => x.Id == id); //метод Linq, вернет объект из списка, если он найден по некоторому условию
            if (city != null)
            {
                return Ok(city); //статус 200
            }

            return NotFound("404 Not Found");
        }

        [HttpPost]
        public IActionResult AddCity([FromBody] City city)
        {
            if (_store.Cities.FirstOrDefault(
                x => x.Id == city.Id
                || x.Name == city.Name) != null)
            {
                return Conflict();
            }
            _store.Cities.Add(city);
            return CreatedAtRoute("GetCityById", new { id = city.Id }, city);
        }

        [HttpPut]
        public IActionResult UpdateCity([FromBody] City city)
        {
            var existingCity = _store.Cities.FirstOrDefault(x => x.Id == city.Id);

            if(existingCity == null)
            {
                return NotFound("404 Not Found");
            }
            existingCity.Name = city.Name;

            //int number = _store.Cities.FindIndex(x => x.Id == city.Id);
            //if (number > 0)
            //{
            //    _store.Cities[number].Name = city.Name;
            //    return Accepted("City update");
            //}
            //{
            //    return NotFound("404 Not Found");
            //}
            return Ok(city);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCity(int id)
        {
            var city = _store.Cities.FirstOrDefault(x => x.Id == id);
            if(city == null)
            {
                return NotFound("404 Not Found");
            }
            bool ok = _store.Cities.Remove(city);

            if(!ok)
            {
                throw new Exception("Cannot remove the city: unexpected error occured.");
            }
            
                return NoContent(); //статус 204
            
        }

    }
}
