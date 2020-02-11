using System.Runtime.Serialization;

namespace WebServ_FMS_V2.Classes
{
    [DataContract]
    public class Office
    {
        [DataMember]
        public int OfficeID { get; set; }

        [DataMember]
        public string OfficeCode { get; set; }

        [DataMember]
        public string OfficeName { get; set; }

        [DataMember]
        public bool Active { get; set; } 
    }
}