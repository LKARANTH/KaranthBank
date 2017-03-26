using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrockBank
{
    static class Bank
    {
        public static Account CreateAccount(string emailAddress, string typeOfAccount,decimal amount)
        {
            var account = new Account
            {
                EmailAddress = emailAddress,
                TypeOfAccount = AccountTypes
            };
            account.Deposit(amount);
            return account;
        }
    }
}
