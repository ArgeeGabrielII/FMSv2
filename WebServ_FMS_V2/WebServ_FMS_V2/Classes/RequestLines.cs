using System.Runtime.Serialization;

namespace WebServ_FMS_V2.Classes
{
    [DataContract]
    public class RequestLines
    {
        [DataMember]
        public string RequestLineID { get; set; }

        [DataMember]
        public string RequestLineNo { get; set; }

        [DataMember]
        public string RequestID { get; set; }

        [DataMember]
        public string SubRequestFormNo { get; set; }

        [DataMember]
        public int DepartmentID { get; set; }

        [DataMember]
        public decimal LineQuantity { get; set; }

        [DataMember]
        public decimal StockOnHandQuantity { get; set; }

        [DataMember]
        public decimal PurchasingQuantity { get; set; }

        [DataMember]
        public string UnitOfMeasurement { get; set; }

        [DataMember]
        public string ItemDescription { get; set; }

        [DataMember]
        public int ItemTypeID { get; set; }

        [DataMember]
        public string Make { get; set; }

        [DataMember]
        public string Model { get; set; }

        [DataMember]
        public string Serial_EngineNo { get; set; }

        [DataMember]
        public string PartNo { get; set; }

        [DataMember]
        public string ArrangementNo_CPL { get; set; }

        [DataMember]
        public string WhereToBuy { get; set; }

        [DataMember]
        public string WarehouseStatus { get; set; }

        [DataMember]
        public string DateDue { get; set; }

        [DataMember]
        public int WarehouseSpecialistID { get; set; }

        [DataMember]
        public string WarehouseReceivedDate { get; set; }

        [DataMember]
        public string SendBackRemarks { get; set; }

        [DataMember]
        public string COSNo { get; set; }

        [DataMember]
        public string COSDate { get; set; }

        [DataMember]
        public int ApproverID1 { get; set; }

        [DataMember]
        public string Remarks1 { get; set; }

        [DataMember]
        public string Status1 { get; set; }

        [DataMember]
        public string DateApproved1 { get; set; }

        [DataMember]
        public int ApproverID2 { get; set; }

        [DataMember]
        public string Remarks2 { get; set; }

        [DataMember]
        public string Status2 { get; set; }

        [DataMember]
        public string DateApproved2 { get; set; }

        [DataMember]
        public int ApprovedByID { get; set; }

        [DataMember]
        public string ApprovedDate { get; set; }

        [DataMember]
        public int PurchDeptHeadID { get; set; }

        [DataMember]
        public string PurchDeptRemarks { get; set; }

        [DataMember]
        public int PurchaserID { get; set; }

        [DataMember]
        public int PurchaserID2 { get; set; }

        [DataMember]
        public string PurchaserRemarks { get; set; }

        [DataMember]
        public int AssignedPurchaserID { get; set; }

        [DataMember]
        public string PurchaserReceivedDate { get; set; }

        [DataMember]
        public string PONo { get; set; }

        [DataMember]
        public string PODate { get; set; }

        [DataMember]
        public int IssuerID { get; set; }

        [DataMember]
        public string ReceiverID { get; set; }

        [DataMember]
        public string IssuanceDate { get; set; }

        [DataMember]
        public string IssuanceRemarks { get; set; }

        [DataMember]
        public string VerificationStatus { get; set; }

        [DataMember]
        public string VerifiedBy { get; set; }

        [DataMember]
        public string VerificationRemarks { get; set; }

        [DataMember]
        public int VerifiedByID { get; set; }

        [DataMember]
        public string VerifiedDateTime { get; set; }

        [DataMember]
        public string AuditStatus { get; set; }

        [DataMember]
        public string AuditRemarks { get; set; }

        [DataMember]
        public int AuditedBy { get; set; }

        [DataMember]
        public string AuditDateTime { get; set; }

        [DataMember]
        public int CreatedByID { get; set; }

        [DataMember]
        public string CreatedDateTime { get; set; }

        [DataMember]
        public int ModifiedByID { get; set; }

        [DataMember]
        public string ModifiedDateTime { get; set; }

        [DataMember]
        public decimal COSQty { get; set; }

        [DataMember]
        public decimal POQty { get; set; }

        [DataMember]
        public string ClosingRemarks { get; set; } 
    }
}