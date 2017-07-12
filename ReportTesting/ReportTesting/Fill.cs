using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ReportTesting
{
    public class Fill
    {
        public static List<Account> FillAccounts(decimal eur, decimal usd)
        {
            var accounts = new List<Account>();
            var rowsRur = GetData.GetDataRur().Rows;
            var rowsUsdEur = GetData.GetDataUsdEur().Rows;
            foreach (DataRow record in rowsRur)
            {
                var account = new Account()
                {
                    AccountId = record.Field<int>("AccountId"),
                    StatementId = record.Field<int>("StatementId"),
                    PaymentAccount = record.Field<string>("PaymentAccount"),
                    CompanyName = record.Field<string>("CompanyName"),
                    CompanyId = record.Field<int>("CompanyId"),
                    DateBegin = record.Field<DateTime>("DateBegin"),
                    DateEnd = record.Field<DateTime>("DateEnd"),
                    ClosingBalance = record.Field<decimal?>("ClosingBalance"),
                    BankName = record.Field<string>("BankName"),
                    AccountType = record.Field<string>("AccountType"),
                    AccountFormat = record.Field<int>("AccountFormat")
                };
                accounts.Add(account);
            }

            foreach (DataRow dataRow in rowsUsdEur)
            {
                var moneyType = dataRow.Field<int>("AccountFormat");
                var moneyTmp= dataRow.Field<decimal?>("ClosingBalance");
                var money = moneyType == 2 ? moneyTmp*usd : moneyTmp*eur;
                var account = new Account()
                {
                    AccountId = dataRow.Field<int>("AccountId"),
                    StatementId = dataRow.Field<int>("StatementId"),
                    PaymentAccount = dataRow.Field<string>("PaymentAccount"),
                    CompanyName = dataRow.Field<string>("CompanyName"),
                    CompanyId = dataRow.Field<int>("CompanyId"),
                    DateBegin = dataRow.Field<DateTime>("DateBegin"),
                    DateEnd = dataRow.Field<DateTime>("DateEnd"),
                    ClosingBalance = money,
                    BankName = dataRow.Field<string>("BankName"),
                    AccountType = dataRow.Field<string>("AccountType"),
                    AccountFormat = dataRow.Field<int>("AccountFormat")
                };
                accounts.Add(account);
            }
            var newLst = from account in accounts
                group account by new
                {
                    account.CompanyName,
                    account.BankName,
                    account.AccountType,
                    account.AccountFormat
                }
                into grouped
                select
                new Account()
                {
                    CompanyName = grouped.Key.CompanyName,
                    BankName = grouped.Key.BankName,
                    AccountType = grouped.Key.AccountType,
                    ClosingBalance = grouped.Sum(o => o.ClosingBalance)
                };
            var lst = newLst.ToList();
            lst.RemoveAll(o => o.ClosingBalance == 0);
            return lst;
        }

        public static List<CourseRate> FillRate()
        {
            var courseRates=new List<CourseRate>();
            var rates = GetData.GetCourse().Rows;
            foreach (DataRow dataRow in rates)
            {
                var courseRate=new CourseRate()
                {
                    CourseId = dataRow.Field<int>("CourseId"),
                    Date = dataRow.Field<DateTime>("Date"),
                    CurrencyId = dataRow.Field<int>("CurrencyId"),
                    Rate = dataRow.Field<decimal>("Rate")
                };
                courseRates.Add(courseRate);
            }
            return courseRates;
        }

    }
}