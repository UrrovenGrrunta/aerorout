using System;

namespace AeroRoute
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------- AeroRoute ----------");

            try
            {
                string icaoDep, icaoArr;
                double groundSpeed;
                Console.Write("Enter ICAO code for depatrure airport: ");
                icaoDep = ValidateICAOFormat(Console.ReadLine());
                Console.Write("Enter ICAO code for arrival airport: ");
                icaoArr = ValidateICAOFormat(Console.ReadLine());
                Console.Write("Enter ground speed (KT): ");
                groundSpeed = ValidateGroundSpeed(Convert.ToDouble(Console.ReadLine()));

                Console.WriteLine($"{icaoDep} DCT {icaoArr}");
                Console.WriteLine($"Ground speed: {groundSpeed} KT");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occured {ex.Message}");                
            }


        }

        static string ValidateICAOFormat (string? icao)
        {
            if (icao is null)
            {
                throw new ArgumentNullException(nameof(icao));
            }

            icao = icao.Trim().ToUpperInvariant();

            if (icao.Length != 4)
            {
                throw new ArgumentException("ICAO must be 4 characters long.");
            }

            foreach (char symbol in icao)
            {
                if (symbol < 'A' || symbol > 'Z')
                {
                    throw new ArgumentException(
                        $"Invalid character '{symbol}'. Only A-Z allowed."
                    );
                }
            }

            return icao;
        }
        static double ValidateGroundSpeed(double? groundSpeed) 
        {
            if (groundSpeed is null)
            {
                throw new ArgumentNullException(nameof(groundSpeed));
            }
            if (groundSpeed.Value <= 0)
            {
                throw new ArgumentException("Ground speed must be possitive.");
            }
            if (groundSpeed is double.NaN)
            {
                throw new ArgumentException("Ground speed must be a number");
            }
            if (groundSpeed == float.PositiveInfinity || groundSpeed == float.NegativeInfinity)
            {
                throw new ArgumentException("Ground speed cannot be positive or negative Infinity");
            }

            return groundSpeed.Value;

        }
            
    }
}