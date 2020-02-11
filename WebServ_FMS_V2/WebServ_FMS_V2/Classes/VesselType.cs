using System.Runtime.Serialization;

namespace WebServ_FMS_V2.Classes
{
    [DataContract]
    public class VesselType
    {
        [DataMember]
        public int VesselTypeID { get; set; }

        [DataMember]
        public string VesselTypes { get; set; } 
    }
}