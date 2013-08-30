using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCollectionOfCars
{
    // Väljer att bara implementera den generiska interfacet IComparable<T>
    // då den generiska typen List<T> ska använda klassen. 
    // OBS! Ramverket kan inte sortera objekt vars referenser placeras i en 
    // array. För detta krävs att interfacet IComparable implementeras.

    class Car : IComparable<Car>
    {
        // Fält
        private string _make;
        private string _petName;
        private string _color;

        // Konstruktorer
        public Car()
            : this(String.Empty, String.Empty, String.Empty)
        {
        }

        public Car(string make, string petName, string color)
        {
            _make = make;
            _petName = petName;
            _color = color;
        }

        // Egenskaper
        public string PetName
        {
            get { return _petName; }
            set { _petName = value; }
        }

        public string Make
        {
            get { return _make; }
            set { _make = value; }
        }

        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }

        // Överskuggade metoder

        public override string ToString()
        {
            return String.Format("{0}, {1}, {2}", _make, _petName, _color);
        }

        // Implementerade interface

        public int CompareTo(Car other)
        {
            if (other == null)
            {
                // Är det andra objektet null ska det sorteras
                // före det här objektet.
                return 1;
            }

            // Jämför det här objektet (det anropande objektet) med
            // det andra objektet.
            return this.ToString().CompareTo(other.ToString());
        }
    }
}
