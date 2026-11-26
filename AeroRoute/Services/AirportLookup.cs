using AeroRoute.Models;
using System;


namespace AeroRoute.Services
{
    public class AirportLookup
    {
        public Airport GetAirport(Dictionary<string, Airport> airports, string? icao)
        {
            icao = Validators.ValidateIcao(icao);
            if (!airports.TryGetValue(icao, out Airport? airport))
            {
                throw new ArgumentException($"No airport with ICAO {icao} found");
            }

            return airport;
        }
    }
}
