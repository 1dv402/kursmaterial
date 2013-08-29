using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayBackwards
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "En array baklänges";

            // Läser in antalet heltal som ska lagras i arrayen och...
            Console.Write("Ange antalet heltal du vill lagra i arrayen: ");
            int count = ReadInt();
            // ...skapar arrayen.
            int[] numbers = new int[count];

            // Uppmanar användaren att mata in ett antal heltal...
            Console.WriteLine("Ange {0} heltal:", numbers.Length);
            for (int i = 0; i < numbers.Length; ++i)
            {
                // ...och metoden ReadInt returnerar ett heltal som 
                // som lagras i det element som variabeln i "pekar ut". 
                numbers[i] = ReadInt();
            }

            // Arrayens innehåll presenteras från det sista värdet till 
            // det första - "baklänges".
            Console.WriteLine("\nTalen utskrivna baklänges:");
            for (int i = numbers.Length - 1; i >= 0; --i)
            {
                Console.Write("{0} ", numbers[i]);
            }
        }

        // Metoden läser in ett heltal och returnerar det.
        private static int ReadInt()
        {
            // Variablen behöver inte initieras till ett värde efterom 
            // TryParse tilldelar result ett värde om TryParse returnerar
            // true.
            int result;

            // Läser in en sträng och försöker tolka strängen till ett heltal
            // som lagras i result. Misslyckas TryParse med att tolka strängen
            // till ett heltal returnerar den false och programmet "fastnar" i
            // while-loopen. OBS! Måste ange out före variabeln result!!
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("\nDu måste ange ett heltal!\n");
            }

            return result;
        }
    }
}
