using System;
using System.Collections.Generic;
using System.Text;

namespace Step1Exercise07
{
    class Program
    {
        static void Main(string[] args)
        {
            for (char ch = 'a'; ch <= 'z'; ++ch)
            {
                Console.Write("{0}{1} ", ch, (char)(ch - 32));
            }

            Console.WriteLine();

            for (char ch = 'z'; ch >= 'a'; --ch)
            {
                Console.Write("{0}{1} ", (char)(ch - 32), ch);
            }
        }
    }
}
