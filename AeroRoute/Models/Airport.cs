namespace AeroRoute.Models
{
    public record Airport(
        string Icao,
        string Name,
        double Latitude,
        double Longitude
        );
}
