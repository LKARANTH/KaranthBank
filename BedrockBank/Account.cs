using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrockBank
{
    enum AccountTypes
    {
        Checking,
        Savings
    }

    class Account
    {
        #region Static Varialbes
        private static int lastAccoubtNumber = 0;
        #endregion

        #region Properties
        /// <summary>
        /// Account number of the account
        /// </summary>
        public int AccountNumber { get; private set; }
        /// <summary>
        /// Email address of the account holder
        /// </summary>
        public string EmailAddress { get; set; }

        public decimal Balance { get; private set; }
        public AccountTypes TypeOfAccount { get; set; }
        #endregion

        #region Constructor
        public Account()
        {
            //lastAccountNumber ++1
            AccountNumber = ++lastAccoubtNumber;
        }
        //public Account(string typeOfAccount) : this()
        //{
        //    TypeOfAccount = typeOfAccount;
        //}
        //public Account(string emailAddress, string typeOfAccount) : this(typeOfAccount) 
        //{
        //EmailAddress = emailAddress;
        //}

        #endregion

        #region Methods
        public void Deposit(decimal amount)
        {
            //Balance = Balance + amount;
            Balance += amount;
        }
        public void Withdraw(decimal amount)
        {
            Balance -= amount;
        }
        #endregion
    }

}
