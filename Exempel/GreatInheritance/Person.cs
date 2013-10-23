
namespace GreatInheriteance
{
    class Person
    {
        public string FirstName { get; set; }
        protected string LastName { get; set; }
        protected string CivicRegistrationNumber { get; set; }

        // Med hjälp av this pekas i samma klass ut den konstruktor som också
        // ska anropas. Detta gör att kod som sköter initieringen kan koncentreras
        // till en enda konstruktor; lämpligen den konstruktor som har flest parametrar.
        public Person()
            : this("N") // Anropar den konstruktor som tar ett förnamn som argument.
        {
            //FirstName = "N";
            //LastName = "N";
            //CivicRegistrationNumber = "okänt!";
        }

        public Person(string firstName)
            : this(firstName, "N") // Anropar den konstruktor som tar ett förnamn och efternamn som argument.
        {
            //FirstName = firstName;
            //LastName = "N";
            //CivicRegistrationNumber = "okänt!";
        }

        public Person(string firstName, string lastName)
            : this(firstName, lastName, "okänt!") // Anropar den konstruktor som tar ett förnamn, efternamn och personnummer som argument.
        {
            //FirstName = firstName;
            //LastName = lastName;
            //CivicRegistrationNumber = "okänt!";
        }
        
        public Person(string firstName, string lastName, string crn)
        {
            FirstName = firstName;
            LastName = lastName;
            CivicRegistrationNumber = crn;
        }
    }
}
