using System.Runtime.Serialization;

namespace WebServ_FMS_V2.Classes
{
    [DataContract]
    public class PaymentMode
    {
        [DataMember]
        public int PaymentModeID { get; set; }

        [DataMember]
        public string PaymentModeCode { get; set; }

        [DataMember]
        public string PaymentModes { get; set; } 
    }
}