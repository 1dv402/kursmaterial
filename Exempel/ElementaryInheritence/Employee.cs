using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementaryInheritence
{
    // Klassen ärver automatiskt från Object
    // även om det uttrycklingen inte står så.
    class Employee
    {
        // Privata fält för namn och årslön.
        private string _name;
        private decimal _salary;

        // Publik autoimplementerad egenskap för
        // antällningsdagen.
        public DateTime HireDay { get; set; }

        // Publik egenskap som kapslar in fältet
        // _name och säkerställer att _name inte
        // tilldelas null eller en sträng med 
        // vita tecken.
        public string Name
        {
            get { return _name; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException();
                }
                _name = value;
            }
        }

        // Publik egenskap som kapslar in fältet
        // _salary och säkerställer att _salary inte
        // tilldelas ett värde mindre än 0.
        public decimal Salary
        {
            get { return _salary; }
            set
            {
                if (value < 0m)
                {
                    throw new ArgumentException();
                }
                _salary = value;
            }
        }

        // Konstruktor med tre parametrar vars värden används
        // till att initiera objektet via egenskaperna.
        public Employee(string name, decimal salary, DateTime hireDay)
        {
            Name = name;
            Salary = salary;
            HireDay = hireDay;
        }

        // Publik metod som ökar lönen med angiven
        // procentsats.
        public void RaiseSalary(decimal percent)
        {
            Salary *= 1 + percent / 100m;
        }

        // Överskuggar metoden ToString i basklassen Object och
        // returnerar en textbeskrivning av anropande objekt.
        public override string ToString()
        {
            return String.Format("{0}, {1:c0}, {2}",
                Name, Salary, HireDay.ToShortDateString());
        }
    }
}
