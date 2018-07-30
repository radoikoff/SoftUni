using BusTicketsSystem.Models;
using BusTicketsSystem.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;


namespace BusTicketsSystem.Initializer
{
    public class TripInitializer
    {
        public static Trip[] GetTrips()
        {
            var trips = new Trip[]
            {
                new Trip()
                { DepartureTime = new DateTime(2018,08,01,08,00,00),
                  ArrivalTime = new DateTime(2018,08,01,09,20,00),
                  Status = TripStatus.Departed,
                  BusCompanyId = 1,
                  OriginBusStationId = 1,
                  DestinationBusStationId = 2
                },

                new Trip()
                { DepartureTime = new DateTime(2018,06,05,08,53,00),
                  ArrivalTime = new DateTime(2018,06,05,09,50,00),
                  Status = TripStatus.Arrived,
                  BusCompanyId = 1,
                  OriginBusStationId = 3,
                  DestinationBusStationId = 4
                },

                  new Trip()
                { DepartureTime = new DateTime(2018,01,01,00,00,00),
                  ArrivalTime = new DateTime(2018,01,01,09,00,00),
                  Status = TripStatus.Arrived,
                  BusCompanyId = 1,
                  OriginBusStationId = 5,
                  DestinationBusStationId = 6
                },

                  new Trip()
                { DepartureTime = new DateTime(2018,01,02,00,00,00),
                  ArrivalTime = new DateTime(2018,01,02,09,00,00),
                  Status = TripStatus.Cancelled,
                  BusCompanyId = 2,
                  OriginBusStationId = 6,
                  DestinationBusStationId = 5
                },


                  new Trip()
                { DepartureTime = new DateTime(2018,01,02,18,30,00),
                  ArrivalTime = new DateTime(2018,01,03,01,10,00),
                  Status = TripStatus.Cancelled,
                  BusCompanyId = 2,
                  OriginBusStationId = 1,
                  DestinationBusStationId = 6
                },


            };

            return trips;
        }
    }
}
