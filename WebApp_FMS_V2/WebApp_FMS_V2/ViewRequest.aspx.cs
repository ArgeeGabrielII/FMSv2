using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp_FMS_V2.wcfFMSv2;

namespace WebApp_FMS_V2
{
    public partial class ViewRequest : System.Web.UI.Page
    {
        FMSV2Client wcfService = new FMSV2Client();
        _gControls _gc = new _gControls();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    //Load GridView - TEMPORARY LOADING
                    _gc.DeserializeDataTable(wcfService.Get_ViewAllRequest("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase))
                        , (string)Session["tID"]), gvViewRequest_ViewAllRequests);
                    _gc.DeserializeDataTable(wcfService.Get_DraftRequests("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase))
                        , (string)Session["tID"]), gvViewRequest_DraftRequest);

                    liAllRequest.Attributes.Add("class", "active"); 

                    //Temporary Static Group Rights for View Request
                    _GroupRights();
                }
                else { }
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionLogs(_UID, "ViewRequest", "Page_Load", ex.ToString(), _gc.localComputerName, _gc.GetIPAddress());
                Response.Redirect("Login");
            }
        }

        #region Events

        protected void btnViewRequisition_CreateRequest_Click(object sender, EventArgs e)
        {
            ResponseRedirect_RequestForm("0", "CreateNew", "0", Session["tID"].ToString());
        }

        #region View All Requests

        protected void lnkViewRequest_ViewAllRequest_Search_Click(object sender, EventArgs e)
        {
            if (txtViewRequest_ViewAllRequest_Search.Text != "")
            {
                _gc.DeserializeDataTable(wcfService.Get_ViewAllRequest(txtViewRequest_ViewAllRequest_Search.Text, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase))
                    , (string)Session["tID"]), gvViewRequest_ViewAllRequests);
            }
        }

        protected void gvViewRequest_ViewAllRequests_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnkVerify = ((LinkButton)e.Row.FindControl("lnkVerify"));
                LinkButton lnkAudit = ((LinkButton)e.Row.FindControl("lnkAudit"));
                LinkButton lnkClose = ((LinkButton)e.Row.FindControl("lnkClose"));

                if (e.Row.Cells[6].Text == "Delivered" || e.Row.Cells[6].Text == "Completed" || e.Row.Cells[6].Text == "Served")
                {
                    e.Row.BackColor = System.Drawing.Color.Green;
                    e.Row.ForeColor = System.Drawing.Color.White;
                    lnkVerify.Visible = true;
                    lnkAudit.Visible = true;
                    lnkClose.Visible = false;
                }
                else if (e.Row.Cells[6].Text == "Partially Served")
                {
                    e.Row.BackColor = System.Drawing.Color.PaleGreen;
                    lnkVerify.Visible = true;
                    lnkAudit.Visible = true;
                    lnkClose.Visible = true;
                }
                else if (e.Row.Cells[6].Text == "For Approval")
                {
                    e.Row.BackColor = System.Drawing.Color.LightSalmon;
                    lnkVerify.Visible = false;
                    lnkAudit.Visible = false;
                    lnkClose.Visible = false;
                }
                else if (e.Row.Cells[6].Text == "For Warehouse Checking")
                {
                    e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFD7D");
                    lnkVerify.Visible = true;
                    lnkAudit.Visible = true;
                    lnkClose.Visible = true;
                }
                else if (e.Row.Cells[6].Text == "For Canvassing")
                {
                    e.Row.BackColor = System.Drawing.Color.PaleTurquoise;
                    lnkVerify.Visible = false;
                    lnkAudit.Visible = false;
                    lnkClose.Visible = true;
                }
                else if (e.Row.Cells[6].Text == "For Delivery" || e.Row.Cells[6].Text == "For Partial Delivery")
                {
                    e.Row.BackColor = System.Drawing.Color.Orange;
                    lnkVerify.Visible = true;
                    lnkAudit.Visible = true;
                    lnkClose.Visible = true;
                }
                else if (e.Row.Cells[6].Text == "Cancelled" || e.Row.Cells[6].Text == "Disapproved")
                {
                    e.Row.BackColor = System.Drawing.Color.Gray;
                    e.Row.ForeColor = System.Drawing.Color.White;
                    lnkVerify.Visible = false;
                    lnkAudit.Visible = false;
                    lnkClose.Visible = false;
                }
                else
                {
                    lnkVerify.Visible = false;
                    lnkAudit.Visible = false;
                    lnkClose.Visible = false;
                }
            }
        }

        protected void gvViewRequest_ViewAllRequests_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvViewRequest_ViewAllRequests.PageIndex = e.NewPageIndex;
            _gc.DeserializeDataTable(wcfService.Get_ViewAllRequest("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase))
                , (string)Session["tID"]), gvViewRequest_ViewAllRequests);
        }

        protected void gvViewRequest_ViewAllRequests_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvViewRequest_ViewAllRequests.SelectedRow;
            ResponseRedirect_RequestForm(row.Cells[0].Text, row.Cells[6].Text, "0", Session["tID"].ToString());
        }

        protected void gvViewRequest_ViewAllRequests_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int rowindex = Convert.ToInt32(e.CommandArgument) % gvViewRequest_ViewAllRequests.PageSize;
                GridViewRow row = gvViewRequest_ViewAllRequests.Rows[rowindex];

                if (e.CommandName == "Verify")
                {
                    lblAllRequest_Verify_Header.Text = "Verify";
                    lblAllRequest_Verify_RequisitionNo.Text = "Requsition No: " + row.Cells[0].Text;
                    lblAllRequest_Verify_VesselName.Text = "Vessel Name: " + row.Cells[5].Text;

                    _gc.DeserializeDataTable(wcfService.Get_RequestLines_ForVerify(_gc.ToInt32(row.Cells[0].Text), _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase))
                        , (string)Session["tID"]), gvAllRequest_Verify);

                    modalAllRequest_Verify.Attributes.Add("class", "modal displayShow");
                }
                else if (e.CommandName == "Audit")
                {
                    lblAllRequest_Audit_Header.Text = "Audit";
                    lblAllRequest_Audit_RequisitionNo.Text = "Requsition No: " + row.Cells[0].Text;
                    lblAllRequest_Audit_VesselName.Text = "Vessel Name: " + row.Cells[5].Text;

                    _gc.DeserializeDataTable(wcfService.Get_RequestLines_ForAudit(_gc.ToInt32(row.Cells[0].Text), _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase))
                        , (string)Session["tID"]), gvAllRequest_Audit);

                    modalAllRequest_Audit.Attributes.Add("class", "modal displayShow");
                }
                else if (e.CommandName == "Close")
                {
                    lblAllRequest_Close_Header.Text = "Close";
                    lblAllRequest_Close_RequesitionNo.Text = "Requisition No: " + row.Cells[0].Text;
                    lblAllRequest_Close_VesselName.Text = "Vessel Name: " + row.Cells[5].Text;

                    _gc.DeserializeDataTable(wcfService.Get_RequestLines_ForClosing(_gc.ToInt32(row.Cells[0].Text), _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase))
                        , (string)Session["tID"]), gvAllRequest_Close);

                    modalAllRequest_Close.Attributes.Add("class", "modal displayShow");
                }
                else { }
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionLogs(_UID, "ViewAllRequest", "gvViewRequest_ViewAllRequests_RowCommand", ex.ToString(), _gc.localComputerName, _gc.GetIPAddress());
            }
        }

        #endregion

        #region View All Request - Verify

        protected void btnAllRequest_Verify_Save_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow row in gvAllRequest_Verify.Rows)
                {
                    CheckBox chk = row.Cells[1].FindControl("chkSelectLine") as CheckBox;
                    TextBox txtRemarks = row.Cells[13].FindControl("txtVerifyRemarks") as TextBox;

                    if (chk != null && chk.Checked)
                    {
                        //wcfSrvc.Save_RequestLines_Verify(Convert.ToInt32(row.Cells[0].Text), txtRemarks.Text, Convert.ToInt32(Session["UserID"].ToString()));
                        //wcfService.Trails_UserTrails
                    }
                }
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionLogs(_UID, "ViewRequest-Verify", "btnAllRequest_Verify_Save_Click", ex.ToString(), _gc.localComputerName, _gc.GetIPAddress());
                Response.Redirect("Login");
            }
        }

        protected void btnAllRequest_Verify_No_Click(object sender, EventArgs e)
        {
            modalAllRequest_Verify.Attributes.Add("class", "modal displayHide");
        }
        
        #endregion

        #region View All Request - Audit

        protected void btnAllRequest_Audit_Save_Click(object sender, EventArgs e)
        {

        }

        protected void btnAllRequest_Audit_No_Click(object sender, EventArgs e)
        {
            modalAllRequest_Audit.Attributes.Add("class", "modal displayHide");
        }
        
        #endregion

        #region View All Request - Close

        protected void btnAllRequest_Close_Save_Click(object sender, EventArgs e)
        {

        }

        protected void btnAllRequest_Close_No_Click(object sender, EventArgs e)
        {
            modalAllRequest_Close.Attributes.Add("class", "modal displayHide");
        }
        
        #endregion

        #region Draft Request

        protected void lnkViewRequest_DraftRequest_Search_Click(object sender, EventArgs e)
        {

        }

        protected void gvViewRequest_DraftRequest_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gvViewRequest_DraftRequest_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvViewRequest_DraftRequest_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvViewRequest_DraftRequest.SelectedRow;
            ResponseRedirect_RequestForm(row.Cells[0].Text, "Draft", "0", Session["tID"].ToString());
        }

        protected void gvViewRequest_DraftRequest_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int rowindex = Convert.ToInt32(e.CommandArgument) % gvViewRequest_DraftRequest.PageSize;
                GridViewRow row = gvViewRequest_DraftRequest.Rows[rowindex];

                if (e.CommandName == "Delete")
                {
                    lblAllRequest_Close_Header.Text = "Delete Draft Request";
                    lblAllRequest_Close_RequesitionNo.Text = "Requisition No: " + row.Cells[0].Text;
                    lblAllRequest_Close_VesselName.Text = "Vessel Name: " + row.Cells[5].Text;

                    _gc.DeserializeDataTable(wcfService.Get_RequestLines_ForClosing(_gc.ToInt32(row.Cells[0].Text), _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase))
                        , (string)Session["tID"]), gvAllRequest_Close);

                    modalAllRequest_Close.Attributes.Add("class", "modal displayShow");
                }
                else { }
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionLogs(_UID, "DraftRequest", "gvViewRequest_DraftRequest_RowCommand", ex.ToString(), _gc.localComputerName, _gc.GetIPAddress());
            }
        }
        
        #endregion

        #endregion

        #region Properties

        private void _GroupRights()
        {
            string _GID = _Cypher.Decrypt(Session["GroupID"].ToString(), _Cypher._PassPhrase);

            if (_GID == "1") { RFTabs(true, true, true, false, false, false, false, false, false, false, false, false); }
            else if (_GID == "2") { RFTabs(true, false, false, false, false, false, false, false, false, false, false, false); }
            else if (_GID == "3") { RFTabs(true, false, false, false, false, false, false, false, false, false, false, false); }
            else if (_GID == "4") { RFTabs(true, false, false, true, false, true, false, false, false, false, false, false); }
            else if (_GID == "5") { RFTabs(true, false, false, true, false, false, true, true, true, true, true, true); }
            else if (_GID == "6") { RFTabs(true, false, false, true, false, true, false, false, false, false, false, false); }
            else if (_GID == "7") { RFTabs(true, false, false, true, false, true, false, false, false, false, false, false); }
            else if (_GID == "8") { RFTabs(true, true, true, true, true, true, true, false, false, false, true, false); }
            else if (_GID == "9") { RFTabs(true, true, true, true, true, true, true, false, false, false, true, false); }
            else if (_GID == "10") { RFTabs(true, true, true, true, true, true, true, false, false, false, true, false); }
            else if (_GID == "11") { RFTabs(true, true, true, true, true, true, true, false, false, false, true, false); }
            else if (_GID == "12") { RFTabs(true, true, true, true, true, true, false, true, true, true, false, false); }
            else if (_GID == "13") { RFTabs(true, true, true, true, true, true, true, true, true, true, true, true); }
            else if (_GID == "14") { RFTabs(true, true, true, true, true, true, true, true, true, true, true, true); }
            else if (_GID == "15") { RFTabs(false, true, true, true, true, false, false, false, false, false, false, false); }
            else if (_GID == "16") { RFTabs(true, false, false, false, false, false, false, false, false, false, false, false); }
            else { RFTabs(false, false, false, false, false, false, false, false, false, false, false, false); }
        }

        private void RFTabs(bool _AllRequest, bool _DraftRequest, bool _SubmittedRequest, bool _ForApproval, bool _SendBack, bool _Approved, bool _WarehouseChecking
            , bool _ForCanvass, bool _CanvassCreated, bool _POCreated, bool _ForwardedToPurchasing, bool _ServedRequest)
        {
            liAllRequest.Visible = _AllRequest;
            liDraftRequests.Visible = _DraftRequest;
            liSubmittedRequests.Visible = _SubmittedRequest;
            liForApproval.Visible = _ForApproval;
            liSentBackRequests.Visible = _SendBack;
            liApprovedRequests.Visible = _Approved;
            liWarehouseChecking.Visible = _WarehouseChecking;
            liForCanvassing.Visible = _ForCanvass;
            liCanvassCreatedNotForCanvass.Visible = _CanvassCreated;
            liPOCreated.Visible = _POCreated;
            liForwardedToPurchasing.Visible = _ForwardedToPurchasing;
            liServedRequests.Visible = _ServedRequest;
        }

        private void ResponseRedirect_RequestForm(string _I, string _L, string _S, string _T)
        {
            Session["I"] = _I;
            Session["L"] = _L;
            Session["S"] = _S;

            Response.Redirect("RequestForm?I=" + _I + "&L=" + _L + "&S=0&T=" + _T);
        }

        #endregion
    }
}