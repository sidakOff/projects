using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TelelinkUpload.Properties;

namespace TelelinkUpload
{
    public static class OrderPresenter
    {
        private static List<Order> orders=new List<Order>();
        public static void DoIt(string ordersNumberText)
        {
            List<string> ordersNumber = ordersNumberText.Split(' ').ToList();
            var results = GetOrderData(ordersNumber);
            bool flag = true;
            for (int i = 0; i < results.Rows.Count; i++)
            {
                var record = results.Rows[i];
                if (i == 0)
                {
                    AddOrder(record);
                }
                else
                {
                    var prevOrder = orders.FirstOrDefault();
                    if ((prevOrder.payerSWIFT == record.ItemArray[0].ToString()) &
                        (prevOrder.payerAccountIban == record.ItemArray[1].ToString()) &
                        (prevOrder.currency == record.ItemArray[2].ToString())
                        & (prevOrder.contract == record.ItemArray[4].ToString()) &
                        (prevOrder.beneficiarCompany == record.ItemArray[6].ToString())
                        & (prevOrder.countryBeneficiar == record.ItemArray[7].ToString()) &
                        (prevOrder.beneficiarAddress == record.ItemArray[8].ToString())
                        & (prevOrder.beneficiarAccountIban == record.ItemArray[9].ToString()) &
                        (prevOrder.beneficiarAccount == record.ItemArray[10].ToString())
                        & (prevOrder.beneficiarSWIFT == record.ItemArray[11].ToString()) &
                        (prevOrder.beneficiarBankName == record.ItemArray[12].ToString())
                        & (prevOrder.countryBeneficiarBank == record.ItemArray[13].ToString()) &
                        (prevOrder.addressBankBeneficiar == record.ItemArray[14].ToString())
                        & (prevOrder.correspondentSWIFT == record.ItemArray[15].ToString()) &
                        (prevOrder.correspondentName == record.ItemArray[16].ToString())
                        & (prevOrder.countryCorrespondent == record.ItemArray[17].ToString()) &
                        (prevOrder.correspondentBankAddress == record.ItemArray[18].ToString())
                        & (prevOrder.receiverCompanyCityEng == record.ItemArray[19].ToString()))
                    {
                        AddOrder(record);
                    }
                    else
                    {
                        flag = false;
                        MessageBox.Show("Заявки имеют разные реквизиты");
                    }
                }
            }
            
            if (flag)
            {
                var order = orders.FirstOrDefault();
                var sum = orders.Sum(o => o.summ);
                order=PrepareValues(order);

                var upload =
                    string.Format(
                        @"{0};{1};{2};{3};{4};{5} ; ;{6};{7};{8};{9}; ;;{10} ;{11};{12};{13};{14}; ; ;{15};{16};{17};{18} ; ;4;1;{19};{20};",
                        order.payerSWIFT,
                        order.payerAccountIban, 
                        order.currency,
                        string.Format(sum.ToString()).Replace(",", "."), 
                        order.dateUpload, 
                        order.contract, 
                        order.note,
                        order.beneficiarCompany,
                        order.countryBeneficiar,
                        order.beneficiarAddress,
                        string.IsNullOrWhiteSpace(order.beneficiarAccountIban)
                            ? order.beneficiarAccount
                           : order.beneficiarAccountIban, 
                        order.beneficiarSWIFT,
                        order.beneficiarBankName,
                        order.countryBeneficiarBank,
                        order.addressBankBeneficiar,
                        order.correspondentSWIFT, 
                        order.correspondentName,
                         order.countryCorrespondent,
                        order.correspondentBankAddress, 
                        order.receiverCompanyCityEng, order.brokerSWIFT);
#if DEBUG
                upload = string.Format(upload).Replace(";", ";" + Environment.NewLine);
#endif
                string path = @"C:\Work\UploadToTelelinkFiles";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                path = string.Format(@"C:\Work\UploadToTelelinkFiles\{0}.txt", ordersNumberText); //todo 
                if (!File.Exists(path))
                {
                    File.Create(path).Dispose();
                    TextWriter tw = new StreamWriter(path);
                    tw.Write(upload);
                    tw.Close();
                }
                else if (File.Exists(path))
                {
                    TextWriter tw = new StreamWriter(path, false);
                    tw.Write(upload);
                    tw.Close();
                }
                MessageBox.Show(@"Всё пучком и выгрузилось в папку C:\Work\UploadToTelelinkFiles");
            }
            orders.Clear();
        }

