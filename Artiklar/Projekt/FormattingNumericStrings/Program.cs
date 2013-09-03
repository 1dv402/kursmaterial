using System;
using System.Collections.Generic;
using System.Text;

namespace FormattingNumericStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Värdet: {0}.", 483);   // Skriver ut talet.
            //Console.WriteLine("Värdet: {0:c}.", 483); // Formatera det som valuta.

            //int myValue = 483;
            //Console.WriteLine("Värdet: |{0, 10}|.", myValue);  // Högerjusterat.
            //Console.WriteLine("Värdet: |{0, -10}|.", myValue); // Vänsterjusterat.

            double myValue = 123.456789;
            Console.WriteLine("{0, -10} -> Standard.", myValue);
            Console.WriteLine("{0, -10:G} -> Generell, samma som standard.", myValue);
            Console.WriteLine("{0, -10:F4} -> Fyra decimaler.", myValue);
            Console.WriteLine("{0, -10:C} -> Valuta.", myValue);
            Console.WriteLine("{0, -10:E3} -> Exponentform, 3 decimaler", myValue);
            Console.WriteLine("{0, -10:X} -> Hexadecimalt heltal.", 123465789);
        }
    }
}
