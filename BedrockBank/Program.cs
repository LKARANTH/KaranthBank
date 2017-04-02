using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrockBank
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("************Welcome to Bedrock Bank!***********");

            while (true)
            {


                Console.WriteLine("Please select from the following option");
                Console.WriteLine("0.Exit");
                Console.WriteLine("1. Create an account");
                Console.WriteLine("2.Deposit");
                Console.WriteLine("3.Withdraw");
                Console.WriteLine("4. Prinat all accounts");
                var option = Console.ReadLine();
                switch (option)
                {
                    case "0":
                        Console.WriteLine("Thank you for visiting! Good bye!");
                        return;
                    case "1":

                        Console.Write("Please provide your email address: ");
                        var emailAddress = Console.ReadLine();
                        Console.WriteLine("What type of account you need?");
                        var accountTypes = Enum.GetNames(typeof(AccountTypes));
                        for (var i = 0; i < accountTypes.Length ; i++)
                        {
                            Console.WriteLine($"{i+1} . {accountTypes[i]}");
                        }
                        var typeOfAccount = Convert.ToInt32(Console.ReadLine());
                        var account1 = Bank.CreateAccount(emailAddress, (AccountTypes)(typeOfAccount-1), 0.0M);
                        Console.WriteLine($"Accountnumber: {account1.AccountNumber}, EmailAddress: {account1.EmailAddress}, TypeOfAccount: {account1.TypeOfAccount}, Balance: {account1.Balance:C}");
                        break;
                    case "2":
                        PrintAllAccounts();
                        Console.Write("Pick an account number to deposit");
                        var accountNumber = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Amount to deposit: ");
                        var amount = Convert.ToDecimal(Console.ReadLine());
                        Bank.Deposit(accountNumber, amount);
                        break;
                    case "3":
                    case "4":
                        PrintAllAccounts();
                        break;
                    default:
                        break;
                }
            }

        }

        private static void PrintAllAccounts()
        {
            var accounts = Bank.GetAllAccounts();
            foreach (var account in accounts)
            {
                Console.WriteLine($"Accountnumber: {account.AccountNumber}, EmailAddress: {account.EmailAddress}, TypeOfAccount: {account.TypeOfAccount}, Balance: {account.Balance:C}");
            }
        }
    }
}
