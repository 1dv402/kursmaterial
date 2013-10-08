using System;

namespace GreatInheriteance
{
    class Student : Person, IComparable
    {
        public char Grade { get; set; }

        public Student()
        {
            // Tom!
        }

        public Student(string firstName, string lastName, string crn, char grade)
            :base(firstName, lastName, crn)
        {
            //FirstName = firstName;
            //LastName = lastName;
            //CivicRegistrationNumber = crn;
            Grade = grade;
        }

        public override string ToString()
        {
            return String.Join(", ", LastName, FirstName, CivicRegistrationNumber, Grade);
        }

        #region IComparable Members

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            if (obj == this)
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
