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
            Console.WriteLine("Please select from the following option");
            Console.WriteLine("0.Exit");
            Console.WriteLine("1. Create an account");
            Console.WriteLine("2.Deposit");
            Console.WriteLine("3.Withdraw");
            var option = Console.ReadLine();
            switch (option)
            {
                case "0":
                    Console.WriteLine("Thank you for visiting! Good bye!");
                    break;
                case "1":
                    var account1 = new Account();
                    Console.Write("Please provide your email address: ");
                    var emailAddress = Console.ReadLine();
                    Console.Write("What type of account you need?");
                    var typeOfAccount = Console.ReadLine();


                    account1.EmailAddress = emailAddress;
                    account1.TypeOfAccount = "Checking";
                    
                   Console.WriteLine($"Accountnumber: {account1.AccountNumber}, EmailAddress: {account1.EmailAddress}, TypeOfAccount: {account1.TypeOfAccount}, Balance: {account1.Balance:C}");
                    break;
                case "2":
                case "3":
               
                default:
                    break;
            }


            
            
          
        
        }
    }
}
