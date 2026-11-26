using AeroRoute.Models;
using AeroRoute.Services;
using AeroRoute.Loaders;
using Xunit;

namespace AeroRoute.Tests
{
    public class TestAirportLookup
    {
        [Theory]
        [InlineData("EGPD", "Aberdeen International Airport")]
        [InlineData("egph", "Edinburgh Airport")]
        [InlineData(" egll ", "London Heathrow Airport")]

        public void TestAirportLookup_GetAirport(string input, string expected)
        {
            AirportLookup airportLookup = new AirportLookup();
            AirportCsvLoader loader = new AirportCsvLoader();
            string path = Path.Combine(
                AppContext.BaseDirectory,
                "Data",
                "airports_test.csv"
            );
            Airport airport = airportLookup.GetAirport(loader.LoadAirports(path), input);
            Assert.Equal(expected, airport.Name);
        }
        [Theory]
        [InlineData("ZZZZ")]
        [InlineData("EG1D")]
        [InlineData(null)]
        public void TestAirportLookup_GetAirportIncorrectData(string? input)
        {
            Assert.Throws<ArgumentException>(() =>
                Validators.ValidateGroundSpeed(input)
            );
        }
    }
}
