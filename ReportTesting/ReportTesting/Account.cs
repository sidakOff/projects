using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportTesting
{
    public class Account
    {
        public int AccountId { get; set; }
        public int StatementId { get; set; }
        public string PaymentAccount { get; set; }
        public string CompanyName { get; set; }
        public int CompanyId { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
        public decimal? ClosingBalance { get; set; }
        public string BankName { get; set; }
        public string AccountType { get; set; }
        public int AccountFormat { get; set; }
        
    }
}
