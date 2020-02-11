using System.Runtime.Serialization;

namespace WebServ_FMS_V2.Classes
{
    [DataContract]
    public class DepartmentApprover
    {
        [DataMember]
        public int UserID { get; set; }

        [DataMember]
        public string Name { get; set; } 
    }
}