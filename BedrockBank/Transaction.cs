using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrockBank
{


    public enum TransactionType
    {
        Credit,
        Debit
    }
        
        public  class Transaction
    {
        [Key]
        public int TransactionID { get; set; }
        public DateTime TrasactionDate { get; set; }
        public string Description { get; set; }
        public TransactionType TypeOfTransaction{ get; set; }
        public decimal Amount{ get; set; }

        [ForeignKey("Account")]
        public int AccountNumber { get; set; }

        public virtual Account Account { get; set; }
        public DateTime TransactionDate { get; internal set; }
    }
}
