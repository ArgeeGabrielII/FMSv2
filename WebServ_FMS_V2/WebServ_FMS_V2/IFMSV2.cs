using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebServ_FMS_V2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFMSV2" in both code and config file together.
    [ServiceContract]
    public interface IFMSV2
    {
        #region Get Data

        #region Requisition

        #region View Request

        [OperationContract]
        string Get_ViewAllRequest(string _Parameter, int UserID, string Token);

        [OperationContract]
        string Get_DraftRequests(string _Parameter, int _UserID, string _Token);

        #endregion

        #region View Request Header

        [OperationContract]
        string Get_RequestHeader(string _RequestID, int _UserID, string _Token);

        #endregion

        #region Request Form

        [OperationContract]
        string Add_RequestHeader(int _UserID, string _Token);

        [OperationContract]
        string Get_RequestLines_ForVerify(int _RequestID, int _UserID, string _Token);

        [OperationContract]
        string Get_RequestLines_ForAudit(int _RequestID, int _UserID, string _Token);

        [OperationContract]
        string Get_RequestLines_ForClosing(int _RequestID, int _UserID, string _Token);

        #endregion

        #endregion

        #region Access Management

        [OperationContract]
        string GetUserPass(string Username, string Password);

        [OperationContract]
        string Get_UserAccessRights(int GroupID);

        #endregion

        #region Account Management

        [OperationContract]
        string Get_UserAccount(string _Parameter, int _UserID, string _Token);

        [OperationContract]
        string Get_UserGroups(string _Parameter, int _UserID, string _Token);

        [OperationContract]
        string Get_GroupRights(string _Parameter, int _UserID, string _Token);

        [OperationContract]
        string Get_GroupRights_Requisition(string _Parameter, int _UserID, string _Token);

        #endregion

        #region Data Management

        [OperationContract]
        string Get_Office(string _Parameter, int _UserID, string _Token);

        [OperationContract]
        string Get_Departments(string _Parameter, int _UserID, string _Token);

        [OperationContract]
        string Get_DepartmentApprover(string _Parameter, int _UserID, string _Token);

        [OperationContract]
        string Get_Supplier(string _Parameter, int _UserID, string _Token);

        [OperationContract]
        string Get_Currency(string _Parameter, int _UserID, string _Token);

        [OperationContract]
        string Get_PaymentMode(string _Parameter, int _UserID, string _Token);

        [OperationContract]
        string Get_PaymentTerm(string _Parameter, int _UserID, string _Token);

        [OperationContract]
        string Get_VesselDepartment(string _Parameter, int _UserID, string _Token);

        [OperationContract]
        string Get_VesselType(string _Parameter, int _UserID, string _Token);

        [OperationContract]
        string Get_FlagRegistration(string _Parameter, int _UserID, string _Token);

        [OperationContract]
        string Get_PageModules(string _Parameter, int _UserID, string _Token);
        
        #endregion

        #endregion

        #region Save Data

        #region Request Form

        #region Request Header

        [OperationContract]
        void Save_RequestHeader(int RequestID, string RequestStatus, int VesselID, string RequestDate, string DateNeeded, string ItemFor, string Notify, string DeliverTo, string Remarks, int _UserID, string _Token);

        #endregion

        #endregion

        #region Account Management

        [OperationContract]
        void Save_UserAccounts(int UserID, string UserName, string Password, string FirstName, string LastName, int GroupID, string EmailAddress, string Office, int DepartmentID, bool Active, int _UserID, string _Token);

        [OperationContract]
        void Save_UserGroups(int ID, string GroupName, string Description, bool Active, int _UserID, string _Token);
        
        [OperationContract]
        void Save_GroupRights(int GroupRightID, int GroupID, int ModuleID, bool CanView, bool CanEdit, bool CanDelete, int _UserID, string _Token);

        [OperationContract]
        void Save_GroupRights_Requisition(int GroupRightRequestID, int GroupID, int RequestProcessID, bool CanView, bool CanEdit, int _UserID, string _Token);
        
        #endregion

        #region Data Management

        [OperationContract]
        void Save_Department(int DepartmentID, string DepartmentName, int ManilaApproverID1, int ManilaApproverID2, int GenSanApproverID1, int GenSanApproverID2, int _UserID, string _Token);

        [OperationContract]
        void Save_Currency(int CurrencyID, string CurrencyCode, string CurrencyName, int _UserID, string _Token);

        [OperationContract]
        void Save_Supplier(int SupplierID, string SupplierName, string ContactPerson, string ContactNumber, int CurrencyID, string PaymentTerms, string ModeOfPayment, int _UserID, string _Token);

        [OperationContract]
        void Save_VesselDepartment(int VesselID, string VesselCode, string VesselName, string VesselType, string FlagRegistration, bool Active, int _UserID, string _Token);

        [OperationContract]
        void Save_FlagRegistration(int FlagID, string FlagName, int _UserID, string _Token);

        [OperationContract]
        void Save_Office(int OfficeID, string OfficeCode, string OfficeName, bool Active, int _UserID, string _Token);

        [OperationContract]
        void Save_PageModules(int ModuleID, string ModuleName, string ModuleDescription, string ModuleURL, int _UserID, string _Token);

        [OperationContract]
        void Save_PaymentMode(int PaymentModeID, string PaymentModeCode, string PaymentMode, int _UserID, string _Token);

        [OperationContract]
        void Save_PaymentTerms(int PaymentTermID, string PaymentTermsCode, string PaymentTerm, int _UserID, string _Token);

        [OperationContract]
        void Save_VesselType(int VesselTypeID, string VesselType, int _UserID, string _Token);

        #endregion

        #endregion

        #region Logs Management

        [OperationContract]
        bool Validate_Token(int UserID, string TokenID);

        [OperationContract]
        void Save_TransactionLogs(int UserID, string FormName, string EventName, string ExceptionError, string ComputerName, string IPAddress);

        [OperationContract]
        void Trails_UserTrails(int UserID, int RequestID, int RequestLineID, string TransType);

        [OperationContract]
        string Get_UserTrails(string RequestID, int _UserID, string _Token);

        [OperationContract]
        string Get_TransactionLogs(string _Parameter, int _UserID, string _Token);

        #endregion
    }
}
