using System.Runtime.Serialization;

namespace WebServ_FMS_V2.Classes
{
    [DataContract]
    public class FlagRegistration
    {
        [DataMember]
        public int FlagID { get; set; }

        [DataMember]
        public string FlagName { get; set; } 
    }
}