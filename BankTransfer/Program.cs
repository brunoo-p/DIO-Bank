using System;
using System.Collections.Generic;
using BankTransfer.Enum;

namespace BankTransfer
{
    class Program
    {
        static List<Account> list = new List<Account>();
        static string name = string.Empty;
        static string typeOperation = string.Empty;
        static void Main(string[] args)
        {   Console.WriteLine("Nos diga seu nome: ");
            name = Console.ReadLine();
            Console.Clear();

            string option = GetUserOption();
            do
            {
                switch(option)
                {
                    case "1":
                        AccountsList();
                    break;

                    case "2":
                        AddAccount();
                    break;

                    case "3":
                        Transfer();
                    break;

                    case "4":
                        typeOperation = "-"; //CheckOut Value
                        OperationBalance();
                    break;

                    case "5":
                        typeOperation = "+"; //Deposit Value
                        OperationBalance();
                    break;

                    default:
                        Console.WriteLine("Opção inválida.");
                    break;
                }
                option = GetUserOption();
            }while(option.ToUpper() != "X");

            Console.WriteLine($"Até logo, {name}");
        }

        private static void PauseAndClear()
        {
            Console.WriteLine("( Precione qualquer tecla para voltar ao menu. )");
            Console.ReadLine();
            Console.Clear();
        }
        private static void AccountsList() {
            Console.WriteLine("Listar contas\n");
            for(int i = 0; i <14; i++) Console.Write("-");

            if(list.Count == 0 )
            {
                Console.WriteLine("\nNenhuma conta cadastrada.");
                PauseAndClear();
                return;
            }
            foreach(var item in list )
            {
                Account account = item;
                Console.WriteLine("{0} - ", item);
            }
        }
        private static void AddAccount() {
            Console.WriteLine("Inserir nova conta");

            Console.WriteLine("Digite 1 para Conta Física ou 2 para Jurídica: ");
            int type = int.Parse(Console.ReadLine());

            Console.WriteLine("DIgite o Nome do Cliente: ");
            string entryName = Console.ReadLine();

            Console.WriteLine("Digite o saldo inicial: ");
            double entryBalance = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Crédito: ");
            double entryCredit = double.Parse(Console.ReadLine());

            var account = new Account(typeAccount: (TypeAccount) type,
                                      balance: entryBalance,
                                      credit: entryCredit,
                                      name: entryName);

            list.Add(account);
            Console.WriteLine("Conta cadastrada com sucesso!");
            PauseAndClear();
            
        }
        private static void Transfer() {
            Console.WriteLine("Digite o número da conta de origem: ");
            int originIndex = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Digite o número da conta destino: ");
            int recipientIndex = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser transferido: ");
            double value = double.Parse(Console.ReadLine());

            list[originIndex].Transfer(value, list[recipientIndex]);
        }
        private static void OperationBalance() {
            
            Console.WriteLine("Informe o número da conta: ");
            int index = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe o valor: ");
            double value = double.Parse(Console.ReadLine());

            if(typeOperation == "-"){
                list[index].CashOut(value);

            }else{
                list[index].Deposit(value);
            }
        }

        private static string GetUserOption()
        {
            Console.WriteLine();
            Console.WriteLine($"Olá {name}, bem-vindo(a) ao");
            Console.WriteLine("\tDIO Bank\n");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string option = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return option;
        }
    }
}
