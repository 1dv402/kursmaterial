using System;

namespace GreatInheriteance
{
    class Student : Person, IComparable
    {
        public char Grade { get; set; }

        // Innan denna konstruktors kropp körs så
        // körs "default"-konstruktorn i basklassen Person.
        public Student()
        {
            Grade = '-';
        }

        // Innan denna konstruktors kropp körs så
        // körs den konstruktor i basklassen Person som har tre parametrar.
        public Student(string firstName, string lastName, string crn, char grade)
            :base(firstName, lastName, crn)
        {
            //FirstName = firstName;
            //LastName = lastName;
            //CivicRegistrationNumber = crn;
            Grade = grade;
        }

        // Denna metod "kör över", överskuggar (overrides), metoden ToString
        // som finns deklarerad i basklassen; Person ärver metoden från Object.
        public override string ToString()
        {
            return String.Join(", ", LastName, FirstName, CivicRegistrationNumber, Grade);
        }

        #region IComparable Members

        // Denna metod används av Array.Sort för att kunna sortera referenser, i en array,
        // till Student-objekt. Sorteringen sker på den sträng som ToString returnerar.
        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            if (Object.ReferenceEquals(this, obj))
            {
                return 0;
            }

            Student other = obj as Student;
            if (other == null)
            {
                throw new ArgumentException("Object is not a Student.");
            }

            return ToString().CompareTo(other.ToString());
        }

        #endregion
    }
}
