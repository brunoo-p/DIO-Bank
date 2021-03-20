using System;
using BankTransfer.Enum;

namespace BankTransfer
{
    public class Account
    {
        private TypeAccount TypeAccount { get; set; }
        private double Balance { get; set; }
        private double Credit { get; set; }
        private string Name { get; set; }

        public Account(TypeAccount typeAccount, double balance, double credit, string name)
        {
            TypeAccount = typeAccount;
            Balance = balance;
            Credit = credit;
            Name = name;
        }

        public bool CashOut(double value)
        {
            if(Balance- value < (Credit * -1))
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }
            Balance -= value;
            Console.WriteLine($"Saldo atual da conta pertencente a {Name} é de {Balance}");
            return true;
        }

        public void Deposit(double value)
        {
            Balance += value;

            Console.WriteLine($"Saldo atual da conta pertencente a {Name} é de {Balance}");
        }

        public void Transfer(double value, Account recipient)
        {
            if(CashOut(value))
            {
                recipient.Deposit(value);
            }
        }

        public override string ToString()
        {
            string retorno = string.Empty;
            retorno += $"TypeAccount: {TypeAccount}\n";
            retorno += $"Name: {Name}\n";
            retorno += $"Balance: {Balance}\n";
            retorno += $"Credit: {Credit}\n";
            
            return retorno;
        }
    }
}