using System;
using System.Collections.Generic;
using System.Text;

namespace BusTicketsSystem.Services.Contracts
{
    public interface IStationService
    {
        bool Exists(int stationId);
        TModel ById<TModel>(int stationId);
    }
}
