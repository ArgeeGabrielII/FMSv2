using System.Runtime.Serialization;

namespace WebServ_FMS_V2.Classes
{
    [DataContract]
    public class Departments
    {
        [DataMember]
        public int DepartmentID { get; set; }

        [DataMember]
        public string DepartmentName { get; set; }

        [DataMember]
        public int ManilaApproverID1 { get; set; }

        [DataMember]
        public int ManilaApproverID2 { get; set; }

        [DataMember]
        public int GenSanApproverID1 { get; set; }

        [DataMember]
        public int GenSanApproverID2 { get; set; }

        [DataMember]
        public string ManilaFullName1 { get; set; }

        [DataMember]
        public string ManilaFullName2 { get; set; }

        [DataMember]
        public string GenSanFullName1 { get; set; }

        [DataMember]
        public string GenSanFullName2 { get; set; }
    }
}