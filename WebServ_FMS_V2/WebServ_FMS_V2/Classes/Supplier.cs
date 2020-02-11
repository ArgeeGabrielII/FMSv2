using System.Runtime.Serialization;

namespace WebServ_FMS_V2.Classes
{
    [DataContract]
    public class Supplier
    {
        [DataMember]
        public int SupplierID { get; set; }

        [DataMember]
        public string SupplierName { get; set; }

        [DataMember]
        public string ContactPerson { get; set; }

        [DataMember]
        public string ContactNumber { get; set; }

        [DataMember]
        public int CurrencyID { get; set; }

        [DataMember]
        public string CurrencyName { get; set; }

        [DataMember]
        public string Terms { get; set; }

        [DataMember]
        public string ModeOfPayment { get; set; } 
    }
}