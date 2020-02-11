using System.Runtime.Serialization;

namespace WebServ_FMS_V2.Classes
{
    [DataContract]
    public class PageModules
    {
        [DataMember]
        public int ModuleID { get; set; }

        [DataMember]
        public string ModuleName { get; set; }

        [DataMember]
        public string ModuleDescription { get; set; }

        [DataMember]
        public string ModuleURL { get; set; } 
    }
}