using System;
using System.Drawing;

namespace PersonalDescription
{
    class Person
    {
        // Fält.
        // OBS! Fält ska "aldrig" vara publika. I detta 
        //      inledande exempel tillåter vi oss det dock.
        public string _name;
        public int _shoeSize;
        public Color _eyeColor;
 
        // "Standardkonstruktor" som tillåter att ett objekt kan instansieras
        // utan att skicka med några argument.
        public Person()
        {
            // Tom! Det nya objektets fält tilldelas standardvärdena
            //      för typerna de är av.
            //      string -> null
            //      byte   -> 0
            //      Color  -> 0
        }
 
        // Konstruktor som kräver argument för namn, skostorlek och ögonfärg.
        // Parametrarnas värden kopieras till respektive fält.
        public Person(string name, int shoeSize, Color eyeColor)
        {
            // Det nya objektets fält tilldelas parametrarnas värden.
            _name = name;
            _shoeSize = shoeSize;
            _eyeColor = eyeColor;
        }
 
        // Instansmetod.
        public void ViewData()
        {
            string color = null;
 
            // Översätt fältet _eyeColor till en sträng.
            if (_eyeColor == Color.Blue)
            {
                color = "blåa";
            }
            else if (_eyeColor == Color.Brown)
            {
                color = "bruna";
            }
            else if (_eyeColor == Color.Green)
            {
                color = "gröna";
            }
            else
            {
                color = "okänd färg på sina";
            }
 
            // Skriv ut beskrivning av personen.
            Console.WriteLine("{0} har {1} ögon och {2} i skostorlek.\n", 
                _name, color, _shoeSize);
        }
    }
}
