using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_lesson_22.Controllers
{
    [ApiController]
    [Route("cities")] //это слово будет в url
    public class CitiesController: ControllerBase
    {
        [HttpGet]  //отвечает на get запросы
        public JsonResult GetCities()
        {
            //var model = new[] { 1, 2, 3 }; //Модель!
            //return new JsonResult(model); //view этой модели

            var model = new List<object>
            {
                new { Id = 1, Name = "Moscow" },
                new { Id = 1, Name = "Saint-Petersburg" },
                new { Id = 1, Name = "New-York" }
            };
            return new JsonResult(model);
        }
    }
}
