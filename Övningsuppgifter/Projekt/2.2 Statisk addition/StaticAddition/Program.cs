using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticAddition
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Statisk addition";

            // Vilken statisk metod anropas?
            int sum = MyMath.Add(123, 456);
            Console.WriteLine("Summan är: {0}\n", sum);

            // Vilken statisk metod anropas?
            double anotherSum = MyMath.Add(9.87, 6.54);
            Console.WriteLine("Summan är: {0}\n", anotherSum);

            // Vilken statisk metod anropas?
            Console.WriteLine("Summan är: {0}\n", MyMath.Add(123, 6.54));
        }
    }
}
