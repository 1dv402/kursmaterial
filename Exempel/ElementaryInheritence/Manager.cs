using System;

namespace ElementaryInheritence
{
    // Klassen ärver allt från Employee men
    // kommer inte åt privata medlemmar i 
    // Employee.
    class Manager : Employee
    {
        // Privat fält för bonus.
        private decimal _bonus;

        // Publik egenskap som kapslar in fältet
        // _bonus och säkerställer att _bonus inte
        // tilldelas ett värde mindre än 0.
        public decimal Bonus
        {
            get { return _bonus; }
            set
            {
                if (value < 0m)
                {
                    throw new ArgumentException();
                }
                _bonus = value;
            }
        }

        // Publik "read-only" egenskap som ger
        // den totala årslönen, d.v.s summan av
        // årlönen (från basklassen) och bonusen.
        public decimal AnnualPay
        {
            get { return Salary + Bonus; }
        }

        // Konstruktor med tre parametrar vars värden används
        // till att initiera objektet via basklassens konstruktor
        // och egenskapen.
        public Manager(string name, decimal salary, DateTime hireDay, decimal bonus)
            : base(name, salary, hireDay)
        {
            Bonus = bonus;
        }

        // Överskuggar metoden ToString i basklassen Employee och
        // returnerar en textbeskrivning av anropande objekt.
        public override string ToString()
        {
            return String.Format("{0}, {1:c0}, {2}",
                Name, AnnualPay, HireDay.ToShortDateString());
        }
    }
}
