using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_lesson22_API.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public City()
        {

        }
        public City(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
