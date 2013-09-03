using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchStatement
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; ++i)
            {
                switch (i)
                {
                    case 1: // om i är lika med 1
                        Console.WriteLine("i = {0} -> i case 1", i);
                        break;

                    case 4: // om i är lika med 4
                        Console.WriteLine("i = {0} -> i case 4", i);
                        break;

                    default: // // om i inte är lika med 1 eller 4
                        Console.WriteLine("i = {0} -> i default", i);
                        break;
                }
            }
        }
    }
}
