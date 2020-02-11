using System.Runtime.Serialization;

namespace WebServ_FMS_V2.Classes
{
    [DataContract]
    public class ViewAllRequest
    {
        [DataMember]
        public string RequestID { get; set; }

        [DataMember]
        public string RequestFormNo { get; set; }

        [DataMember]
        public string RequestDate { get; set; }

        [DataMember]
        public string DateNeeded { get; set; }

        [DataMember]
        public string VesselID { get; set; }

        [DataMember]
        public string VesselName { get; set; }

        [DataMember]
        public string RequestStatus { get; set; }

        [DataMember]
        public string Remarks { get; set; }

        [DataMember]
        public string CreatedByID { get; set; }

        [DataMember]
        public string RequestedBy { get; set; }
    }
}