        private static Order PrepareValues(Order order)
        {
            if (!string.IsNullOrEmpty(order.countryBeneficiar))
            {
                order.countryBeneficiar = string.Format(order.countryBeneficiar).Remove(2);
            }
            if (!string.IsNullOrEmpty(order.countryBeneficiarBank))
            {
                order.countryBeneficiarBank = string.Format(order.countryBeneficiarBank).Remove(2);
            }
            if (!string.IsNullOrEmpty(order.countryCorrespondent))
            {
                order.countryCorrespondent = string.Format(order.countryCorrespondent).Remove(2);
            }
            if (!string.IsNullOrEmpty(order.beneficiarAccount))
            {
                order.beneficiarAccount = string.Format(order.beneficiarAccount).Replace(" ", "");
            }
            if (!string.IsNullOrEmpty(order.beneficiarAccountIban))
            {
                order.beneficiarAccountIban = string.Format(order.beneficiarAccountIban).Replace(" ", "");
            }
            if (!string.IsNullOrEmpty(order.brokerSWIFT))
            {
                order.brokerSWIFT = string.Format("/IBK/{0}", order.brokerSWIFT);
            }

            return order;
        }

        private static void AddOrder(DataRow record)
        {
            orders.Add(new Order
            {
                payerSWIFT = record.ItemArray[0].ToString(),
                payerAccountIban = record.ItemArray[1].ToString(),
                currency = record.ItemArray[2].ToString(),
                summ = Convert.ToDecimal(record.ItemArray[3]),
                dateUpload = string.Format(DateTime.Now.ToShortDateString()).Replace(".", "/"),
                contract = record.ItemArray[4].ToString(),
                note = record.ItemArray[5].ToString(),
                beneficiarCompany = record.ItemArray[6].ToString(),
                countryBeneficiar = record.ItemArray[7].ToString(),
                beneficiarAddress = record.ItemArray[8].ToString(),
                beneficiarAccountIban = record.ItemArray[9].ToString(),
                beneficiarAccount = record.ItemArray[10].ToString(),
                beneficiarSWIFT = record.ItemArray[11].ToString(),
                beneficiarBankName = record.ItemArray[12].ToString(),
                countryBeneficiarBank = record.ItemArray[13].ToString(),
                addressBankBeneficiar = record.ItemArray[14].ToString(),
                correspondentSWIFT = record.ItemArray[15].ToString(),
                correspondentName = record.ItemArray[16].ToString(),
                countryCorrespondent = record.ItemArray[17].ToString(),
                correspondentBankAddress = record.ItemArray[18].ToString(),
                receiverCompanyCityEng = record.ItemArray[19].ToString(),
                brokerSWIFT = record.ItemArray[20].ToString()
            });
        }

        private static DataTable GetOrderData(List<string> ordersData)
        {
            var results = new DataTable();
            foreach (var order in ordersData)
            {
                using (var conn = new SqlConnection(Settings.Default.ConnecitionString))
                {
                    #region Запрос

                    string query = string.Format(@"
            select 
                ord.vcPayerBankSwiftCode,
                ord.vcPayerAccountIban,
                ord.vcCurrencyIsoCode,
                ord.mAmount,
                ord.vcAgreementName,
                ord.vcPaymentCoverage,
                ord.vcReceiverCompanyNameEng,
                ord.vcReceiverCompanyCountryCodeAlpha3,
                ord.vcReceiverCompanyAddressEng,
                ord.vcReceiverAccountIban,
                ord.vcReceiverAccount,
                ord.vcReceiverBankSwiftCode,
                ord.vcReceiverBankNameEng,
                ord.vcReceiverBankCountryCodeAlpha3,
                ord.vcReceiverBankAddressEng,
                ord.vcCorrBankSwiftCode,
                ord.vcCorrBankNameEng,
                ord.vcCorrBankCountryCodeAlpha3,
                ord.vcCorrBankAddressEng,
                ord.vcReceiverCompanyCityEng,
                ord.vcIntCorrBankSwiftCode	
            from wh_ForeignPayment ord where iOrderID={0}", order);

                    #endregion

                    using (var command = new SqlCommand(query, conn))
                    using (var dataAdapter = new SqlDataAdapter(command))
                        dataAdapter.Fill(results);
                }
            }
            return results;
        }
    }
}