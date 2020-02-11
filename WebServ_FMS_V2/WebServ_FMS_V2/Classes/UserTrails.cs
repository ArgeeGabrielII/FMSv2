using System.Runtime.Serialization;

namespace WebServ_FMS_V2.Classes
{
    [DataContract]
    public class UserTrails
    {
        [DataMember]
        public int UserTrailID { get; set; }

        [DataMember]
        public int UserID { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public int RequestID { get; set; }

        [DataMember]
        public string RequestLineID { get; set; }

        [DataMember]
        public string ItemDescription { get; set; }

        [DataMember]
        public string TransType { get; set; }

        [DataMember]
        public string TransDateTime { get; set; } 
    }
}