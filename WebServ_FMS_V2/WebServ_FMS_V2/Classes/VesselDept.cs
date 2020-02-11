using System.Runtime.Serialization;

namespace WebServ_FMS_V2.Classes
{
    [DataContract]
    public class VesselDept
    {
        [DataMember]
        public int VesselID { get; set; }

        [DataMember]
        public string VesselCode { get; set; }

        [DataMember]
        public string VesselName { get; set; }

        [DataMember]
        public int VesselTypeID { get; set; }

        [DataMember]
        public string VesselType { get; set; }

        [DataMember]
        public int FlagID { get; set; }

        [DataMember]
        public string FlagName { get; set; }

        [DataMember]
        public bool Active { get; set; } 
    }
}