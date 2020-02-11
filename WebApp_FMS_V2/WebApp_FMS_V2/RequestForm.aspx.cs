using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using WebApp_FMS_V2.wcfFMSv2;

namespace WebApp_FMS_V2
{
    public partial class RequestForm : System.Web.UI.Page
    {
        #region Declaration(s)

        FMSV2Client wcfService = new FMSV2Client();
        _gControls _gc = new _gControls();
        string _RFID = string.Empty, _Label = string.Empty, _SubRequest = string.Empty, _Token = string.Empty;

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // Legend: 
                // I - RequestID; L - ReqeustLabel; S - Sub-RequestID; T - Token
                _RFID = Request.QueryString["I"].ToString();
                _Label = Request.QueryString["L"].ToString();
                _SubRequest = Request.QueryString["S"].ToString();

                //Check Session vs URLString
                if (Session["I"].ToString() == _RFID && Session["L"].ToString() == _Label && Session["S"].ToString() == _SubRequest)
                {
                    if (!Page.IsPostBack)
                    {
                        if (wcfService.Validate_Token(_gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"]))
                        {
                            _gc.DeserializeDropDownList(wcfService.Get_VesselDepartment("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                                , "VesselName", "VesselID", ddlRequestHeader_VesselSiteDept);

                            Load_Details(_Label, _RFID, _SubRequest);
                        }
                        else
                        {
                            wcfService.Save_TransactionLogs(_gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), "RequestForm"
                                , "Page_Load", "Unidentified Token", _gc.localComputerName, _gc.GetIPAddress());
                            Response.Redirect("Login");
                        }
                    }
                }
                else
                {
                    //URL Parameters has been manipulated
                    int _UID = 0;
                    if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                    wcfService.Save_TransactionLogs(_UID, "RequestForm", "Page_Load", "Request Query Sting Manupulation", _gc.localComputerName, _gc.GetIPAddress());
                    Response.Redirect("Login");
                }
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionLogs(_UID, "RequestForm", "Page_Load", ex.ToString(), _gc.localComputerName, _gc.GetIPAddress());
                Response.Redirect("Login");
            }
        }

        #region Request Header

        protected void btnRequestHeader_SaveDraft_Click(object sender, EventArgs e)
        {
            RequestHeader_Notification(true, "Save as Draft", "Are you sure you want to save the data as draft?", true, false);
        }

        protected void btnRequestHeader_AddItems_Click(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(txtRequestHeader_DateNeeded.Text) >= Convert.ToDateTime(txtRequestHeader_DateRequested.Text))
            {
                if (ddlRequestHeader_ItemFor.SelectedValue != "0")
                {
                    if (ddlRequestHeader_VesselSiteDept.SelectedValue != "0")
                    {
                        Get_RequestHeaderSummary(txtRequestHeader_RequestID.Text, txtRequestHeader_DateNeeded.Text, txtRequestHeader_DateRequested.Text
                            , ddlRequestHeader_VesselSiteDept.SelectedItem.Text, ddlRequestHeader_ItemFor.SelectedItem.Text, txtRequestHeader_Notify.Text
                            , txtRequestHeader_DeliverTo.Text, txtRequestHeader_Remarks.Text);

                        lblRequestHeader_Alert.Text = "";
                        RequestLines_Buttons(true, false, true);
                        modalRequestLines.Attributes.Add("class", "modal displayShow");
                    }
                    else { lblRequestHeader_Alert.Text = "Vessel/Site/Department cannot be empty."; }
                }
                else { lblRequestHeader_Alert.Text = "Item For cannot be empty."; }
            }
            else { lblRequestHeader_Alert.Text = "Date Needed cannot be less than date today."; }
        }

        protected void btnRequestHeader_EditItems_Click(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(txtRequestHeader_DateNeeded.Text) >= Convert.ToDateTime(txtRequestHeader_DateRequested.Text))
            {
                if (ddlRequestHeader_ItemFor.SelectedValue != "0")
                {
                    if (ddlRequestHeader_VesselSiteDept.SelectedValue != "0")
                    {
                        Get_RequestHeaderSummary(txtRequestHeader_RequestID.Text, txtRequestHeader_DateNeeded.Text, txtRequestHeader_DateRequested.Text
                            , ddlRequestHeader_VesselSiteDept.SelectedItem.Text, ddlRequestHeader_ItemFor.SelectedItem.Text, txtRequestHeader_Notify.Text
                            , txtRequestHeader_DeliverTo.Text, txtRequestHeader_Remarks.Text);

                        lblRequestHeader_Alert.Text = "";
                        RequestLines_Buttons(true, false, true);
                        modalRequestLines.Attributes.Add("class", "modal displayShow");
                    }
                    else { lblRequestHeader_Alert.Text = "Vessel/Site/Department cannot be empty."; }
                }
                else { lblRequestHeader_Alert.Text = "Item For cannot be empty."; }
            }
            else { lblRequestHeader_Alert.Text = "Date Needed cannot be less than date today."; }
        }

