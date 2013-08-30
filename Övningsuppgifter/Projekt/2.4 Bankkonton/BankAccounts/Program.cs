using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccounts
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Bankkonton";

            Account account1 = new Account("Sparkap Ital", 15672, 2559.37);
            Account account2 = new Account("Fatti Glapp", 78153, 17.12);
            Account account3 = new Account("Massap Engar", 93781, 15869435.98);

            Console.WriteLine("{0} sätter in pengar.", account1.Name);
            account1.Deposit(441.50);
            account1.DisplayAccount();

            Console.WriteLine("\n{0} tar ut pengar.", account1.Name);
            account1.Withdraw(980, 23.5);
            account1.DisplayAccount();

            Console.WriteLine("\n{0} försöker ta ut 10000 kr.", account2.Name);
            try
            {
                account2.Withdraw(10000, 23.5);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            account2.DisplayAccount();

            Console.WriteLine("\nRänta sätts in");
            account1.AddInterest();
            account2.AddInterest();
            account3.AddInterest();

            Console.WriteLine("\nAlla konton");
            account1.DisplayAccount();
            account2.DisplayAccount();
            account3.DisplayAccount();
            Console.WriteLine();
        }
    }
}
