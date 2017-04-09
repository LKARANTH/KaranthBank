﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrockBank
{
    static class Bank
    {
        private static List<Account> accounts = new List<Account>();
        private static  BankModel db = new BankModel();

        public static Account CreateAccount(string emailAddress, AccountTypes typeOfAccount,decimal amount)
        {
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
            return accounts;
        }
        public static void Deposit(int accountNumber, decimal amount)
        {
            var account = accounts.Where(a => a.AccountNumber == accountNumber).FirstOrDefault();
            if (account != null)
            {
                account.Deposit(amount);
            }
        }
    }
}