        protected void btnRequestHeader_Cancel_Click(object sender, EventArgs e)
        {
            RequestHeader_Notification(true, "Confirmation to Cancel", "Are you sure you want to cancel this transaction?", false, true);
        }


        protected void btnRequestHeaderDraft_SaveYes_Click(object sender, EventArgs e)
        {
            wcfService.Save_RequestHeader(_gc.ToInt32(txtRequestHeader_RequestID.Text), "Draft", _gc.ToInt32(ddlRequestHeader_VesselSiteDept.SelectedValue), (Convert.ToDateTime(txtRequestHeader_DateRequested.Text)).ToString("MM/dd/yyyy")
                , (Convert.ToDateTime(txtRequestHeader_DateNeeded.Text)).ToString("MM/dd/yyyy"), ddlRequestHeader_ItemFor.SelectedValue, txtRequestHeader_Notify.Text, txtRequestHeader_DeliverTo.Text, txtRequestHeader_Remarks.Text
                , _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)), (string)Session["tID"]);

            Response.Redirect("ViewRequest");
        }

        protected void btnRequestHeader_CancelYes_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewRequest");
        }

        protected void btnRequestHeader_No_Click(object sender, EventArgs e)
        {
            RequestHeader_Notification(false, "", "", false, false);
        }

        #endregion

        #region Request Lines

        protected void btnRequestLines_SaveItem_Click(object sender, EventArgs e)
        {

        }


        protected void btnRequestLines_ForApproval_Click(object sender, EventArgs e)
        {

        }

        protected void btnRequestLines_Resend_Click(object sender, EventArgs e)
        {

        }

        protected void btnRequestLines_Back_Click(object sender, EventArgs e)
        {
            RequestLines_Notification(true, "Return", "Are you sure you want to go back to the Request Header?", false, true);
        }


        protected void btnRequestLines_SaveYes_Click(object sender, EventArgs e)
        {

        }

        protected void btnRequestLines_CancelYes_Click(object sender, EventArgs e)
        {
            modalRequestLines_Notification.Attributes.Add("class", "modal displayHide");
            modalRequestLines.Attributes.Add("class", "modal displayHide");
        }

        protected void btnRequestLines_No_Click(object sender, EventArgs e)
        {
            modalRequestLines_Notification.Attributes.Add("class", "modal displayHide");
        }

        #endregion

        #region Propert(ies)

        protected void Load_Details(string _Label, string _RFID, string _SubRequest)
        {
            string _jsonResponse = string.Empty;

            switch (_Label)
            {
                case "ViewRequest":
                    _jsonResponse = wcfService.Get_RequestHeader(_RFID, _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)), (string)Session["tID"]);
                    LoadJsonResult(_jsonResponse, false);
                    ReqeustHeader_Buttons(true, true, false, true);
                    break;

                case "CreateNew":
                    _jsonResponse = wcfService.Add_RequestHeader(_gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)), (string)Session["tID"]);
                    LoadJsonResult(_jsonResponse, true);
                    ReqeustHeader_Buttons(true, true, false, true);
                    break;

                case "Draft":
                    _jsonResponse = wcfService.Get_RequestHeader(_RFID, _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)), (string)Session["tID"]);
                    LoadJsonResult(_jsonResponse, true);
                    ReqeustHeader_Buttons(true, false, true, true);
                    break;

                default:
                    break;
            }
        }

        protected void ReqeustHeader_Buttons(bool _Draft, bool _AddItem, bool _EditItem, bool _Cancel)
        {
            btnRequestHeader_SaveDraft.Visible = _Draft;
            btnRequestHeader_AddItems.Visible = _AddItem;
            btnRequestHeader_EditItems.Visible = _EditItem;
            btnRequestHeader_Cancel.Visible = _Cancel;
        }

        protected void RequestLines_Buttons(bool _ForApproval, bool _Resend, bool _Back)
        {
            btnRequestLines_ForApproval.Visible = _ForApproval;
            btnRequestLines_Resend.Visible = _Resend;
            btnRequestLines_Back.Visible = _Back;
        }

        protected void LoadJsonResult(string _JsonResult, bool _NewDraft)
        {
            if (_JsonResult != "")
            {
                dynamic _jData = JsonConvert.DeserializeObject<dynamic>(_JsonResult);

                txtRequestHeader_RequestID.Text = (string)_jData[0].RequestID;

                //txtRequestHeader_RequestedBy.Text = (string)_jData[0].RequestedBy;
                //txtRequestHeader_DateRequested.Text = (_jData[0].DateRequested).ToString("yyyy-MM-dd");

                ddlRequestHeader_VesselSiteDept.SelectedValue = (string)_jData[0].VesselID;
                ddlRequestHeader_ItemFor.SelectedValue = (string)_jData[0].ItemFor;
                txtRequestHeader_DateNeeded.Text = DateTime.Today.ToString("yyyy-MM-dd");
                txtRequestHeader_Notify.Text = _jData[0].Notify;
                txtRequestHeader_DeliverTo.Text = _jData[0].DeliverTo;
                txtRequestHeader_Remarks.Text = _jData[0].Remarks;
            }

            if (_NewDraft)
            {
                txtRequestHeader_RequestedBy.Text = _Cypher.Decrypt(Session["ClientName"].ToString(), _Cypher._PassPhrase);
                txtRequestHeader_DateRequested.Text = DateTime.Today.ToString("yyyy-MM-dd");
            }
        }

        private void Get_RequestHeaderSummary(string _RFID, string _DateNeeded, string _DateRequested, string _VesselSiteDept, string _ItemFor, string _Notify, string _DeliverTo, string _Remarks)
        {
            lblRHSummary_RequestID.Text = "Request ID: " + _RFID;

            lblRHSummary_DateNeeded.Text = _DateNeeded;
            lblRHSummary_DateRequested.Text = _DateRequested;

            lblRHSummary_VesselSiteDeptartment.Text = _VesselSiteDept;
            lblRHSummary_ItemFor.Text = _ItemFor;

            lblRHSummary_Notify.Text = _Notify;
            lblRHSummary_DeliverTo.Text = _DeliverTo;
            lblRHSummary_Remarks.Text = _Remarks;
        }

        private void RequestHeader_Notification(bool _ShowHide, string _HeaderText, string _BodyText, bool _SaveDraft, bool _Cancel)
        {
            if (_ShowHide) { modalRequestHeader_Notification.Attributes.Add("class", "modal displayShow"); }
            else { modalRequestHeader_Notification.Attributes.Add("class", "modal displayHide"); }

            lblRequestHeader_NotifHeader.Text = _HeaderText;
            lblRequestHeader_NotifBody.Text = _BodyText;

            btnRequestHeaderDraft_SaveYes.Visible = _SaveDraft;
            btnRequestHeader_CancelYes.Visible = _Cancel;
        }

        private void RequestLines_Notification(bool _ShowHide, string _HeaderText, string _BodyText, bool _Save, bool _Cancel)
        {
            if (_ShowHide) { modalRequestLines_Notification.Attributes.Add("class", "modal displayShow"); }
            else { modalRequestLines_Notification.Attributes.Add("class", "modal displayHide"); }

            lblRequestLines_NotifHeader.Text = _HeaderText;
            lblRequestLines_NotifBody.Text = _BodyText;

            btnRequestLines_SaveYes.Visible = _Save;
            btnRequestLines_CancelYes.Visible = _Cancel;
        }

        private void ClearHeader()
        {
            txtRequestHeader_RequestID.Text = "";
            txtRequestHeader_RequestedBy.Text = "";
            txtRequestHeader_DateRequested.Text = DateTime.Today.ToString("yyyy-MM-dd");
            ddlRequestHeader_VesselSiteDept.SelectedValue = "0";
            ddlRequestHeader_ItemFor.SelectedValue = "0";
            txtRequestHeader_DateNeeded.Text = DateTime.Today.ToString("yyyy-MM-dd");
            txtRequestHeader_Notify.Text = "";
            txtRequestHeader_DeliverTo.Text = "";
            txtRequestHeader_Remarks.Text = "";

            lblRequestHeader_Alert.Text = "";
        }

        #endregion
    }
}