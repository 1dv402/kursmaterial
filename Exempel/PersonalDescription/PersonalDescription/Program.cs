using System;
using System.Drawing;

namespace PersonalDescription
{
    class Program
    {
        static void Main(string[] args)
        {
            // Lokala variabler som inte på något sätt relaterar till varandra 
            // trots att datat borde "hänga ihop" i ett paket bestående av 
            // namn, skostorlek och ögonfärg.
            string name = "Adam";
            string name2 = "Bertil";
            string name3 = "Ceasar";
 
            int shoeSize = 42;
            int shoeSizeA = 42;
            int shoeSize3 = 44;
 
            Color eyeColor = Color.Blue;
            Color eyeColorX = Color.Brown;
            Color eyeColorY = Color.Green;
 
            ViewData(name, shoeSize, eyeColor);
            ViewData(name2, shoeSizeA, eyeColorX);
            ViewData(name3, shoeSize3, eyeColorY);
 
            // Lätt att göra fel!
            ViewData(name, shoeSize3, eyeColorX);
 
            // Skapa nytt Person-objekt genom att använda standardkonstruktorn 
            // (konstruktorn utan parameterlista).
            Person person = new Person();
            person._name = "Adam";
            person._shoeSize = 42;
            person._eyeColor = Color.Blue;
 
            // Instansiera ytterligare objekt av klassen Person.
            Person person2 = new Person(); 
            person2._name = "Bertil";
            person2._shoeSize = 42;
            person2._eyeColor = Color.Brown;
 
            Person person3 = new Person();
            person3._name = "Ceasar";
            person3._shoeSize = 44;
            person3._eyeColor = Color.Green;
 
            // Datat hänger ihop! Fel undviks.
            ViewData(person);
            ViewData(person2);
            ViewData(person3);
 
            // Låt objekten exekvera metod i klassen.
            person.ViewData();
            person2.ViewData();
            person3.ViewData();
 
            // Instansiera och initiera nytt objekt av typen Person genom att 
            // använda den överlagrade konstruktorn som tar tre argument.
            Person person4 = new Person("David", 45, Color.Gray);
            person4.ViewData();
        }
 
        // --------------------------------------------------------------------
        // Metoden ViewData finns i två versioner. Namnkonflikt blir det inte 
        // eftersom metodernas signaturer är olika, d.v.s. parameterlistorna
        // skiljer sig åt mellan metoderna.
        // --------------------------------------------------------------------
        
        // Metod med tre parametrar.
        private static void ViewData(string name, int shoeSize, Color eyeColor)
        {
            string color = null;
 
            // Översätt parametern eyeColor till en sträng.
            if (eyeColor == Color.Blue)
            {
                color = "blåa";
            }
            else if (eyeColor == Color.Brown)
            {
                color = "bruna";
            }
            else if (eyeColor == Color.Green)
            {
                color = "gröna";
            }
            else
            {
                color = "okänd färg på sina";
            }
 
            // Skriv ut beskrivning av personen.
            Console.WriteLine("{0} har {1} ögon och {2} i skostorlek.\n", 
                name, color, shoeSize);
        }
 
        // Metod med en parameter.
        private static void ViewData(Person person)
        {
            string color;
 
            // Översätt medlemmen _eyeColor till en sträng.
            if (person._eyeColor == Color.Blue)
            {
                color = "blåa";
            }
            else if (person._eyeColor == Color.Brown)
            {
                color = "bruna";
            }
            else if (person._eyeColor == Color.Green)
            {
                color = "gröna";
            }
            else
            {
                color = "har okänd färg på sina";
            }
 
            // Skriv ut beskrivning av personen.
            Console.WriteLine("{0} har {1} ögon och {2} i skostorlek.\n", 
                person._name, color, person._shoeSize);
        }
    }
}
