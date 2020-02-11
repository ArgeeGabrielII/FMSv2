using System.Runtime.Serialization;

namespace WebServ_FMS_V2.Classes
{
    [DataContract]
    public class UserGroup
    {
        [DataMember]
        public int GroupID { get; set; }

        [DataMember]
        public string GroupName { get; set; }

        [DataMember]
        public string GroupDescription { get; set; }

        [DataMember]
        public bool Active { get; set; } 
    }
}