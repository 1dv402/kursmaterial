using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertFahrenheitToCelsius
{
    class Program
    {
        static void Main(string[] args)
        {
            // Definierar och initierar variabler.
            double celsius = 0.0;
            double fahrenheit = 0.0;

            // Hämta temperatur i Fahrenheit från användaren.
            Console.Write("Ange temperaturen i grader Fahrenheit: ");
            fahrenheit = double.Parse(Console.ReadLine());

            // Konvertera Fahrenheit till Celcius.
            celsius = (fahrenheit - 32) * 5 / 9;

            // Presenterar resultatet.
            Console.WriteLine("Temperaturen {0} °F motsvarar {1:f1} °C",
                    fahrenheit, celsius);
        }
    }
}
