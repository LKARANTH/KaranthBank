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

        public static Account CreateAccount(string emailAddress, int typeOfAccount,decimal amount)
        {
            if (string.IsNullOrEmpty(emailAddress))
            {
                throw new ArgumentNullException("Email Addree cannot be empty. ");
            }
            if (amount < 0.0M)
            {
                throw new ArgumentException("Amount cannot be less thank zero");
            }
            var accountType = Enum.GetName(typeof(AccountTypes), typeOfAccount);
                if (string.IsNullOrEmpty(accountType))
            {
                throw new ArgumentException("Invalid account type. ");
            }
            var account = new Account
            { 
                EmailAddress = emailAddress,
                TypeOfAccount = (AccountTypes)typeOfAccount
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
        public static void Withdrae(int accountNumber, decimal amount)
        {
            var account = db.Accounts.Where(a => a.AccountNumber == accountNumber).FirstOrDefault();
            if (account != null)
            {
                account.Withdraw(amount);
            }
        }
    }
}
