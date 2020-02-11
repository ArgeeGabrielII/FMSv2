using System.Runtime.Serialization;

namespace WebServ_FMS_V2.Classes
{
    [DataContract]
    public class TransactionLogs
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public int UserID { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string FormName { get; set; }

        [DataMember]
        public string EventName { get; set; }

        [DataMember]
        public string ExceptionError { get; set; }

        [DataMember]
        public string ComputerName { get; set; }

        [DataMember]
        public string IPAddress { get; set; }

        [DataMember]
        public string DateTimeLogs { get; set; } 
    }
}