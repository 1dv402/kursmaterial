using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccounts
{
    class Account
    {
        // Konstant (constant)
        private const double Rate = 0.035;

        // Fält (fields)
        private string _name;
        private int _accountNumber;
        private double _balance;

        // Konstruktor (constructor)
        public Account(string name, int accountNUmber, double balance)
        {
            _name = name;
            _accountNumber = accountNUmber;
            Balance = balance;
        }

        // Egenskaper (properties)
        public int AccountNumber
        {
            get { return _accountNumber; }
        }

        public double Balance
        {
            get { return _balance; }
            private set
            {
                if (value < 0)
                {
                    throw new ApplicationException(
                        "The balance can not be set to a amount less than 0.");
                }
                _balance = value;
            }
        }

        public string Name
        {
            get { return _name; }
        }

        // Metoder (methods)
        public double Deposit(double amount)
        {
            if (amount < 0)
            {
                throw new ApplicationException(
                    "The amount can not be less than 0.");
            }

            Balance += amount;
            return _balance;
        }

        public double Withdraw(double amount, double fee)
        {
            if (amount + fee < 0 ||
                amount + fee > _balance)
            {
                throw new ApplicationException(
                    "Manage your account wisely so you do not overdraw.");
            }

            Balance -= (amount + fee);
            return _balance;
        }

        public double AddInterest()
        {
            Balance *= (1 + Rate);
            return _balance;
        }

        public void DisplayAccount()
        {
            Console.WriteLine("{0}\t{1}\t{2:c}",
                _accountNumber, _name, _balance);
        }
    }
}
