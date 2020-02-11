using System.Runtime.Serialization;

namespace WebServ_FMS_V2.Classes
{
    [DataContract]
    public class GroupRightsRequisition
    {
        [DataMember]
        public int GroupRightRequestID { get; set; }

        [DataMember]
        public int GroupID { get; set; }

        [DataMember]
        public int RequestProcessID { get; set; }

        [DataMember]
        public string RequestProcessName { get; set; }

        [DataMember]
        public bool CanView { get; set; }

        [DataMember]
        public bool CanEdit { get; set; } 
    }
}