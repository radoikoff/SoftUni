using BusTicketsSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusTicketsSystem.Initializer
{
    public class BusStationsInitializer
    {
        public static BusStation[] GetBusStations()
        {
            var stations = new BusStation[]
            {
                new BusStation() { Name = "Pliska", TownId = 1 },
                new BusStation() { Name = "Liulin", TownId = 1 },
                new BusStation() { Name = "Koleloto", TownId = 1 },
                new BusStation() { Name = "Kensington", TownId = 4 },
                new BusStation() { Name = "4-ti kilometyr", TownId = 1 },
                new BusStation() { Name = "Sqare Garten", TownId = 4 },
                new BusStation() { Name = "Le Shateaoux", TownId = 5 },
                new BusStation() { Name = "Monmarthr", TownId = 5 },
                new BusStation() { Name = "Das Newe", TownId = 6 },
                new BusStation() { Name = "Under Den Linden", TownId = 6 }
            };

            return stations;
        }
    }
}
