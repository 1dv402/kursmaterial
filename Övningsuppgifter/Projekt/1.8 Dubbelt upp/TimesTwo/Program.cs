using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimesTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Dubbelt upp";

            // Skapar och initierar en array med fem heltal.
            int[] values = { 10, 23, 5, 1, 15 };

            // Loopar igenom arrayen...
            for (int i = 0; i < values.Length; ++i)
            {
                // ...och skriver ut varje elements värde.
                Console.Write("{0} ", values[i]);
            }
            Console.WriteLine();

            // Hämtar ut det andra värdet, dubblerar det
            // och tilldelar det andra elementet det nya värdet.
            int temp = values[1];
            temp = temp * 2;
            values[1] = temp;

            // Samma resultat som ovan men enklare(?).
            // OBS! Det sista elementet har index 4 då
            //      arrayen innhåller fem element.
            values[4] *= 2;

            // Loopar igenom arrayen...
            for (int i = 0; i < values.Length; ++i)
            {
                // ...och skriver ut varje elements värde.
                Console.Write("{0} ", values[i]);
            }
            Console.WriteLine();
        }
    }
}
