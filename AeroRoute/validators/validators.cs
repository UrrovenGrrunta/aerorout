using System;
using System.Xml;

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
                throw new ArgumentException($"ICAO code must be letters from A to Z. {symbol} is not a valid letter.");
            }
        }
        if (icao.Length != 4)
        {
            throw new ArgumentException("ICAO code must be 4 characters long");
        }

        return icao;
    }
    public static double ValidateGroundSpeed(string? speed)
    {
        double groundSpeed;

        if (speed == null) 
        {
            throw new ArgumentException("Speed cannot be null");
        }
        try
        {
            groundSpeed = double.Parse(speed);
        }
        catch (FormatException ex)
        {
            throw new ArgumentException($"Cannot convert {speed} to double.\nError: {ex}");
        }
        if (groundSpeed <= 0f || !double.IsFinite(groundSpeed))
        {
            throw new ArgumentException("Ground speed must be positive finite number");
        }
        return groundSpeed;
    }
}