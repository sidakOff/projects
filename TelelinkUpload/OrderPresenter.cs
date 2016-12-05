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
        private static List<Order> orders = new List<Order>();

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
                        & (prevOrder.paymentDestination == record.ItemArray[4].ToString()) &
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
                order = PrepareValues(order);

                var upload =
                    string.Format(
                        @"{0};{1};{2};{3};{4};{5} ; ;{6};{7};{8};{9}; ;;{10} ;{11};{12};{13};{14}; ; ;{15};{16};{17};{18} ; ;4;1;{19};{20};",
                        order.payerSWIFT,
                        order.payerAccountIban,
                        order.currency,
                        string.Format(sum.ToString()).Replace(",", "."),
                        order.dateUpload,
                        order.paymentDestination,
                        order.paymentCoverage,
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
            if (!string.IsNullOrEmpty(order.payerAccountIban))
            {
                order.payerAccountIban = string.Format(order.payerAccountIban).Replace(" ", "");
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
                payerSWIFT = record.Field<string>("PayerBankSwiftCode"), //record.ItemArray[0].ToString(),
                payerAccountIban = record.Field<string>("PayerAccountIban"),
                currency = record.Field<string>("CurrencyIsoCode"),
                summ = record.Field<decimal>("Amount"),
                dateUpload = string.Format(DateTime.Now.ToShortDateString()).Replace(".", "/"),
                paymentDestination = record.Field<string>("PaymentDestination"),
                paymentCoverage = record.Field<string>("PaymentCoverage"),
                beneficiarCompany = record.Field<string>("ReceiverCompanyNameEng"),
                countryBeneficiar = record.Field<string>("ReceiverCompanyCountryCodeAlpha3"),
                beneficiarAddress = record.Field<string>("ReceiverCompanyAddressEng"),
                beneficiarAccountIban = record.Field<string>("ReceiverAccountIban"),
                beneficiarAccount = record.Field<string>("ReceiverAccount"),
                beneficiarSWIFT = record.Field<string>("ReceiverBankSwiftCode"),
                beneficiarBankName = record.Field<string>("ReceiverBankNameEng"),
                countryBeneficiarBank = record.Field<string>("ReceiverBankCountryCodeAlpha3"),
                addressBankBeneficiar = record.Field<string>("ReceiverBankAddressEng"),
                correspondentSWIFT = record.Field<string>("CorrBankSwiftCode"),
                correspondentName = record.Field<string>("CorrBankNameEng"),
                countryCorrespondent = record.Field<string>("CorrBankCountryCodeAlpha3"),
                correspondentBankAddress = record.Field<string>("CorrBankAddressEng"),
                receiverCompanyCityEng = record.Field<string>("ReceiverCompanyCityEng"),
                brokerSWIFT = record.Field<string>("IntCorrBankSwiftCode")
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
                ord.vcPayerBankSwiftCode as PayerBankSwiftCode,
                ord.vcPayerAccountIban as PayerAccountIban,
                ord.vcCurrencyIsoCode as CurrencyIsoCode,
                ord.mAmount as Amount,
                ord.vcPaymentDestination as PaymentDestination,
                ord.vcPaymentCoverage as PaymentCoverage,
                ord.vcReceiverCompanyNameEng as ReceiverCompanyNameEng,
                ord.vcReceiverCompanyCountryCodeAlpha3 as ReceiverCompanyCountryCodeAlpha3,
                ord.vcReceiverCompanyAddressEng as ReceiverCompanyAddressEng,
                ord.vcReceiverAccountIban as ReceiverAccountIban,
                ord.vcReceiverAccount as ReceiverAccount,
                ord.vcReceiverBankSwiftCode as ReceiverBankSwiftCode,
                ord.vcReceiverBankNameEng as ReceiverBankNameEng,
                ord.vcReceiverBankCountryCodeAlpha3 as ReceiverBankCountryCodeAlpha3,
                ord.vcReceiverBankAddressEng as ReceiverBankAddressEng,
                ord.vcCorrBankSwiftCode as CorrBankSwiftCode,
                ord.vcCorrBankNameEng as CorrBankNameEng,
                ord.vcCorrBankCountryCodeAlpha3 as CorrBankCountryCodeAlpha3,
                ord.vcCorrBankAddressEng as CorrBankAddressEng,
                ord.vcReceiverCompanyCityEng as ReceiverCompanyCityEng,
                ord.vcIntCorrBankSwiftCode as IntCorrBankSwiftCode	
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