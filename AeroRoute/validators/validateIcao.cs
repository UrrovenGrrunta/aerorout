using System;

namespace AeroRoute;

public class Validators
{
    //This method is responsible for converting the ICAO code into the correct format
    public static string ValidateIcao(string? icao)
    {
        if (string.IsNullOrEmpty(icao))
        {
            throw new ArgumentException("ICAO code cannot be null or empty");
        }
        icao = icao.Trim().ToUpper(); 

        foreach (char symbol in icao) 
        {
            if (symbol < 'A' || symbol > 'Z')
            {
                throw new ArgumentException($"ICAO code must be letters form A to Z. {symbol} is not a cletter.");
            }
        }
        if (icao.Length != 4)
        {
            throw new ArgumentException("ICAO code must be 4 characters long");
        }
        if (icao is "")
        {

        }


        return icao;
    }
}