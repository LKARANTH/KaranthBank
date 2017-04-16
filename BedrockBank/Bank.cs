using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrockBank
{
    static class Bank
    {
       // private static List<Account> accounts = new List<Account>();
        private static  BankModel db = new BankModel();

        public static Account CreateAccount(string emailAddress, AccountTypes typeOfAccount,decimal amount)
        {
            if (string.IsNullOrEmpty(emailAddress))
            {
                throw new ArgumentNullException("Email Addree cannot be empty. ");
            }
            if (amount < 0.0M)
            {
                throw new ArgumentException("Amount cannot be less thank 0");
            }
            
            
            var account = new Account
            { 
                EmailAddress = emailAddress,
                TypeOfAccount = typeOfAccount
            };
            account.Deposit(amount);
            //accounts.Add(account);
            db.Accounts.Add(account);
            db.SaveChanges();
            return account;
        }
        public static List<Account> GetAllAccounts()
        {
            return db.Accounts.ToList();
            
        }
        public static void Deposit(int accountNumber, decimal amount)
        {
            var account = db.Accounts.Where(a => a.AccountNumber == accountNumber).FirstOrDefault();
            if (account != null)
            {
                account.Deposit(amount);
            }
        }
    }
}
