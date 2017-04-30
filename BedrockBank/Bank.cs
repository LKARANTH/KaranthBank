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
                TypeOfAccount = (AccountTypes)typeOfAccount,
                CreatedDate = DateTime.Now
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
                db.SaveChanges();
                CreateTransaction("Deposit", TransactionType.Credit, amount, account.AccountNumber);
            }

        }
        public static void Withdrae(int accountNumber, decimal amount)
        {
            var account = db.Accounts.Where(a => a.AccountNumber == accountNumber).FirstOrDefault();
            if (account != null)
            {
                account.Withdraw(amount);
                db.SaveChanges();
                CreateTransaction("Withdraw", TransactionType.Debit, amount, account.AccountNumber);
            }
        }
        private static void CreateTransaction(string description, TransactionType typeOfTransaction, decimal amount, int accountNumber)
        {
            var transaction = new Transaction
            {
                TransactionDate = DateTime.Now,
                Description = description,
                TypeOfTransaction = typeOfTransaction,
                Amount = amount,
                AccountNumber = accountNumber
            };
            db.Transactions.Add(transaction);
            db.SaveChanges();
        }

        public static List<Transaction> GetAllTransactions(int accountNumber)
        {
           return db.Transactions.Where(t => t.AccountNumber == accountNumber).ToList();
        }
    }
}
