using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrockBank
{
   public  enum AccountTypes
    {
        Checking,
        Savings
    }

    public class Account
    {
        //#region Static Varialbes
        //private static int lastAccoubtNumber = 0;
        //#endregion

        #region Properties
        /// <summary>
        /// Account number of the account
        /// </summary>
        [Key]
        public int AccountNumber { get; set; }
        /// <summary>
        /// Email address of the account holder
        /// </summary>
        public string EmailAddress { get; set; }



        public decimal Balance { get; set; }
        
        public DateTime CreatedDate { get; set; }
        public AccountTypes TypeOfAccount { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }

        #endregion

        #region Constructor
        public Account()
        {
            //lastAccountNumber ++1
            //AccountNumber = ++lastAccoubtNumber;
        }
        //public Account(string typeOfAccount) : this()
        //{
        //    TypeOfAccount = typeOfAccount;
        //}
        //public Account(string emailAddress, string typeOfAccount) : this(typeOfAccount)
        //{
        //    EmailAddress = emailAddress;
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
