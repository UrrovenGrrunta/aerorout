using System;

namespace AeroRoute;

public class Processors
{
    public string? ReadICAO()
    {

        Console.Write("Enter ICAO code: ");
        string? icao = Console.ReadLine();

        return icao;
    }
    public string? ReadGroundSpeed()
    {
        Console.Write("Enter ground speed (kt): ");
        string? groundSpeed = Console.ReadLine();
        return groundSpeed;
    }
}