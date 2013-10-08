using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatInheriteance
{
    class Person
    {
        public string FirstName { get; set; }
        protected string LastName { get; set; }
        protected string CivicRegistrationNumber { get; set; }

        public Person()
            :this("N")
        {
            //FirstName = "N";
            //LastName = "N";
            //CivicRegistrationNumber = "okänt!";
        }

        public Person(string firstName)
            : this(firstName, "N")
        {
            //FirstName = firstName;
            ////LastName = "N";
            ////CivicRegistrationNumber = "okänt!";
        }

        public Person(string firstName, string lastName)
            : this(firstName, lastName, "okänt!")
        {
            //FirstName = firstName;
            //LastName = lastName;
            ////CivicRegistrationNumber = "okänt!";
        }
        
        public Person(string firstName, string lastName, string crn)
        {
            FirstName = firstName;
            LastName = lastName;
            CivicRegistrationNumber = crn;
        }
    }
}
