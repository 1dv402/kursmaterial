using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCollectionOfCars
{
    class Program
    {
        static void Main(string[] args)
        {
            // Skapar en samling (lista) som kan innehålla 
            // referenser till Car-objekt.
            List<Car> listCars = new List<Car>();

            // Fyller listan med några bilar.
            listCars.Add(new Car("Ford", "Bettan", "Silver"));
            listCars.Add(new Car("Toyota", "Plutten", "Ljusblå"));
            listCars.Add(null); // Tillåtet! Och det fungerar faktiskt.
            listCars.Add(new Car("Nissan", "Bucklan", "Blå"));
            listCars.Add(new Car("BMW", "Blixten", "Mörkblå"));

            // Presenterar bilarna i den ordning de lades in.
            Console.WriteLine("Osorterade\n==========");
            DisplayCars(listCars);

            // Sorterar listan med bilar. Ramverket kan sortera 
            // Car-objekten eftersom klassen Car implementerar 
            // interfacet IComparable<Car>. Metoden CompareTo i klassen 
            // Car anropas av ramverket för att bestämma om ett Car-objekt 
            // ska sorteras för eller efter ett annat Car-objekt.
            listCars.Sort();

            // Presenterar bilarna i den ordning de har efter att de sorterats.
            Console.WriteLine("\nSorterade på bilmärke\n=====================");
            DisplayCars(listCars);
        }

        private static void DisplayCars(List<Car> cars)
        {
            // Loopar igenom listan med bilar och...
            foreach (Car car in cars)
            {
                // ...presenterar dem. Metoden ToString i klassen Car 
                // anropas implicit (automatiskt).
                if (car != null)
                {
                    Console.WriteLine(car);
                }
                else
                {
                    Console.WriteLine("[null]");
                }
            }
        }
    }
}
