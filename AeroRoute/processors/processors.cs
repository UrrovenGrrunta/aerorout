using System;
using System.Runtime.InteropServices;

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
        Console.Write("Eneter grpund speed (kt): ");
        string? groundSpeed = Console.ReadLine();
        return groundSpeed;
    }
}