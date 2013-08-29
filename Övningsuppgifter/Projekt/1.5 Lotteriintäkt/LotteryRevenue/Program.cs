using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryRevenue
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;

            for (int i = 2; i <= 100; i += 2)
            {
                sum += i;
            }

            Console.WriteLine("Ringen med lotter ger intäkten {0:c0}.", sum);
        }
    }
}
