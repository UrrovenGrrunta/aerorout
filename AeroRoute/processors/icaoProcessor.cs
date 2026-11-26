using System;

namespace AeroRoute;

public class Processors
{
    public string ReadICAO()
    {

        Console.Write("Enter ICAO code: ");
        string icao = Console.ReadLine();

        return icao;
    }
}