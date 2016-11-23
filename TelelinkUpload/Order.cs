namespace TelelinkUpload
{
    public class Order
    {
        public string payerSWIFT { get; set; }
        public string payerAccountIban { get; set; }
        public string currency { get; set; }
        public decimal summ { get; set; }
        public string dateUpload { get; set; }
        public string contract { get; set; }
        public string note { get; set; }
        public string beneficiarCompany { get; set; }
        public string countryBeneficiar { get; set; }
        public string beneficiarAddress { get; set; }
        public string beneficiarAccountIban { get; set; }
        public string beneficiarAccount { get; set; }
        public string beneficiarSWIFT { get; set; }
        public string beneficiarBankName { get; set; }
        public string countryBeneficiarBank { get; set; }
        public string addressBankBeneficiar { get; set; }
        public string correspondentSWIFT { get; set; }
        public string correspondentName { get; set; }
        public string countryCorrespondent { get; set; }
        public string correspondentBankAddress { get; set; }
        public string receiverCompanyCityEng { get; set; }
        public string brokerSWIFT { get; set; }
    }
}
