using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsOnIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            Statistics statics1 = new Statistics();
            Statistics statics2 = new Statistics();

            Console.WriteLine("Ange tio heltal till den första serien: ");
            ReadInts(statics1);
            Console.WriteLine(statics1);

            Console.WriteLine("Ange tio heltal till den andra serien: ");
            ReadInts(statics2);
            Console.WriteLine(statics2);

            Console.WriteLine("Den {0} serien har högst medelvärde.",
                statics1.Average > statics2.Average ? "första" : "andra");
        }

        private static void ReadInts(Statistics statics)
        {
            int value;
            for (int i = 0; i < 10; ++i)
            {
                while (!int.TryParse(Console.ReadLine(), out value))
                {
                    Console.WriteLine("Du måste ange ett heltal!");
                }
                statics.Add(value);
            }
        }
    }
}
