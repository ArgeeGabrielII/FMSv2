using System.Runtime.Serialization;

namespace WebServ_FMS_V2.Classes
{
    [DataContract]
    public class PaymentTerm
    {
        [DataMember]
        public int PaymentTermID { get; set; }

        [DataMember]
        public string PaymentTermsCode { get; set; }

        [DataMember]
        public string PaymentTerms { get; set; } 
    }
}