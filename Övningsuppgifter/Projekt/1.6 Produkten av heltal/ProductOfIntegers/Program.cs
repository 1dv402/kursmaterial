using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductOfIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Produkten av heltal";

            long product = 1;

            for (int i = 1; i <= 20; i++)
            {
                product *= i;
            }

            Console.WriteLine("Produkten av alla heltal mellan 1 och 20 är {0}.", product);
        }
    }
}
