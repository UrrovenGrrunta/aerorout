using System;

namespace AeroRoute;

public class Validators
{
    // Validates and normalizes an ICAO code.
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
                throw new ArgumentException($"ICAO code must contain only letters A-Z. '{symbol}' is invalid.");
            }
        }
        if (icao.Length != 4)
        {
            throw new ArgumentException("ICAO code must be exactly 4 characters long");
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
            throw new ArgumentException($"Cannot convert '{speed}' to a number.\nError: {ex}");
        }
        if (groundSpeed <= 0f || !double.IsFinite(groundSpeed))
        {
            throw new ArgumentException("Ground speed must be a positive, finite number");
        }
        return groundSpeed;
    }
}