using System;
using System.Collections.Generic;
using System.Text;

namespace InvokeMethod
{
    class Program  // deklarerar klassen
    {
        static void Main(string[] args) // deklarerar metoden
        {
            Console.WriteLine("Månadens namn kommer att skrivas ut...");
            MyClass mc = new MyClass();  // skapar ett MyClass-objekt
            mc.PrintFullNameOfDayOfMonth(); // objektet anopar metoden
            Console.WriteLine("...och nu har det skrivits ut.");
        }
    }

    class MyClass // deklarerar klassen
    {
        public void PrintFullNameOfDayOfMonth() // deklarerar metoden
        {
            DateTime dt = DateTime.Today; // hämtar aktuellt datum
            Console.WriteLine("{0:MMMM}", dt); // skriver ut månadens namn
        }
    }

}


/*
        static void Main(string[] args) // deklarerar metoden
        {
            Console.WriteLine("Veckodagens namn kommer att skrivas ut...");
            PrintFullNameOfDayOfWeek(); // anropar metoden
            Console.WriteLine("...och nu har det skrivits ut.");
        }

        static void PrintFullNameOfDayOfWeek() // deklarerar metoden
        {
            DateTime dt = DateTime.Today; // hämtar aktuellt datum
            Console.WriteLine("{0:dddd}", dt); // skriver ut veckodagens namn
        }
*/