using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtoZandViceVersa
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Från a till z och tvärtom";

            for (char ch = 'A'; ch <= 'Z'; ch++)
            {
                Console.Write("{0}{1} ", (char)(ch + 32), ch);
            }

            Console.WriteLine();

            for (char ch = 'Z'; ch >= 'A'; ch--)
            {
                Console.Write("{0}{1} ", (char)(ch + 32), ch);
            }

            Console.WriteLine();
        }
    }
}
