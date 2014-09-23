using System;
using System.Drawing;

namespace PersonalDescription2
{
    class Person
    {
        #region Fält

        // Fält.
        // Fält ska ALLTID vara privata. (En 
        // tumregel som det är sällsynt att 
        // man inte följer.)
        private string _name;
        private int _shoeSize;

        #endregion

        #region Autoimplementerade egenskaper

        // Någon validering av ögonfärgen behöver inte göras,
        // varför en autoimplementerad egenskap lämpligen
        // används istället för ett publikt fält.
        public Color EyeColor { get; set; }

        #endregion

        #region Egenskaper

        public string Name
        {
            get { return this._name; }
            set
            {
                // Namnet måste sättas till en sträng med
                // tecken, dock inte enbart vita tecken,
                // d.v.s. mellanslag, tabbar, etc.. Klarar inte
                // värdet valideringen kastas ett undantag.
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name is required.", "Name");
                }

                // Trimmar bort inledande och avslutande
                // vita tecken.
                this._name = value.Trim();
            }
        }

        public int ShoeSize
        {
            get { return _shoeSize; }
            set
            {
                // Skostorleken måste sättas till ett värde mellan
                // 5 och 52. Klarar inte värdet valideringen kastas 
                // ett undantag.
                if (value < 5 || value > 52)
                {
                    throw new ArgumentOutOfRangeException("ShoeSize", "The shoe size cannot be less than 5 or grater than 52.");
                }
                this._shoeSize = value;
            }
        }

        #endregion

        #region Konstruktorer

        // "Standardkonstruktor" som tillåter att ett objekt kan instansieras
        // utan att skicka med några argument.
        public Person()
        {
            // Tom! Det nya objektets fält tilldelas standardvärdena
            //      för typerna de är av.
            //      string -> null
            //      byte   -> 0
            //      Color  -> 0
        }

        // Konstruktor som kräver argument för namn, skostorlek och ögonfärg.
        // Parametrarnas värden kopieras till respektive fält.
        public Person(string name, int shoeSize, Color eyeColor)
        {
            // this refererar till objekt som just skapats och som
            // här initieras av konstruktorn.
            Name = name;
            ShoeSize = shoeSize;
            EyeColor = eyeColor;
        }

        #endregion

        #region Metoder

        // Instansmetod.
        public void ViewData()
        {
            string color = null;

            // Översätt fältet _eyeColor till en sträng.
            if (EyeColor == Color.Blue)
            {
                color = "blåa";
            }
            else if (EyeColor == Color.Brown)
            {
                color = "bruna";
            }
            else if (EyeColor == Color.Green)
            {
                color = "gröna";
            }
            else
            {
                color = "okänd färg på sina";
            }

            // Skriv ut beskrivning av personen.
            Console.WriteLine("{0} har {1} ögon och {2} i skostorlek.\n", 
                Name, color, ShoeSize);
        }

        #endregion
    }
}
