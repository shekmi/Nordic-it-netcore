﻿using System.Collections.Generic;
using WebApplication_lesson22_API.Models;

namespace WebApplication_lesson22_API
{
    public class CitiesDataStore
    {
        private static CitiesDataStore _store;
        public List<City> Cities { get; }

        private CitiesDataStore()
        {
            Cities = new List<City>
            {
                new City (1, "Moscow" ),
                new City (2, "Saint-Petersburg" ),
                new City (3, "New-York" )
            };
        }

        public static CitiesDataStore GetInstance()
        {
            if (_store == null)
                _store = new CitiesDataStore();
            return _store;
        }
    }
}
