using System;
using System.Drawing;

namespace PersonalDescription2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Raderna nedan är bortkommenterade eftersom fälten är privata,
            // eller inte längre finns, varför de inte kan kommas åt.
            //Person Person = new Person(); // skapar nytt Person-objekt.
            //Person._name = "Adam";
            //Person._shoeSize = 42;
            //Person._eyeColor = Color.Blue;
            //Person.ViewData(); // Objektet som Person refererar till exekverar metoden i klassen!

            // Här används publika egenskaper istället för fälten.
            Person person2 = new Person(); // instansierar nytt objekt av klassen Person.
            person2.Name = "Bertil";
            person2.ShoeSize = 42;
            person2.EyeColor = Color.Brown;
            person2.ViewData(); // Objektet som person2 refererar till exekverar metoden i klassen!

            // Då en egenskap tilldelas ett värde valideras värdet innan det sparas i det privata fält
            // som egenskapen är knuten till. Misslyckas valideringen kastas ett undantag.
            try
            {
                Person person3 = new Person();
                person3.Name = "Ceasar";
                person3.ShoeSize = 54;  // Orsakar att ett undantag kastas!
                person3.EyeColor = Color.Green;
                person3.ViewData(); // Objektet som person3 refererar till exekverar metoden i klassen!
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nERROR!\n{0}\n", ex.Message);
            }

            try
            {
                Person person4 = new Person("    ", 0, Color.Gray); // Försöker instansiera och initera ett nytt objekt 
                // av typen Person. Orsakar att ett undantag kastas! 
                person4.ViewData();
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nERROR!\n{0}\n", ex.Message);
            }

            try
            {
                // Använder standardkonstuktorn.
                Person person5 = new Person();

                // Tilldelar objektet som person5 refererar till värden
                // genom att använda de publika egenskaperna.
                person5.Name = "Erik";
                person5.ShoeSize = 43;
                person5.EyeColor = Color.Blue;
                person5.ViewData();

                // Använder konstuktorn som har tre parametrar för att initiera
                // objektet person6 refererar till.
                Person Person6 = new Person("Filip", 41, Color.Brown);
                Person6.ViewData();

                // Använder standsardkonstuktorn och egenskaper för att
                // initera objektet person7 refererar till.
                Person person7 = new Person
                {
                    Name = "Gustav",
                    ShoeSize = 37,
                    EyeColor = Color.Green
                };
                person7.ViewData();
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nERROR!\n{0}\n", ex.Message);
            }
        }
    }
}
