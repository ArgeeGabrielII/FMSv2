using System;
using System.Collections.Generic;
using System.Data;
using System.ServiceModel;
using System.Web.Script.Serialization;
using System.Web.Services;
using FMSVS_DataAccess;
using Newtonsoft.Json;
using WebServ_FMS_V2.Classes;

namespace WebServ_FMS_V2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FMSV2" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select FMSV2.svc or FMSV2.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class FMSV2 : IFMSV2
    {
        #region Declaration(s)

        public DataAccess mclsda = new DataAccess();
        string _jsonResponse = string.Empty;
        JavaScriptSerializer jsonSerialiser = new JavaScriptSerializer();

        #endregion

        #region Get Data

        #region Requisition

        #region View Requests

        [WebMethod]
        public string Get_ViewAllRequest(string _Parameter, int _UserID, string _Token)
        {
            List<ViewAllRequest> uViewAllRequest = new List<ViewAllRequest>();

            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("Parameter", _Parameter);

                    using (DataTableReader dtr = mclsda.ExecuteReader("[RFS].[Get_ViewAllRequests]", CommandType.StoredProcedure))
                    {
                        if (dtr.HasRows)
                        {
                            while (dtr.Read())
                            {
                                uViewAllRequest.Add(new ViewAllRequest
                                {
                                    RequestID = dtr["RequestID"].ToString(),
                                    RequestFormNo = dtr["RequestFormNo"].ToString(),
                                    RequestDate = dtr["RequestDate"].ToString(),
                                    DateNeeded = dtr["DateNeeded"].ToString(),
                                    VesselID = dtr["VesselID"].ToString(),
                                    VesselName = dtr["VesselName"].ToString(),
                                    RequestStatus = dtr["RequestStatus"].ToString(),
                                    Remarks = dtr["Remarks"].ToString(),
                                    CreatedByID = dtr["CreatedByID"].ToString(),
                                    RequestedBy = dtr["RequestedBy"].ToString()
                                });
                            }
                        }
                    }

                    _jsonResponse = jsonSerialiser.Serialize(uViewAllRequest);
                }
                catch (Exception) { _jsonResponse = ""; }
                finally { mclsda.dbClose(); }
            }
            else { _jsonResponse = ""; }

            return _jsonResponse;
        }

        [WebMethod]
        public string Get_DraftRequests(string _Parameter, int _UserID, string _Token)
        {
            List<ViewAllRequest> uViewAllRequest = new List<ViewAllRequest>();

            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("UserID", _UserID);
                    mclsda.AddParameter("Parameter", _Parameter);

                    using (DataTableReader dtr = mclsda.ExecuteReader("[RFS].[Get_DraftRequests]", CommandType.StoredProcedure))
                    {
                        if (dtr.HasRows)
                        {
                            while (dtr.Read())
                            {
                                uViewAllRequest.Add(new ViewAllRequest
                                {
                                    RequestID = dtr["RequestID"].ToString(),
                                    RequestFormNo = dtr["RequestFormNo"].ToString(),
                                    RequestDate = dtr["RequestDate"].ToString(),
                                    DateNeeded = dtr["DateNeeded"].ToString(),
                                    VesselID = dtr["VesselID"].ToString(),
                                    VesselName = dtr["VesselName"].ToString(),
                                    RequestStatus = dtr["RequestStatus"].ToString(),
                                    Remarks = dtr["Remarks"].ToString(),
                                    CreatedByID = dtr["CreatedByID"].ToString(),
                                    RequestedBy = dtr["RequestedBy"].ToString()
                                });
                            }
                        }
                    }

                    _jsonResponse = jsonSerialiser.Serialize(uViewAllRequest);
                }
                catch (Exception) { _jsonResponse = ""; }
                finally { mclsda.dbClose(); }
            }
            else { _jsonResponse = ""; }

            return _jsonResponse;
        }

        #endregion

        #region View Request Header

        [WebMethod]
        public string Get_RequestHeader(string _RequestID, int _UserID, string _Token)
        {
            List<RequestHeader> uRequestHeader = new List<RequestHeader>();

            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("RequestID", _RequestID);
                    mclsda.AddParameter("UserID", _UserID);

                    using (DataTableReader dtr = mclsda.ExecuteReader("[RFS].[Get_RequestHeader]", CommandType.StoredProcedure))
                    {
                        if (dtr.HasRows)
                        {
                            while (dtr.Read())
                            {
                                uRequestHeader.Add(new RequestHeader
                                {
                                    RequestID = Convert.ToInt32(dtr["RequestID"].ToString()),
                                    RequestFormNo = dtr["RequestFormNo"].ToString(),
                                    RequestDate = dtr["RequestDate"].ToString(),
                                    DateNeeded = dtr["DateNeeded"].ToString(),
                                    VesselID = Convert.ToInt32(dtr["VesselID"].ToString()),
                                    ItemFor = dtr["ItemFor"].ToString(),
                                    RequestStatus = dtr["RequestStatus"].ToString(),
                                    Notify = dtr["Notify"].ToString(),
                                    DeliverTo = dtr["DeliverTo"].ToString(),
                                    Remarks = dtr["Remarks"].ToString(),
                                    CreatedByID = Convert.ToInt32(dtr["CreatedByID"].ToString())
                                });
                            }
                        }
                    }

                    _jsonResponse = jsonSerialiser.Serialize(uRequestHeader);
                }
                catch (Exception) { _jsonResponse = ""; }
                finally { mclsda.dbClose(); }
            }
            else { _jsonResponse = ""; }

            return _jsonResponse;
        }

        #endregion

        #region Request Form

        [WebMethod]
        public string Add_RequestHeader(int _UserID, string _Token)
        {
            List<RequestHeader> uRequestHeader = new List<RequestHeader>();

            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("UserID", _UserID);

                    using (DataTableReader dtr = mclsda.ExecuteReader("[RFS].[Add_RequestHeader]", CommandType.StoredProcedure))
                    {
                        if (dtr.HasRows)
                        {
                            while (dtr.Read())
                            {
                                uRequestHeader.Add(new RequestHeader
                                {
                                    RequestID = Convert.ToInt32(dtr["RequestID"].ToString()),
                                    RequestFormNo = dtr["RequestFormNo"].ToString(), 
                                    RequestStatus = dtr["RequestStatus"].ToString(),
                                    VesselID = Convert.ToInt32(dtr["VesselID"].ToString()),
                                    RequestDate = dtr["RequestDate"].ToString(),
                                    DateNeeded = dtr["DateNeeded"].ToString(),
                                    ItemFor = dtr["ItemFor"].ToString(),
                                    Notify = dtr["Notify"].ToString(),
                                    DeliverTo = dtr["DeliverTo"].ToString(),
                                    Remarks = dtr["Remarks"].ToString(),
                                    CreatedByID = Convert.ToInt32(dtr["CreatedByID"].ToString()),
                                    CreatedDateTime = Convert.ToDateTime(dtr["CreatedDateTime"].ToString()).ToString("yyyy-MM-dd"),
                                    ModifiedByID = Convert.ToInt32(dtr["ModifiedByID"].ToString()),
                                    ModifiedDateTime = Convert.ToDateTime(dtr["ModifiedDateTime"].ToString()).ToString("yyyy-MM-dd"), 
                                });
                            }
                        }
                    }

                    _jsonResponse = jsonSerialiser.Serialize(uRequestHeader);
                }
                catch (Exception) { _jsonResponse = ""; }
                finally { mclsda.dbClose(); }
            }
            else { _jsonResponse = ""; }

            return _jsonResponse;
        }

        [WebMethod]
        public string Get_RequestLines_ForVerify(int _RequestID, int _UserID, string _Token)
        {
            List<RequestLines> uRequestLines = new List<RequestLines>();

            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("RequestID", _RequestID);
                    mclsda.AddParameter("UserID", _UserID);

                    using (DataTableReader dtr = mclsda.ExecuteReader("[RFS].[Get_RequestLines_ForVerify]", CommandType.StoredProcedure))
                    {
                        if (dtr.HasRows)
                        {
                            while (dtr.Read())
                            {
                                uRequestLines.Add(new RequestLines
                                {
                                    RequestLineID = dtr["RequestLineID"].ToString(),
                                    RequestLineNo = dtr["RequestLineNo"].ToString(),
                                    RequestID = dtr["RequestID"].ToString(),
                                    SubRequestFormNo = dtr["SubRequestFormNo"].ToString(),
                                    LineQuantity = Convert.ToDecimal(dtr["LineQuantity"].ToString()),
                                    UnitOfMeasurement = dtr["UnitOfMeasurement"].ToString(),
                                    ItemDescription = dtr["ItemDescription"].ToString(),
                                    PONo = dtr["PONo"].ToString(),
                                    COSNo = dtr["COSNo"].ToString(),
                                    VerificationStatus = dtr["VerificationStatus"].ToString(),
                                    VerifiedBy = dtr["VerifiedBy"].ToString(),
                                    VerifiedDateTime = dtr["VerifiedDateTime"].ToString(),
                                    VerificationRemarks = dtr["VerificationRemarks"].ToString()
                                });
                            }
                        }
                    }

                    _jsonResponse = jsonSerialiser.Serialize(uRequestLines);
                }
                catch (Exception) { _jsonResponse = ""; }
                finally { mclsda.dbClose(); }
            }
            else { _jsonResponse = ""; }

            return _jsonResponse;
        }

        [WebMethod]
        public string Get_RequestLines_ForAudit(int _RequestID, int _UserID, string _Token)
        {
            List<RequestLines> uRequestLines = new List<RequestLines>();

            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("RequestID", _RequestID);
                    mclsda.AddParameter("UserID", _UserID);

                    using (DataTableReader dtr = mclsda.ExecuteReader("[RFS].[Get_RequestLines_ForAudit]", CommandType.StoredProcedure))
                    {
                        if (dtr.HasRows)
                        {
                            while (dtr.Read())
                            {
                                uRequestLines.Add(new RequestLines
                                {
                                    RequestLineID = dtr["RequestLineID"].ToString(),
                                    RequestLineNo = dtr["RequestLineNo"].ToString(),
                                    RequestID = dtr["RequestID"].ToString(),
                                    SubRequestFormNo = dtr["SubRequestFormNo"].ToString(),
                                    LineQuantity = Convert.ToDecimal(dtr["LineQuantity"].ToString()),
                                    UnitOfMeasurement = dtr["UnitOfMeasurement"].ToString(),
                                    ItemDescription = dtr["ItemDescription"].ToString(),
                                    PONo = dtr["PONo"].ToString(),
                                    COSNo = dtr["COSNo"].ToString(),
                                    AuditRemarks = dtr["AuditRemarks"].ToString()
                                });
                            }
                        }
                    }

                    _jsonResponse = jsonSerialiser.Serialize(uRequestLines);
                }
                catch (Exception) { _jsonResponse = ""; }
                finally { mclsda.dbClose(); }
            }
            else { _jsonResponse = ""; }

            return _jsonResponse;
        }

        [WebMethod]
        public string Get_RequestLines_ForClosing(int _RequestID, int _UserID, string _Token)
        {
            List<RequestLines> uRequestLines = new List<RequestLines>();

            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("RequestID", _RequestID);
                    mclsda.AddParameter("UserID", _UserID);

                    using (DataTableReader dtr = mclsda.ExecuteReader("[RFS].[Get_RequestLines_ForClosing]", CommandType.StoredProcedure))
                    {
                        if (dtr.HasRows)
                        {
                            while (dtr.Read())
                            {
                                uRequestLines.Add(new RequestLines
                                {
                                    RequestLineID = dtr["RequestLineID"].ToString(),
                                    RequestLineNo = dtr["RequestLineNo"].ToString(),
                                    RequestID = dtr["RequestID"].ToString(),
                                    SubRequestFormNo = dtr["SubRequestFormNo"].ToString(),
                                    LineQuantity = Convert.ToDecimal(dtr["LineQuantity"].ToString()),
                                    UnitOfMeasurement = dtr["UnitOfMeasurement"].ToString(),
                                    ItemDescription = dtr["ItemDescription"].ToString(),
                                    PONo = dtr["PONo"].ToString(),
                                    COSNo = dtr["COSNo"].ToString(),
                                    ClosingRemarks = dtr["ClosingRemarks"].ToString()
                                });
                            }
                        }
                    }

                    _jsonResponse = jsonSerialiser.Serialize(uRequestLines);
                }
                catch (Exception) { _jsonResponse = ""; }
                finally { mclsda.dbClose(); }
            }
            else { _jsonResponse = ""; }

            return _jsonResponse;
        }

        #endregion

        #endregion

        #region Access Management

        [WebMethod]
        public string GetUserPass(string Username, string Password)
        {
            List<UserAccount> uAccount = new List<UserAccount>();

            try
            {
                mclsda.dbConnect();
                mclsda.ClearParameter();
                mclsda.AddParameter("Username", Username);
                mclsda.AddParameter("Password", Password);

                using (DataTableReader dtr = mclsda.ExecuteReader("[GEN].[User_Login]", CommandType.StoredProcedure))
                {
                    if (dtr.HasRows)
                    {
                        while (dtr.Read())
                        {
                            uAccount.Add(new UserAccount
                            {
                                UserID = Convert.ToInt32(dtr["UserID"].ToString()),
                                UserName = dtr["UserName"].ToString(),
                                Password = dtr["Password"].ToString(),
                                FirstName = dtr["FirstName"].ToString(),
                                LastName = dtr["LastName"].ToString(),
                                EmailAddress = dtr["EmailAddress"].ToString(),
                                GroupID = Convert.ToInt32(dtr["GroupID"].ToString()),
                                Office = dtr["Office"].ToString(),
                                Active = Convert.ToBoolean(dtr["Active"].ToString()),
                                DepartmentID = Convert.ToInt32(dtr["DepartmentID"].ToString()),
                                Token = "FzaXnRMR2345" + (_Cypher.Encrypt(dtr["UserName"].ToString(), _Cypher._PassPhrase + "FzaXnRMR2345"))
                            });
                        }
                    }
                }

                _jsonResponse = jsonSerialiser.Serialize(uAccount);
            }
            catch (Exception) { _jsonResponse = ""; }
            finally { mclsda.dbClose(); }

            return _jsonResponse;
        }

        [WebMethod]
        public string Get_UserAccessRights(int GroupID)
        {
            List<UserAccessRights> uUserAccessRights = new List<UserAccessRights>();

            try
            {
                mclsda.dbConnect();
                mclsda.ClearParameter();
                mclsda.AddParameter("GroupID", GroupID);

                using (DataTableReader dtr = mclsda.ExecuteReader("[GEN].[Get_UserAccessRights]", CommandType.StoredProcedure))
                {
                    if (dtr.HasRows)
                    {
                        while (dtr.Read())
                        {
                            uUserAccessRights.Add(new UserAccessRights
                            {
                                GroupRightID = Convert.ToInt32(dtr["GroupRightID"].ToString()),
                                GroupID = Convert.ToInt32(dtr["GroupID"].ToString()),
                                ModuleID = Convert.ToInt32(dtr["ModuleID"].ToString()),
                                CanView = Convert.ToBoolean(dtr["CanView"].ToString()),
                                CanEdit = Convert.ToBoolean(dtr["CanEdit"].ToString()),
                                CanDelete = Convert.ToBoolean(dtr["CanDelete"].ToString()),
                                ModuleName = dtr["ModuleName"].ToString()
                            });
                        }
                    }
                }

                _jsonResponse = jsonSerialiser.Serialize(uUserAccessRights);
            }
            catch (Exception) { _jsonResponse = ""; }
            finally { mclsda.dbClose(); }

            return _jsonResponse;
        }

        #endregion

        #region Account Management

        [WebMethod]
        public string Get_UserAccount(string _Parameter, int _UserID, string _Token)
        {
            List<UserAccount> uUserAccount = new List<UserAccount>();

            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("Parameter", _Parameter);

                    using (DataTableReader dtr = mclsda.ExecuteReader("[GEN].[Get_UserAccount]", CommandType.StoredProcedure))
                    {
                        if (dtr.HasRows)
                        {
                            while (dtr.Read())
                            {
                                uUserAccount.Add(new UserAccount
                                {
                                    UserID = Convert.ToInt32(dtr["UserID"].ToString()),
                                    UserName = dtr["UserName"].ToString(),
                                    Password = dtr["Password"].ToString(),
                                    FirstName = dtr["FirstName"].ToString(),
                                    LastName = dtr["LastName"].ToString(),
                                    GroupID = Convert.ToInt32(dtr["GroupID"].ToString()),
                                    GroupName = dtr["GroupName"].ToString(),
                                    EmailAddress = dtr["EmailAddress"].ToString(),
                                    DepartmentID = Convert.ToInt32(dtr["DepartmentID"].ToString()),
                                    DepartmentName = dtr["DepartmentName"].ToString(),
                                    Office = dtr["Office"].ToString(),
                                    Active = Convert.ToBoolean(dtr["Active"].ToString())
                                });
                            }
                        }
                    }

                    _jsonResponse = jsonSerialiser.Serialize(uUserAccount);
                }
                catch (Exception) { _jsonResponse = ""; }
                finally { mclsda.dbClose(); }
            }
            else { _jsonResponse = ""; }

            return _jsonResponse;
        }

        [WebMethod]
        public string Get_UserGroups(string _Parameter, int _UserID, string _Token)
        {
            List<UserGroup> uUserGroup = new List<UserGroup>();

            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("Parameter", _Parameter);

                    using (DataTableReader dtr = mclsda.ExecuteReader("[GEN].[Get_UserGroups]", CommandType.StoredProcedure))
                    {
                        if (dtr.HasRows)
                        {
                            while (dtr.Read())
                            {
                                uUserGroup.Add(new UserGroup
                                {
                                    GroupID = Convert.ToInt32(dtr["GroupID"].ToString()),
                                    GroupName = dtr["GroupName"].ToString(),
                                    GroupDescription = dtr["GroupDescription"].ToString(),
                                    Active = Convert.ToBoolean(dtr["Active"].ToString())
                                });
                            }
                        }
                    }

                    _jsonResponse = jsonSerialiser.Serialize(uUserGroup);
                }
                catch (Exception) { _jsonResponse = ""; }
                finally { mclsda.dbClose(); }
            }
            else { _jsonResponse = ""; }

            return _jsonResponse;
        }

        [WebMethod]
        public string Get_GroupRights(string _Parameter, int _UserID, string _Token)
        {
            List<GroupRights> uGroupRights = new List<GroupRights>();

            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("Parameter", _Parameter);

                    using (DataTableReader dtr = mclsda.ExecuteReader("[GEN].[Get_GroupRights]", CommandType.StoredProcedure))
                    {
                        if (dtr.HasRows)
                        {
                            while (dtr.Read())
                            {
                                uGroupRights.Add(new GroupRights
                                {
                                    GroupRightID = Convert.ToInt32(dtr["GroupRightID"].ToString()),
                                    GroupID = Convert.ToInt32(dtr["GroupID"].ToString()),
                                    ModuleID = Convert.ToInt32(dtr["ModuleID"].ToString()),
                                    ModuleName = dtr["ModuleName"].ToString(),
                                    CanView = Convert.ToBoolean(dtr["CanView"].ToString()),
                                    CanEdit = Convert.ToBoolean(dtr["CanEdit"].ToString()),
                                    CanDelete = Convert.ToBoolean(dtr["CanDelete"].ToString())
                                });
                            }
                        }
                    }

                    _jsonResponse = jsonSerialiser.Serialize(uGroupRights);
                }
                catch (Exception) { _jsonResponse = ""; }
                finally { mclsda.dbClose(); }
            }
            else { _jsonResponse = ""; }

            return _jsonResponse;
        }

        [WebMethod]
        public string Get_GroupRights_Requisition(string _Parameter, int _UserID, string _Token)
        {
            List<GroupRightsRequisition> uGroupRightsRequisition = new List<GroupRightsRequisition>();

            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("Parameter", _Parameter);

                    using (DataTableReader dtr = mclsda.ExecuteReader("[GEN].[Get_GroupRights_Requisition]", CommandType.StoredProcedure))
                    {
                        if (dtr.HasRows)
                        {
                            while (dtr.Read())
                            {
                                uGroupRightsRequisition.Add(new GroupRightsRequisition
                                {
                                    GroupRightRequestID = Convert.ToInt32(dtr["GroupRightRequestID"].ToString()),
                                    GroupID = Convert.ToInt32(dtr["GroupID"].ToString()),
                                    RequestProcessID = Convert.ToInt32(dtr["RequestProcessID"].ToString()),
                                    RequestProcessName = dtr["RequestProcessName"].ToString(),
                                    CanView = Convert.ToBoolean(dtr["CanView"].ToString()),
                                    CanEdit = Convert.ToBoolean(dtr["CanEdit"].ToString())
                                });
                            }
                        }
                    }

                    _jsonResponse = jsonSerialiser.Serialize(uGroupRightsRequisition);
                }
                catch (Exception) { _jsonResponse = ""; }
                finally { mclsda.dbClose(); }
            }
            else { _jsonResponse = ""; }

            return _jsonResponse;
        }

        #endregion

        #region Data Management

        [WebMethod]
        public string Get_Office(string _Parameter, int _UserID, string _Token)
        {
            List<Office> uOffice = new List<Office>();

            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("Parameter", _Parameter);

                    using (DataTableReader dtr = mclsda.ExecuteReader("[GEN].[Get_Office]", CommandType.StoredProcedure))
                    {
                        if (dtr.HasRows)
                        {
                            while (dtr.Read())
                            {
                                uOffice.Add(new Office
                                {
                                    OfficeID = Convert.ToInt32(dtr["OfficeID"].ToString()),
                                    OfficeCode = dtr["OfficeCode"].ToString(),
                                    OfficeName = dtr["OfficeName"].ToString(),
                                    Active = Convert.ToBoolean(dtr["Active"].ToString())
                                });
                            }
                        }
                    }

                    _jsonResponse = jsonSerialiser.Serialize(uOffice);
                }
                catch (Exception) { _jsonResponse = ""; }
                finally { mclsda.dbClose(); }
            }
            else { _jsonResponse = ""; }

            return _jsonResponse;
        }

        [WebMethod]
        public string Get_Departments(string _Parameter, int _UserID, string _Token)
        {
            List<Departments> uDepartments = new List<Departments>();

            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("Parameter", _Parameter);

                    using (DataTableReader dtr = mclsda.ExecuteReader("[GEN].[Get_Departments]", CommandType.StoredProcedure))
                    {
                        if (dtr.HasRows)
                        {
                            while (dtr.Read())
                            {
                                uDepartments.Add(new Departments
                                {
                                    DepartmentID = Convert.ToInt32(dtr["DepartmentID"].ToString()),
                                    DepartmentName = dtr["DepartmentName"].ToString(),

                                    ManilaApproverID1 = Convert.ToInt32(dtr["ManilaApproverID1"].ToString()),
                                    ManilaApproverID2 = Convert.ToInt32(dtr["ManilaApproverID2"].ToString()),
                                    GenSanApproverID1 = Convert.ToInt32(dtr["GenSanApproverID1"].ToString()),
                                    GenSanApproverID2 = Convert.ToInt32(dtr["GenSanApproverID2"].ToString()),

                                    ManilaFullName1 = dtr["ManilaFullName1"].ToString(),
                                    ManilaFullName2 = dtr["ManilaFullName2"].ToString(),
                                    GenSanFullName1 = dtr["GenSanFullName1"].ToString(),
                                    GenSanFullName2 = dtr["GenSanFullName2"].ToString()
                                });
                            }
                        }
                    }

                    _jsonResponse = jsonSerialiser.Serialize(uDepartments);
                }
                catch (Exception) { _jsonResponse = ""; }
                finally { mclsda.dbClose(); }
            }
            else { _jsonResponse = ""; }

            return _jsonResponse;
        }

        [WebMethod]
        public string Get_DepartmentApprover(string _Parameter, int _UserID, string _Token)
        {
            List<DepartmentApprover> uDepartmentApprover = new List<DepartmentApprover>();

            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("Parameter", _Parameter);

                    using (DataTableReader dtr = mclsda.ExecuteReader("[GEN].[Get_DepartmentApprover]", CommandType.StoredProcedure))
                    {
                        if (dtr.HasRows)
                        {
                            while (dtr.Read())
                            {
                                uDepartmentApprover.Add(new DepartmentApprover
                                {
                                    UserID = Convert.ToInt32(dtr["UserID"].ToString()),
                                    Name = dtr["Name"].ToString()
                                });
                            }
                        }
                    }

                    _jsonResponse = jsonSerialiser.Serialize(uDepartmentApprover);
                }
                catch (Exception) { _jsonResponse = ""; }
                finally { mclsda.dbClose(); }
            }
            else { _jsonResponse = ""; }

            return _jsonResponse;
        }

        [WebMethod]
        public string Get_Supplier(string _Parameter, int _UserID, string _Token)
        {
            List<Supplier> uSupplier = new List<Supplier>();

            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("Parameter", _Parameter);

                    using (DataTableReader dtr = mclsda.ExecuteReader("[GEN].[Get_Supplier]", CommandType.StoredProcedure))
                    {
                        if (dtr.HasRows)
                        {
                            while (dtr.Read())
                            {
                                uSupplier.Add(new Supplier
                                {
                                    SupplierID = Convert.ToInt32(dtr["SupplierID"].ToString()),
                                    SupplierName = dtr["SupplierName"].ToString(),
                                    ContactPerson = dtr["ContactPerson"].ToString(),
                                    ContactNumber = dtr["ContactNumber"].ToString(),
                                    CurrencyID = Convert.ToInt32(dtr["CurrencyID"].ToString()),
                                    CurrencyName = dtr["CurrencyName"].ToString(),
                                    Terms = dtr["Terms"].ToString(),
                                    ModeOfPayment = dtr["ModeOfPayment"].ToString()
                                });
                            }
                        }
                    }

                    _jsonResponse = jsonSerialiser.Serialize(uSupplier);
                }
                catch (Exception) { _jsonResponse = ""; }
                finally { mclsda.dbClose(); }
            }
            else { _jsonResponse = ""; }

            return _jsonResponse;
        }

        [WebMethod]
        public string Get_Currency(string _Parameter, int _UserID, string _Token)
        {
            List<Currency> uCurrency = new List<Currency>();

            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("Parameter", _Parameter);

                    using (DataTableReader dtr = mclsda.ExecuteReader("[GEN].[Get_CurrencyList]", CommandType.StoredProcedure))
                    {
                        if (dtr.HasRows)
                        {
                            while (dtr.Read())
                            {
                                uCurrency.Add(new Currency
                                {
                                    CurrencyID = Convert.ToInt32(dtr["CurrencyID"].ToString()),
                                    CurrencyCode = dtr["CurrencyCode"].ToString(),
                                    CurrencyName = dtr["CurrencyName"].ToString(),
                                    CurrencyCodeName = dtr["CurrencyCodeName"].ToString()
                                });
                            }
                        }
                    }

                    _jsonResponse = jsonSerialiser.Serialize(uCurrency);
                }
                catch (Exception) { _jsonResponse = ""; }
                finally { mclsda.dbClose(); }
            }
            else { _jsonResponse = ""; }

            return _jsonResponse;
        }

        [WebMethod]
        public string Get_PaymentMode(string _Parameter, int _UserID, string _Token)
        {
            List<PaymentMode> uPaymentMode = new List<PaymentMode>();

            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("Parameter", _Parameter);

                    using (DataTableReader dtr = mclsda.ExecuteReader("[GEN].[Get_PaymentMode]", CommandType.StoredProcedure))
                    {
                        if (dtr.HasRows)
                        {
                            while (dtr.Read())
                            {
                                uPaymentMode.Add(new PaymentMode
                                {
                                    PaymentModeID = Convert.ToInt32(dtr["PaymentModeID"].ToString()),
                                    PaymentModeCode = dtr["PaymentModeCode"].ToString(),
                                    PaymentModes = dtr["PaymentMode"].ToString()
                                });
                            }
                        }
                    }

                    _jsonResponse = jsonSerialiser.Serialize(uPaymentMode);
                }
                catch (Exception) { _jsonResponse = ""; }
                finally { mclsda.dbClose(); }
            }
            else { _jsonResponse = ""; }

            return _jsonResponse;
        }

        [WebMethod]
        public string Get_PaymentTerm(string _Parameter, int _UserID, string _Token)
        {
            List<PaymentTerm> uPaymentTerm = new List<PaymentTerm>();

            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("Parameter", _Parameter);

                    using (DataTableReader dtr = mclsda.ExecuteReader("[GEN].[Get_PaymentTerm]", CommandType.StoredProcedure))
                    {
                        if (dtr.HasRows)
                        {
                            while (dtr.Read())
                            {
                                uPaymentTerm.Add(new PaymentTerm
                                {
                                    PaymentTermID = Convert.ToInt32(dtr["PaymentTermID"].ToString()),
                                    PaymentTermsCode = dtr["PaymentTermsCode"].ToString(),
                                    PaymentTerms = dtr["PaymentTerm"].ToString()
                                });
                            }
                        }
                    }

                    _jsonResponse = jsonSerialiser.Serialize(uPaymentTerm);
                }
                catch (Exception) { _jsonResponse = ""; }
                finally { mclsda.dbClose(); }
            }
            else { _jsonResponse = ""; }

            return _jsonResponse;
        }

        [WebMethod]
        public string Get_VesselDepartment(string _Parameter, int _UserID, string _Token)
        {
            List<VesselDept> uVesselDept = new List<VesselDept>();

            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("Parameter", _Parameter);

                    using (DataTableReader dtr = mclsda.ExecuteReader("[GEN].[Get_VesselDepartment]", CommandType.StoredProcedure))
                    {
                        if (dtr.HasRows)
                        {
                            while (dtr.Read())
                            {
                                uVesselDept.Add(new VesselDept
                                {
                                    VesselID = Convert.ToInt32(dtr["VesselID"].ToString()),
                                    VesselCode = dtr["VesselCode"].ToString(),
                                    VesselName = dtr["VesselName"].ToString(),
                                    VesselTypeID = Convert.ToInt32(dtr["VesselTypeID"].ToString()),
                                    VesselType = dtr["VesselType"].ToString(),
                                    FlagID = Convert.ToInt32(dtr["FlagID"].ToString()),
                                    FlagName = dtr["FlagName"].ToString(),
                                    Active = Convert.ToBoolean(dtr["Active"].ToString())
                                });
                            }
                        }
                    }

                    _jsonResponse = jsonSerialiser.Serialize(uVesselDept);
                }
                catch (Exception) { _jsonResponse = ""; }
                finally { mclsda.dbClose(); }
            }
            else { _jsonResponse = ""; }

            return _jsonResponse;
        }

        [WebMethod]
        public string Get_VesselType(string _Parameter, int _UserID, string _Token)
        {
            List<VesselType> uVesselType = new List<VesselType>();

            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("Parameter", _Parameter);

                    using (DataTableReader dtr = mclsda.ExecuteReader("[GEN].[Get_VesselType]", CommandType.StoredProcedure))
                    {
                        if (dtr.HasRows)
                        {
                            while (dtr.Read())
                            {
                                uVesselType.Add(new VesselType
                                {
                                    VesselTypeID = Convert.ToInt32(dtr["VesselTypeID"].ToString()),
                                    VesselTypes = dtr["VesselTypes"].ToString(), 
                                });
                            }
                        }
                    }

                    _jsonResponse = jsonSerialiser.Serialize(uVesselType);
                }
                catch (Exception) { _jsonResponse = ""; }
                finally { mclsda.dbClose(); }
            }
            else { _jsonResponse = ""; }

            return _jsonResponse;
        }

        [WebMethod]
        public string Get_FlagRegistration(string _Parameter, int _UserID, string _Token)
        {
            List<FlagRegistration> uFlagRegistration = new List<FlagRegistration>();

            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("Parameter", _Parameter);

                    using (DataTableReader dtr = mclsda.ExecuteReader("[GEN].[Get_FlagRegistration]", CommandType.StoredProcedure))
                    {
                        if (dtr.HasRows)
                        {
                            while (dtr.Read())
                            {
                                uFlagRegistration.Add(new FlagRegistration
                                {
                                    FlagID = Convert.ToInt32(dtr["FlagID"].ToString()),
                                    FlagName = dtr["FlagName"].ToString(), 
                                });
                            }
                        }
                    }

                    _jsonResponse = jsonSerialiser.Serialize(uFlagRegistration);
                }
                catch (Exception) { _jsonResponse = ""; }
                finally { mclsda.dbClose(); }
            }
            else { _jsonResponse = ""; }

            return _jsonResponse;
        }

        [WebMethod]
        public string Get_PageModules(string _Parameter, int _UserID, string _Token)
        {
            List<PageModules> uPageModules = new List<PageModules>();

            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("Parameter", _Parameter);

                    using (DataTableReader dtr = mclsda.ExecuteReader("[GEN].[Get_PageModules]", CommandType.StoredProcedure))
                    {
                        if (dtr.HasRows)
                        {
                            while (dtr.Read())
                            {
                                uPageModules.Add(new PageModules
                                {
                                    ModuleID = Convert.ToInt32(dtr["ModuleID"].ToString()),
                                    ModuleName = dtr["ModuleName"].ToString(),
                                    ModuleDescription = dtr["ModuleDescription"].ToString(),
                                    ModuleURL = dtr["ModuleURL"].ToString()
                                });
                            }
                        }
                    }

                    _jsonResponse = jsonSerialiser.Serialize(uPageModules);
                }
                catch (Exception) { _jsonResponse = ""; }
                finally { mclsda.dbClose(); }
            }
            else { _jsonResponse = ""; }

            return _jsonResponse;
        }
        
        #endregion

        #endregion

        #region Save Data

        #region Request Form

        #region Request Header

        [WebMethod]
        public void Save_RequestHeader(int RequestID, string RequestStatus, int VesselID, string RequestDate, string DateNeeded, string ItemFor, string Notify, string DeliverTo, string Remarks, int _UserID, string _Token)
        {
            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("RequestID", RequestID);
                    mclsda.AddParameter("RequestStatus", RequestStatus);
                    mclsda.AddParameter("VesselID", VesselID);
                    mclsda.AddParameter("RequestDate", RequestDate);
                    mclsda.AddParameter("DateNeeded", DateNeeded);
                    mclsda.AddParameter("ItemFor", ItemFor);
                    mclsda.AddParameter("Notify", Notify);
                    mclsda.AddParameter("DeliverTo", DeliverTo);
                    mclsda.AddParameter("Remarks", Remarks);
                    mclsda.AddParameter("UserID", _UserID);

                    mclsda.ExecuteNonQuery("[RFS].[Save_RequestHeader]", CommandType.StoredProcedure);

                }
                catch (Exception ex) { throw ex; }
                finally { mclsda.dbClose(); }
            }
        }

        #endregion

        #endregion

        #region Account Management

        [WebMethod]
        public void Save_UserAccounts(int UserID, string UserName, string Password, string FirstName, string LastName, int GroupID, string EmailAddress, string Office, int DepartmentID, bool Active, int _UserID, string _Token)
        {
            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("UserID", UserID);
                    mclsda.AddParameter("UserName", UserName);
                    mclsda.AddParameter("Password", Password);
                    mclsda.AddParameter("FirstName", FirstName);
                    mclsda.AddParameter("LastName", LastName);
                    mclsda.AddParameter("GroupID", GroupID);
                    mclsda.AddParameter("EmailAddress", EmailAddress);
                    mclsda.AddParameter("Office", Office);
                    mclsda.AddParameter("DepartmentID", DepartmentID);
                    mclsda.AddParameter("Active", Active);

                    mclsda.ExecuteNonQuery("[GEN].[Save_UserAccounts]", CommandType.StoredProcedure);

                }
                catch (Exception ex) { throw ex; }
                finally { mclsda.dbClose(); }
            }
        }

        [WebMethod]
        public void Save_UserGroups(int ID, string GroupName, string Description, bool Active, int _UserID, string _Token)
        {
            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("ID", ID);
                    mclsda.AddParameter("GroupName", GroupName);
                    mclsda.AddParameter("Description", Description);
                    mclsda.AddParameter("Active", Active);

                    mclsda.ExecuteNonQuery("[GEN].[Save_UserGroups]", CommandType.StoredProcedure);
                }
                catch (Exception ex) { throw ex; }
                finally { mclsda.dbClose(); }
            }
        }

        [WebMethod]
        public void Save_GroupRights(int GroupRightID, int GroupID, int ModuleID, bool CanView, bool CanEdit, bool CanDelete, int _UserID, string _Token)
        {
            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("GroupRightID", GroupRightID);
                    mclsda.AddParameter("GroupID", GroupID);
                    mclsda.AddParameter("ModuleID", ModuleID);
                    mclsda.AddParameter("CanView", CanView);
                    mclsda.AddParameter("CanEdit", CanEdit);
                    mclsda.AddParameter("CanDelete", CanDelete);

                    mclsda.ExecuteNonQuery("[GEN].[Save_GroupRights]", CommandType.StoredProcedure);
                }
                catch (Exception ex) { throw ex; }
                finally { mclsda.dbClose(); }
            }
        }

        [WebMethod]
        public void Save_GroupRights_Requisition(int GroupRightRequestID, int GroupID, int RequestProcessID, bool CanView, bool CanEdit, int _UserID, string _Token)
        {
            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("GroupRightRequestID", GroupRightRequestID);
                    mclsda.AddParameter("GroupID", GroupID);
                    mclsda.AddParameter("RequestProcessID", RequestProcessID);
                    mclsda.AddParameter("CanView", CanView);
                    mclsda.AddParameter("CanEdit", CanEdit);

                    mclsda.ExecuteNonQuery("[GEN].[Save_GroupRights_Requisition]", CommandType.StoredProcedure);
                }
                catch (Exception ex) { throw ex; }
                finally { mclsda.dbClose(); }
            }
        }
        
        #endregion

        #region Data Management

        [WebMethod]
        public void Save_Department(int DepartmentID, string DepartmentName, int ManilaApproverID1, int ManilaApproverID2, int GenSanApproverID1,int GenSanApproverID2, int _UserID, string _Token)
        {
            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("DepartmentID", DepartmentID);
                    mclsda.AddParameter("DepartmentName", DepartmentName);
                    mclsda.AddParameter("ManilaApproverID1", ManilaApproverID1);
                    mclsda.AddParameter("ManilaApproverID2", ManilaApproverID2);
                    mclsda.AddParameter("GenSanApproverID1", GenSanApproverID1);
                    mclsda.AddParameter("GenSanApproverID2", GenSanApproverID2);

                    mclsda.ExecuteNonQuery("[GEN].[Save_Department]", CommandType.StoredProcedure);
                }
                catch (Exception ex) { throw ex; }
                finally { mclsda.dbClose(); }
            }
        }

        [WebMethod]
        public void Save_Currency(int CurrencyID, string CurrencyCode, string CurrencyName, int _UserID, string _Token)
        {
            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("CurrencyID", CurrencyID);
                    mclsda.AddParameter("CurrencyCode", CurrencyCode);
                    mclsda.AddParameter("CurrencyName", CurrencyName);

                    mclsda.ExecuteNonQuery("[GEN].[Save_Currency]", CommandType.StoredProcedure);
                }
                catch (Exception ex) { throw ex; }
                finally { mclsda.dbClose(); }
            }
        }

        [WebMethod]
        public void Save_Supplier(int SupplierID, string SupplierName, string ContactPerson, string ContactNumber, int CurrencyID, string PaymentTerms, string ModeOfPayment, int _UserID, string _Token)
        {
            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("SupplierID", SupplierID);
                    mclsda.AddParameter("SupplierName", SupplierName);
                    mclsda.AddParameter("ContactPerson", ContactPerson);
                    mclsda.AddParameter("ContactNumber", ContactNumber);
                    mclsda.AddParameter("CurrencyID", CurrencyID);
                    mclsda.AddParameter("Terms", PaymentTerms);
                    mclsda.AddParameter("ModeOfPayment", ModeOfPayment);

                    mclsda.ExecuteNonQuery("[GEN].[Save_Supplier]", CommandType.StoredProcedure);
                }
                catch (Exception ex) { throw ex; }
                finally { mclsda.dbClose(); }
            }
        }

        [WebMethod]
        public void Save_VesselDepartment(int VesselID, string VesselCode, string VesselName, string VesselType, string FlagRegistration, bool Active, int _UserID, string _Token)
        {
            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("VesselID", VesselID);
                    mclsda.AddParameter("VesselCode", VesselCode);
                    mclsda.AddParameter("VesselName", VesselName);
                    mclsda.AddParameter("VesselType", VesselType);
                    mclsda.AddParameter("FlagRegistration", FlagRegistration);
                    mclsda.AddParameter("Active", Active);

                    mclsda.ExecuteNonQuery("[GEN].[Save_VesselDepartment]", CommandType.StoredProcedure);
                }
                catch (Exception ex) { throw ex; }
                finally { mclsda.dbClose(); }
            }
        }

        [WebMethod]
        public void Save_FlagRegistration(int FlagID, string FlagName, int _UserID, string _Token)
        {
            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("FlagID", FlagID);
                    mclsda.AddParameter("FlagName", FlagName);

                    mclsda.ExecuteNonQuery("[GEN].[Save_FlagRegistration]", CommandType.StoredProcedure);
                }
                catch (Exception ex) { throw ex; }
                finally { mclsda.dbClose(); }
            }
        }

        [WebMethod]
        public void Save_Office(int OfficeID, string OfficeCode, string OfficeName, bool Active, int _UserID, string _Token)
        {
            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("OfficeID", OfficeID);
                    mclsda.AddParameter("OfficeCode", OfficeCode);
                    mclsda.AddParameter("OfficeName", OfficeName);
                    mclsda.AddParameter("Active", Active);

                    mclsda.ExecuteNonQuery("[GEN].[Save_Office]", CommandType.StoredProcedure);
                }
                catch (Exception ex) { throw ex; }
                finally { mclsda.dbClose(); }
            }
        }

        [WebMethod]
        public void Save_PageModules(int ModuleID, string ModuleName, string ModuleDescription, string ModuleURL, int _UserID, string _Token)
        {
            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("ModuleID", ModuleID);
                    mclsda.AddParameter("ModuleName", ModuleName);
                    mclsda.AddParameter("ModuleDescription", ModuleDescription);
                    mclsda.AddParameter("ModuleURL", ModuleURL);

                    mclsda.ExecuteNonQuery("[GEN].[Save_PageModules]", CommandType.StoredProcedure);
                }
                catch (Exception ex) { throw ex; }
                finally { mclsda.dbClose(); }
            }
        }

        [WebMethod]
        public void Save_PaymentMode(int PaymentModeID, string PaymentModeCode, string PaymentMode, int _UserID, string _Token)
        {
            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("PaymentModeID", PaymentModeID);
                    mclsda.AddParameter("PaymentModeCode", PaymentModeCode);
                    mclsda.AddParameter("PaymentMode", PaymentMode);

                    mclsda.ExecuteNonQuery("[GEN].[Save_PaymentMode]", CommandType.StoredProcedure);
                }
                catch (Exception ex) { throw ex; }
                finally { mclsda.dbClose(); }
            }
        }

        [WebMethod]
        public void Save_PaymentTerms(int PaymentTermID, string PaymentTermsCode, string PaymentTerm, int _UserID, string _Token)
        {
            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("PaymentTermID", PaymentTermID);
                    mclsda.AddParameter("PaymentTermsCode", PaymentTermsCode);
                    mclsda.AddParameter("PaymentTerm", PaymentTerm);

                    mclsda.ExecuteNonQuery("[GEN].[Save_PaymentTerm]", CommandType.StoredProcedure);
                }
                catch (Exception ex) { throw ex; }
                finally { mclsda.dbClose(); }
            }
        }

        [WebMethod]
        public void Save_VesselType(int VesselTypeID, string VesselType, int _UserID, string _Token)
        {
            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("VesselTypeID", VesselTypeID);
                    mclsda.AddParameter("VesselType", VesselType);

                    mclsda.ExecuteNonQuery("[GEN].[Save_VesselType]", CommandType.StoredProcedure);
                }
                catch (Exception ex) { throw ex; }
                finally { mclsda.dbClose(); }
            }
        }
        
        #endregion

        #endregion

        #region Transaction Management

        [WebMethod]
        public bool Validate_Token(int UserID, string TokenID)
        {
            bool _ValidateToken = false;

            try
            {
                //Get _userToken and EncryptedString
                int _strCount = TokenID.Length;
                string _userToken = TokenID.Substring(0, 12);
                string _eString = TokenID.Substring(12, (_strCount - 12));
                string _uNM = _Cypher.Decrypt(_eString, _Cypher._PassPhrase + _userToken);

                mclsda.dbConnect();
                mclsda.ClearParameter();
                mclsda.AddParameter("UserID", UserID);

                using (DataTableReader dtr = mclsda.ExecuteReader("[GEN].[Get_Token]", CommandType.StoredProcedure))
                {
                    if (dtr.HasRows)
                    {
                        while (dtr.Read())
                        {
                            if (dtr["UserName"].ToString() == _uNM) { _ValidateToken = true; }
                            else { _ValidateToken = false; }
                        }
                    }
                    else { _ValidateToken = false; }
                }
            }
            catch (Exception) { _ValidateToken = false; }
            finally { mclsda.dbClose(); }

            return _ValidateToken;
        }

        [WebMethod]
        public void Save_TransactionLogs(int UserID, string FormName, string EventName, string ExceptionError, string ComputerName, string IPAddress)
        {
            try
            {
                mclsda.dbConnect();
                mclsda.ClearParameter();
                mclsda.AddParameter("UserID", UserID);
                mclsda.AddParameter("FormName", FormName);
                mclsda.AddParameter("EventName", EventName);
                mclsda.AddParameter("ExceptionError", ExceptionError);
                mclsda.AddParameter("ComputerName", ComputerName);
                mclsda.AddParameter("IPAddress", IPAddress);

                mclsda.ExecuteQuery("[GEN].[Save_TransactionLogs]", CommandType.StoredProcedure);
            }
            catch (Exception) { }
            finally { mclsda.dbClose(); }
        }

        [WebMethod]
        public void Trails_UserTrails(int UserID, int RequestID, int RequestLineID, string TransType)
        {
            try
            {
                mclsda.dbConnect();
                mclsda.ClearParameter();
                mclsda.AddParameter("UserID", UserID);
                mclsda.AddParameter("RequestID", RequestID);
                mclsda.AddParameter("RequestLineID", RequestLineID);
                mclsda.AddParameter("TransType", TransType);

                mclsda.ExecuteNonQuery("[GEN].[Trails_UserTransactions]", CommandType.StoredProcedure);
            }
            catch (Exception ex) { throw ex; }
            finally { mclsda.dbClose(); }
        }

        [WebMethod]
        public string Get_UserTrails(string RequestID, int _UserID, string _Token)
        {
            List<UserTrails> uUserTrails = new List<UserTrails>();

            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("RequestID", RequestID);

                    using (DataTableReader dtr = mclsda.ExecuteReader("[GEN].[Get_UserTrails]", CommandType.StoredProcedure))
                    {
                        if (dtr.HasRows)
                        {
                            while (dtr.Read())
                            {
                                uUserTrails.Add(new UserTrails
                                {
                                    UserTrailID = Convert.ToInt32(dtr["UserTrailID"].ToString()),
                                    UserID = Convert.ToInt32(dtr["UserID"].ToString()),
                                    UserName = dtr["UserName"].ToString(),
                                    RequestID = Convert.ToInt32(dtr["RequestID"].ToString()),
                                    RequestLineID = dtr["RequestLineID"].ToString(),
                                    ItemDescription = dtr["ItemDescription"].ToString(),
                                    TransType = dtr["TransType"].ToString(),
                                    TransDateTime = dtr["TransDateTime"].ToString()
                                });
                            }
                        }
                    }

                    _jsonResponse = jsonSerialiser.Serialize(uUserTrails);
                }
                catch (Exception) { _jsonResponse = ""; }
                finally { mclsda.dbClose(); }
            }
            else { _jsonResponse = ""; }

            return _jsonResponse;
        }

        [WebMethod]
        public string Get_TransactionLogs(string _Parameter, int _UserID, string _Token)
        {
            List<TransactionLogs> uTransactionLogs = new List<TransactionLogs>();

            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("Parameter", _Parameter);

                    using (DataTableReader dtr = mclsda.ExecuteReader("[GEN].[Get_TransactionLogs]", CommandType.StoredProcedure))
                    {
                        if (dtr.HasRows)
                        {
                            while (dtr.Read())
                            {
                                uTransactionLogs.Add(new TransactionLogs
                                {
                                    ID = Convert.ToInt32(dtr["ID"].ToString()),
                                    UserID = Convert.ToInt32(dtr["UserID"].ToString()),
                                    UserName = dtr["UserName"].ToString(),
                                    FormName = dtr["FormName"].ToString(),
                                    EventName = dtr["EventName"].ToString(),
                                    ExceptionError = dtr["ExceptionError"].ToString(),
                                    ComputerName = dtr["ComputerName"].ToString(),
                                    IPAddress = dtr["IPAddress"].ToString(),
                                    DateTimeLogs = dtr["DateTimeLogs"].ToString()
                                });
                            }
                        }
                    }

                    _jsonResponse = jsonSerialiser.Serialize(uTransactionLogs);
                }
                catch (Exception) { _jsonResponse = ""; }
                finally { mclsda.dbClose(); }
            }
            else { _jsonResponse = ""; }

            return _jsonResponse;
        }

        #endregion
    }
}
