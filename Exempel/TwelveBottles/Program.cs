using System;
using System.IO;

namespace TwelveBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (StreamReader reader = new StreamReader("12 flaskor whiskey.txt"))
                {
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }

            }
            catch (Exception)
            {
                Console.WriteLine("Fel inträffade vid läsning av textfil.");
            }
        }
    }
}
