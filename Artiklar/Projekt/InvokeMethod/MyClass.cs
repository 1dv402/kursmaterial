using System;
using System.Collections.Generic;
using System.Text;

namespace InvokeMethod
{
    class MyClass
    {
        public void PrintFullNameOfDayOfMonth() // deklarerar metoden
        {
            DateTime dt = DateTime.Today; // h�mtar aktuellt datum
            Console.WriteLine("{0:MMMM}", dt); // skriver ut m�nadens namn
        }
    }
}
