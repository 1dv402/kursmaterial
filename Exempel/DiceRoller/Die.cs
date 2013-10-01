using System;

namespace DiceRoller
{
    class Die
    {
        // Konstanter
        public const int MinFaceValue = 1;
        public const int MaxFaceValue = 6;

        // Speciell "konstant" då Random är en referenstyp varför 
        // objektet instansieras i den statiska konstruktorn.
        // I och med att _randomSeed är statisk är objektet som den
        // refererar till gemensamt för alla objekt instansierade från 
        // klassen Die.
        private static readonly Random _randomSeed;

        // Fält
        private int _faceValue;
        private readonly Random _random;

        // Statisk kontruktor som bara körs en gång!
        static Die()
        {
            // Skapar det Random-objekt som används för att
            // slumpa fram nya slumptalsfrön.
            _randomSeed = new Random();
        }

        // Standardkonstruktor.
        public Die()
        {
            // Slumpar ett nytt slumptalsfrö för
            // det här objektet.
            _random = new Random(_randomSeed.Next());

            // Slumpar tärningens värde redan då
            // objkektet skapas.
            Roll();
        }

        // Egenskap (set är publik, get är privat). Innan _faceValue
        // tilldelas ett nytt värde kontrolleras att den automatiska
        // variabeln value har ett värde mellan konstanternas värden.
        public int FaceValue
        {
            get { return _faceValue; }
            private set 
            {
                if (value < MinFaceValue ||
                    value > MaxFaceValue)
                {
                    throw new ArgumentOutOfRangeException();
                }
                _faceValue = value; 
            }
        }

        // Metod som slumpar ett heltal mellan konstanternas värden
        // och lagrar reultatet i fältet _faceValue via egenskapen 
        // FaceValue.
        public int Roll()
        {
            FaceValue = _random.Next(MinFaceValue, MaxFaceValue + 1);
            return FaceValue;
        }

        // Överskugga metod som "översätter" objektets status till
        // en sträng.
        public override string ToString()
        {
            return FaceValue.ToString();
        }
    }
}
