using System;
using System.Data;
using System.Data.SqlClient;
using ReportTesting.Properties;

namespace ReportTesting
{
    public static class GetData
    {
        public static DataTable GetDataRur()
        {
            var results = new DataTable();
            string query = string.Format(@"exec dbo.sp_AccountStatement_Get_Alter  @dateBegin='{0}', @dateEnd='{1}'",
                ReportsForm.dateBegin, ReportsForm.dateEnd);
            using (var conn = new SqlConnection(Settings.Default.TEKConnectionString))
            using (var command = new SqlCommand(query, conn)
            {
                CommandType = CommandType.Text
            })
            {
                using (var dataAdapter = new SqlDataAdapter(command))
                    dataAdapter.Fill(results);
            }
            return results;
        }

        public static DataTable GetDataUsdEur()
        {
            var results = new DataTable();
            string query = @"exec dbo.sp_AccountStatement_Get_Alter_USD_EUR ";
            using (var conn = new SqlConnection(Settings.Default.TEKConnectionString))
            using (var command = new SqlCommand(query, conn)
            {
                CommandType = CommandType.Text
            })
            {
                using (var dataAdapter = new SqlDataAdapter(command))
                    dataAdapter.Fill(results);
            }
            return results;
        }

        public static DataTable GetCourse(string date)
        {
            var results = new DataTable();
            string query = string.Format(@"
                       SELECT
                         iCourseID   AS CourseId,
                         dtDate      AS Date,
                         iCurrencyID AS CurrencyId,
                         mRate       AS Rate
                       FROM dic_CourseRate
                       WHERE iCurrencyID IN (2, 176) AND dtDate = '{0}'
                       ORDER BY dtDate DESC", date);
#if DEBUG
            using (var conn = new SqlConnection(Settings.Default.TEKConnectionString))
            using (var command = new SqlCommand(query, conn)
            {
                CommandType = CommandType.Text
            })
            {
                using (var dataAdapter = new SqlDataAdapter(command))
                    dataAdapter.Fill(results);
            }
#else
            using (var conn = new SqlConnection(Settings.Default.EKGTEKConnectionString))
            using (var command = new SqlCommand(query, conn)
            {
                CommandType = CommandType.Text
            })
            {
                using (var dataAdapter = new SqlDataAdapter(command))
                    dataAdapter.Fill(results);
            }
#endif

            return results;
        }
    }
}