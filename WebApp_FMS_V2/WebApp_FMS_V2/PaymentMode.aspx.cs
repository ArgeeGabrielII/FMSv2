using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp_FMS_V2.wcfFMSv2;

namespace WebApp_FMS_V2
{
    public partial class PaymentMode : System.Web.UI.Page
    {
        FMSV2Client wcfService = new FMSV2Client();
        _gControls _gc = new _gControls();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    _gc.DeserializeDataTable(wcfService.Get_PaymentMode("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                      , gvPaymentModeList);

                    MainButton(true, false);

                    mvPaymentMode.SetActiveView(vwViewPaymentMode);
                }
                else { }
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionLogs(_UID, "PaymentMode", "Page_Load", ex.ToString(), _gc.localComputerName, _gc.GetIPAddress());
                Response.Redirect("Login");
            }
        }


        protected void lnkPaymentModeView_Search_Click(object sender, EventArgs e)
        {
            try
            {
                _gc.DeserializeDataTable(wcfService.Get_PaymentMode(txtPaymentModeView_Search.Text, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                    , gvPaymentModeList);
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionLogs(_UID, "PaymentMode", "lnkPaymentModeView_Search_Click", ex.ToString(), _gc.localComputerName, _gc.GetIPAddress());
                Response.Redirect("Login");
            }
        }


        protected void btnPaymentMode_Create_Click(object sender, EventArgs e)
        {
            mvPaymentMode.SetActiveView(vwDetailsPaymentMode);
            MainButton(false, true);
            Clear();
        }

        protected void btnPaymentMode_Back_Click(object sender, EventArgs e)
        {
            _gc.DeserializeDataTable(wcfService.Get_PaymentMode("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                , gvPaymentModeList);

            MainButton(true, false);
            Clear();

            mvPaymentMode.SetActiveView(vwViewPaymentMode);
        }


        protected void btnPaymentModeDetails_Submit_Click(object sender, EventArgs e)
        {
            if (txtPaymentModeDetails_Code.Text != "")
            {
                if (txtPaymentModeDetails_PaymentMode.Text != "")
                {
                    NotificationModal(true, "Confirmation to Save", "Are you sure you want to save this transaction?", true, false);
                }
                else { lblPaymentModeDetails_Alert.Text = "Code is a required field."; }
            }
            else { lblPaymentModeDetails_Alert.Text = "Payment Mode is a required field."; }
        }

        protected void btnPaymentModeDetails_Cancel_Click(object sender, EventArgs e)
        {
            NotificationModal(true, "Confirmation to Cancel", "Are you sure you want to cancel this transaction?", false, true);
        }


        protected void btnPaymentModeDetails_SaveYes_Click(object sender, EventArgs e)
        {
            #region Save

            try
            {
                NotificationModal(false, "", "", false, false);

                //Save Payment Mode
                wcfService.Save_PaymentMode(_gc.ToInt32(hfPaymentModeID.Value), txtPaymentModeDetails_Code.Text, txtPaymentModeDetails_PaymentMode.Text
                    , _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"]);

                //Save User Trails
                string _TransType = "";
                _TransType = "Save PaymentMode - ID: " + hfPaymentModeID.Value + "; Code: " + txtPaymentModeDetails_Code.Text + "; Mode: " + txtPaymentModeDetails_PaymentMode;

                wcfService.Trails_UserTrails(0, _gc.ToInt32(hfPaymentModeID.Value), 0, _TransType);

                //Save Transaction Logs
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionLogs(_UID, "PaymentMode", "btnPaymentModeDetails_SaveYes_Click", _TransType, _gc.localComputerName, _gc.GetIPAddress());

                lblPaymentModeDetails_Alert.Text = "";
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionLogs(_UID, "PaymentMode", "btnPaymentModeDetails_SaveYes_Click", ex.ToString(), _gc.localComputerName, _gc.GetIPAddress());
            }
            finally
            {
                _gc.DeserializeDataTable(wcfService.Get_PaymentMode("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                    , gvPaymentModeList);

                MainButton(true, false);
                Clear();

                mvPaymentMode.SetActiveView(vwViewPaymentMode);
            }

            #endregion
        }

        protected void btnPaymentModeDetails_CancelYes_Click(object sender, EventArgs e)
        {
            NotificationModal(false, "", "", false, false);

            _gc.DeserializeDataTable(wcfService.Get_PaymentMode("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                , gvPaymentModeList);

            MainButton(true, false);
            Clear();

            mvPaymentMode.SetActiveView(vwViewPaymentMode);
        }

        protected void btnPaymentModeDetails_No_Click(object sender, EventArgs e)
        {
            NotificationModal(false, "", "", false, false);
        }

        #region GridView Events

        protected void gvPaymentModeList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int rowindex = Convert.ToInt32(e.CommandArgument) % gvPaymentModeList.PageSize;
                GridViewRow row = gvPaymentModeList.Rows[rowindex];

                if (e.CommandName == "Select")
                {
                    hfPaymentModeID.Value = row.Cells[0].Text;
                    txtPaymentModeDetails_Code.Text = row.Cells[1].Text.Replace("&nbsp;", "");
                    txtPaymentModeDetails_PaymentMode.Text = row.Cells[2].Text.Replace("&nbsp;", "");

                    mvPaymentMode.SetActiveView(vwDetailsPaymentMode);
                    MainButton(false, true);
                }
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionLogs(_UID, "PaymentMode", "gvPaymentModeList_RowCommand", ex.ToString(), _gc.localComputerName, _gc.GetIPAddress());
            }
        }

        protected void gvPaymentModeList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPaymentModeList.PageIndex = e.NewPageIndex;
            _gc.DeserializeDataTable(wcfService.Get_PaymentMode(txtPaymentModeView_Search.Text, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                , gvPaymentModeList);
        }

        protected void gvPaymentModeList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion

        #region Property(ies)

        private void MainButton(bool _btnCreate, bool _btnBack)
        {
            btnPaymentMode_Create.Visible = _btnCreate;
            btnPaymentMode_Back.Visible = _btnBack;
        }

        private void NotificationModal(bool _ShowHide, string _HeaderText, string _BodyText, bool _Save, bool _Cancel)
        {
            if (_ShowHide) { modalNotification.Attributes.Add("class", "modal displayShow"); }
            else { modalNotification.Attributes.Add("class", "modal displayHide"); }

            lblPaymentModeDetails_NotifHeader.Text = _HeaderText;
            lblPaymentModeDetails_NotifBody.Text = _BodyText;

            btnPaymentModeDetails_SaveYes.Visible = _Save;
            btnPaymentModeDetails_CancelYes.Visible = _Cancel;
        }

        private void Clear()
        {
            hfPaymentModeID.Value = "0";
            txtPaymentModeDetails_Code.Text = "";
            txtPaymentModeDetails_PaymentMode.Text = "";

            lblPaymentModeDetails_Alert.Text = "";
        }

        #endregion
    }
}