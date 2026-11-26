using Xunit;
using AeroRoute;
using AeroRoute.Models;

namespace AeroRoute.Tests
{
    public class TestCsvLoader
    {
        [Fact]
        public void TestCsvLoader_LoadsCsv()
        {
            string path = Path.Combine(
                AppContext.BaseDirectory,
                "Data",
                "airports_test.csv"
            );
            var loader = new Loaders.AirportCsvLoader();
            string[] airports = loader.LoadAirportCsv(path);
            Assert.Equal(5, airports.Length);
        }
        [Fact]
        public void TestCsvLoader_ValuesAreCorrect()
        {
            string path = Path.Combine(
            AppContext.BaseDirectory,
            "Data",
            "airports_test.csv"
            );
            var loader = new Loaders.AirportCsvLoader();
            string[] airports = loader.LoadAirportCsv(path);
            Assert.Equal("id,ident,name,latitude_deg,longitude_deg,elevation_ft,iso_country,iso_region,municipality,icao_code,iata_code", airports[0]);
            Assert.Equal("2459,EGPD,Aberdeen International Airport,57.2019,-2.19778,215,GB,GB-SCT,Aberdeen,EGPD,ABZ", airports[^1]);
        }
        [Fact]
        public void TestCsvLoader_ParserReturnsAirport()
        {
            string input = "2459,EGPD,Aberdeen International Airport,57.2019,-2.19778,215,GB,GB-SCT,Aberdeen,EGPD,ABZ";
            var airport = new Loaders.AirportCsvLoader();
            var parsedAirport = airport.ParseAirport(input);
            Assert.Equal("EGPD", parsedAirport.Icao);
            Assert.Equal("Aberdeen International Airport", parsedAirport.Name);
            Assert.Equal(57.2019, parsedAirport.Latitude);
            Assert.Equal(-2.19778, parsedAirport.Longitude);
        }
    }
}
