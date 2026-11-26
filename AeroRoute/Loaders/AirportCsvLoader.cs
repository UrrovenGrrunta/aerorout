using AeroRoute.Models;
using System;
using System.IO;
using System.Linq;
using Microsoft.VisualBasic.FileIO;

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
            using var reader = new StringReader(line);
            using var parser = new TextFieldParser(reader);

            parser.SetDelimiters(",");
            parser.HasFieldsEnclosedInQuotes = true;

            string[] columns = parser.ReadFields()
                ?? throw new FormatException("Invalid CSV row.");

            Airport airport = new Airport(
                Icao: columns[9],
                Name: columns[2],
                Latitude: double.Parse(columns[3]),
                Longitude: double.Parse(columns[4])
            );

            return airport;
        }
        public Dictionary<string, Airport> LoadAirports(string path)
        {
            var file = LoadAirportCsv(path);
            Dictionary<string, Airport> airportDictionary = new();
            foreach (var line in file.Skip(1)) 
            {
                Airport airport = ParseAirport(line);
                airportDictionary[airport.Icao] = airport;
            }

            return airportDictionary;
        }
    }
}

