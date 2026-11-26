using AeroRoute.Models;
using System;
using System.IO;
using System.Linq;
namespace AeroRoute.Loaders
{
    public class AirportCsvLoader
    {
        public string[] LoadAirportCsv(string path)
        {
            string[] file = File.ReadAllLines(path);
            return file;
        }
        public Airport ParseAirport(string line)
        {
            string[] columns = line.Split(",");
            Airport airport = new Airport(
                Icao: columns[9],
                Name: columns[2],
                Latitude: double.Parse(columns[3]),
                Longitude: double.Parse(columns[4])
                );
            return airport;
        }
    }
}

