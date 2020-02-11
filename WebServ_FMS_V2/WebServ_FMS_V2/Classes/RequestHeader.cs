using System.Runtime.Serialization;

namespace WebServ_FMS_V2.Classes
{
    [DataContract]
    public class RequestHeader
    {
        [DataMember]
        public int RequestID { get; set; }

        [DataMember]
        public string RequestFormNo { get; set; }

        [DataMember]
        public string RequestStatus { get; set; }

        [DataMember]
        public int VesselID { get; set; }

        [DataMember]
        public string RequestDate { get; set; }

        [DataMember]
        public string DateNeeded { get; set; }

        [DataMember]
        public string ItemFor { get; set; }

        [DataMember]
        public string Notify { get; set; }

        [DataMember]
        public string DeliverTo { get; set; }

        [DataMember]
        public string Remarks { get; set; }

        [DataMember]
        public int CreatedByID { get; set; }

        [DataMember]
        public string CreatedDateTime { get; set; }

        [DataMember]
        public int ModifiedByID { get; set; }

        [DataMember]
        public string ModifiedDateTime { get; set; } 
    }
}