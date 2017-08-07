using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using KellermanSoftware.CompareNetObjects;
using TelelinkUpload.Properties;

namespace TelelinkUpload
{
    public static class OrderPresenter
    {
        private static List<Order> orders = new List<Order>();

        /// <summary>
        /// Грузим заявки в тхт файл
        /// </summary>
        /// <param name="ordersNumberText"></param>
        public static void DoIt(string ordersNumberText)
        {
            var flag = true;
            List<string> ordersNumber = ordersNumberText.Split(' ').ToList();
            var results = GetOrderData(ordersNumber);
            foreach (var record in results.Rows)
            {
                AddOrder(record as DataRow);
            }

            if (orders.Count > 1)
            {
                for (int i = 0; i < orders.Count; i++)
                {
                    if (i > 0)
                    {
                        if (!CompareOrders(orders[0], orders[i]))
                        {
                            MessageBox.Show("Заявки имеют разные реквизиты");
                            flag = false;
                        }
                    }
                }
            }

            if (flag)
            {
                var order = orders.FirstOrDefault(); // если заявок несколько, то значит пользователь грузит в одну, 
                var sum = orders.Sum(o => o.summ); //где реквизиты одни и те же, а суммы складываются
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
                    // раскидываем по полям в столбик
#endif

                WriteToFile(ordersNumberText, upload);
            }
            orders.Clear(); // чистим список от предыдущих заявок
        }

        private static bool CompareOrders(Order firstOrder, Order order)
        {
            var compareLogic=new CompareLogic();
            compareLogic.Config= new ComparisonConfig
            {
                MembersToIgnore = new List<string> { "summ", "paymentDestination" }
            };
            var result=compareLogic.Compare(firstOrder, order).AreEqual;
            
            return result;
        }

        /// <summary>
        /// Пишем в файл
        /// </summary>
        /// <param name="ordersNumberText"></param>
        /// <param name="upload"></param>
        private static void WriteToFile(string ordersNumberText, string upload)
        {
            string path = @"C:\Work\UploadToTelelinkFiles";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path = string.Format(@"C:\Work\UploadToTelelinkFiles\{0}.txt", ordersNumberText); //todo 
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
                TextWriter textWriter = new StreamWriter(path);
                textWriter.Write(upload);
                textWriter.Close();
            }
            else if (File.Exists(path))
            {
                TextWriter textWriter = new StreamWriter(path, false);
                textWriter.Write(upload);
                textWriter.Close();
            }
            MessageBox.Show(@"Всё пучком и выгрузилось в папку C:\Work\UploadToTelelinkFiles");
        }

        /// <summary>
        /// Проводим подготовку полей для записи в файл
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        private static Order PrepareValues(Order order)
        {
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
            if (!string.IsNullOrEmpty(order.paymentDestination))
            {
                order.paymentDestination = string.Format(order.paymentDestination).Replace("   ", "");
            }

            return order;
        }

        /// <summary>
        /// Добавляем заявку в список заявок
        /// </summary>
        /// <param name="record"></param>
        private static void AddOrder(DataRow record)
        {
            orders.Add(new Order
            {
                payerSWIFT = record.Field<string>("PayerBankSwiftCode"),
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

        /// <summary>
        /// Получаем данные по заявке
        /// </summary>
        /// <param name="ordersData"></param>
        /// <returns></returns>
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
                c.vcCodeAlpha2 as ReceiverCompanyCountryCodeAlpha3,
                ord.vcReceiverCompanyAddressEng as ReceiverCompanyAddressEng,
                ord.vcReceiverAccountIban as ReceiverAccountIban,
                ord.vcReceiverAccount as ReceiverAccount,
                ord.vcReceiverBankSwiftCode as ReceiverBankSwiftCode,
                ord.vcReceiverBankNameEng as ReceiverBankNameEng,
                c1.vcCodeAlpha2 as ReceiverBankCountryCodeAlpha3,
                ord.vcReceiverBankAddressEng as ReceiverBankAddressEng,
                ord.vcCorrBankSwiftCode as CorrBankSwiftCode,
                ord.vcCorrBankNameEng as CorrBankNameEng,
                c2.vcCodeAlpha2 as CorrBankCountryCodeAlpha3,
                ord.vcCorrBankAddressEng as CorrBankAddressEng,
                ord.vcReceiverCompanyCityEng as ReceiverCompanyCityEng,
                ord.vcIntCorrBankSwiftCode as IntCorrBankSwiftCode	
            from wh_ForeignPayment ord left join dbo.dic_Country c on ord.iReceiverCompanyCountryID=c.iCountryID
            left join dbo.dic_Country c1 on ord.iReceiverBankCountryID=c1.iCountryID
            left join dbo.dic_Country c2 on ord.iCorrBankCountryID=c2.iCountryID where iOrderID={0}", order);

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