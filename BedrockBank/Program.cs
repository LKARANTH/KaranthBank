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
           var account1 =  new Account();
            account1.EmailAddress = "test@test.com";
            account1.TypeOfAccount = "Checking";
            account1.Deopsit(105.40M);
            Console.WriteLine($"Accountnumber: {account1.AccountNumber}, EmailAddress: {account1.EmailAddress}, TypeOfAccount: {account1.TypeOfAccount}, Balance: {account1.Balance:C}");
            
          
        
        }
    }
}
