using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using ReportTesting.Properties;

namespace ReportTesting
{
    public partial class ReportsForm : Form
    {
        public static DateTime dateBegin;
        public static DateTime dateEnd;
        private List<CourseRate> courseRates;
        private decimal usd;
        private decimal eur;
        private static string dateCourse;

        public ReportsForm()
        {
            InitializeComponent();
            GetCourseToDate();
        }

        private void GetCourseToDate()
        {
            dateCourse = getCourseDateTimePicker.Value.ToShortDateString();
            courseRates = Fill.FillRate(dateCourse);
            usd = courseRates.FirstOrDefault(o => o.CurrencyId == 2).Rate;
            eur = courseRates.FirstOrDefault(o => o.CurrencyId == 176).Rate;
            eurLabelVal.Text = eur.ToString();
            usdLabelVal.Text = usd.ToString();
        }

        private void loadDataButton_Click(object sender, EventArgs e)
        {
            GetCourseToDate();
            dateBegin = beginDateTimePicker.Value;
            dateEnd = endDateTimePicker.Value;
            GetAccountValues();
        }

        private void GetAccountValues()
        {
            AccountDataSet accountDataSet = new AccountDataSet();
            
            var accounts = Fill.FillAccounts(eur, usd);
            foreach (var account in accounts)
            {
                accountDataSet.Tables[0].Rows.Add(account.AccountId, account.StatementId, account.PaymentAccount,
                    account.CompanyName, account.CompanyId, account.DateBegin, account.DateEnd, account.ClosingBalance,
                    account.BankName, account.AccountType, account.AccountFormat, account.ClosingBalanceDefRur);
            }
            ReportDataSource rds = new ReportDataSource("AccountDT", accountDataSet.Tables[0]);
            this.accountReportViewer.LocalReport.DataSources.Clear();
            this.accountReportViewer.LocalReport.DataSources.Add(rds);
            this.accountReportViewer.LocalReport.Refresh();
            this.accountReportViewer.RefreshReport();
        }


        //public static AccountDataSet ToDataSet<T>(IList<T> list)
        //{
        //    Type elementType = typeof(T);
        //    AccountDataSet ds = new AccountDataSet();
        //    DataTable t = new DataTable();
        //    ds.Tables.Add(t);

        //    //add a column to table for each public property on T
        //    foreach (var propInfo in elementType.GetProperties())
        //    {
        //        Type ColType = Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType;

        //        t.Columns.Add(propInfo.Name, ColType);
        //    }

        //    //go through each property on T and add each value to the table
        //    foreach (T item in list)
        //    {
        //        DataRow row = t.NewRow();

        //        foreach (var propInfo in elementType.GetProperties())
        //        {
        //            row[propInfo.Name] = propInfo.GetValue(item, null) ?? DBNull.Value;
        //        }

        //        t.Rows.Add(row);
        //    }

        //    return ds;
        //}


        private void ReportsForm_Load(object sender, EventArgs e)
        {
            this.accountReportViewer.RefreshReport();
            getCourseDateTimePicker.Value=DateTime.Now;
        }
    }
}