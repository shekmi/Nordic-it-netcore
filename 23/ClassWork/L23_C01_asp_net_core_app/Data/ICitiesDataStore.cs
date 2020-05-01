using System;
using System.Collections.Generic;

namespace L23_C01_asp_net_core_app.Data
{
    public interface ICitiesDataStore
    {
        List<CityDto> Cities { get; }
    }
}
