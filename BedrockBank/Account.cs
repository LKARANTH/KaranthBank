using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrockBank
{
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

        public decimal Balance { get;  private set; }
        public string TypeOfAccount { get; set; }
        #endregion

        #region Constructor
        public Account()
        {
            //lastAccountNumber ++1
            AccountNumber = ++lastAccoubtNumber;
        }
        #endregion

        #region Methods
        public void Deopsit(decimal amount)
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
