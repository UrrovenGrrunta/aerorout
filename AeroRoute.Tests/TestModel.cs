using AeroRoute.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AeroRoute.Tests
{
    public class TestModel
    {
        [Fact]
        public void TestModels_TestModelCreates()
        {
            Airport airport = new Airport(
                Icao: "EGPH",
                Name: "Edinburgh Airport",
                Latitude: 55.950145,
                Longitude: -3.372288
                );

            Assert.Equal("EGPH", airport.Icao);
            Assert.Equal("Edinburgh Airport", airport.Name);
            Assert.Equal(55.950145, airport.Latitude);
            Assert.Equal(-3.372288, airport.Longitude);

        }

    }
}
