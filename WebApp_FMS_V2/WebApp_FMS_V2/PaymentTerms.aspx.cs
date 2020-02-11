using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp_FMS_V2.wcfFMSv2;

namespace WebApp_FMS_V2
{
    public partial class PaymentTerms : System.Web.UI.Page
    {
        FMSV2Client wcfService = new FMSV2Client();
        _gControls _gc = new _gControls();


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    _gc.DeserializeDataTable(wcfService.Get_PaymentTerm("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                      , gvPaymentTermsList);

                    MainButton(true, false);

                    mvPaymentTerms.SetActiveView(vwViewPaymentTerms);
                }
                else { }
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionLogs(_UID, "PaymentTerms", "Page_Load", ex.ToString(), _gc.localComputerName, _gc.GetIPAddress());
                Response.Redirect("Login");
            }
        }

        protected void btnPaymentTerms_Create_Click(object sender, EventArgs e)
        {
            mvPaymentTerms.SetActiveView(vwDetailsPaymentTerms);
            MainButton(false, true);
            Clear();
        }

        protected void btnPaymentTerms_Back_Click(object sender, EventArgs e)
        {
            _gc.DeserializeDataTable(wcfService.Get_PaymentTerm("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                , gvPaymentTermsList);

            MainButton(true, false);
            Clear();

            mvPaymentTerms.SetActiveView(vwDetailsPaymentTerms);
        }


        protected void lnkPaymentTermsView_Search_Click(object sender, EventArgs e)
        {
            try
            {
                _gc.DeserializeDataTable(wcfService.Get_PaymentTerm(txtPaymentTermsView_Search.Text, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                      , gvPaymentTermsList);
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionLogs(_UID, "PaymentMode", "lnkPaymentTermsView_Search_Click", ex.ToString(), _gc.localComputerName, _gc.GetIPAddress());
                Response.Redirect("Login");
            }
        }


        protected void btnPaymentTermsDetails_Submit_Click(object sender, EventArgs e)
        {
            if (txtPaymentTermsDetails_Code.Text != "")
            {
                if (txtPaymentTermsDetails_PaymentTerms.Text != "")
                {
                    NotificationModal(true, "Confirmation to Save", "Are you sure you want to save this transaction?", true, false);
                }
                else { lblPaymentTermsDetails_Alert.Text = "Code is a required field."; }
            }
            else { lblPaymentTermsDetails_Alert.Text = "Payment Term is a required field."; }
        }

        protected void btnPaymentTermsDetails_Cancel_Click(object sender, EventArgs e)
        {
            NotificationModal(true, "Confirmation to Cancel", "Are you sure you want to cancel this transaction?", false, true);
        }


        protected void btnPaymentTermsDetails_SaveYes_Click(object sender, EventArgs e)
        {
            #region Save

            try
            {
                NotificationModal(false, "", "", false, false);

                //Save Payment Mode
                wcfService.Save_PaymentTerms(_gc.ToInt32(hfPaymentTermsID.Value), txtPaymentTermsDetails_Code.Text, txtPaymentTermsDetails_PaymentTerms.Text
                    , _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"]);

                //Save User Trails
                string _TransType = "";
                _TransType = "Save PaymentTerms - ID: " + hfPaymentTermsID.Value + "; Code: " + txtPaymentTermsDetails_Code.Text + "; Terms: " + txtPaymentTermsDetails_PaymentTerms;

                wcfService.Trails_UserTrails(_gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), _gc.ToInt32(hfPaymentTermsID.Value), 0, _TransType);

                //Save Transaction Logs
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionLogs(_UID, "PaymentTerms", "btnPaymentTermsDetails_SaveYes_Click", _TransType, _gc.localComputerName, _gc.GetIPAddress());

                lblPaymentTermsDetails_Alert.Text = "";
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionLogs(_UID, "PaymentTerms", "btnPaymentTermsDetails_SaveYes_Click", ex.ToString(), _gc.localComputerName, _gc.GetIPAddress());
            }
            finally
            {
                _gc.DeserializeDataTable(wcfService.Get_PaymentTerm("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                      , gvPaymentTermsList);

                MainButton(true, false);
                Clear();

                mvPaymentTerms.SetActiveView(vwViewPaymentTerms);
            }

            #endregion
        }

        protected void btnPaymentTermsDetails_CancelYes_Click(object sender, EventArgs e)
        {
            NotificationModal(false, "", "", false, false);

            _gc.DeserializeDataTable(wcfService.Get_PaymentTerm("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                , gvPaymentTermsList);

            MainButton(true, false);
            Clear();

            mvPaymentTerms.SetActiveView(vwViewPaymentTerms);
        }

        protected void btnPaymentTermsDetails_No_Click(object sender, EventArgs e)
        {
            NotificationModal(false, "", "", false, false);
        }

        #region GridView Events

        protected void gvPaymentTermsList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int rowindex = Convert.ToInt32(e.CommandArgument) % gvPaymentTermsList.PageSize;
                GridViewRow row = gvPaymentTermsList.Rows[rowindex];

                if (e.CommandName == "Select")
                {
                    hfPaymentTermsID.Value = row.Cells[0].Text;
                    txtPaymentTermsDetails_Code.Text = row.Cells[1].Text.Replace("&nbsp;", "");
                    txtPaymentTermsDetails_PaymentTerms.Text = row.Cells[2].Text.Replace("&nbsp;", "");

                    mvPaymentTerms.SetActiveView(vwDetailsPaymentTerms);
                    MainButton(false, true);
                }
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionLogs(_UID, "PaymentTerms", "gvPaymentTermsList_RowCommand", ex.ToString(), _gc.localComputerName, _gc.GetIPAddress());
            }
        }

        protected void gvPaymentTermsList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPaymentTermsList.PageIndex = e.NewPageIndex;
            _gc.DeserializeDataTable(wcfService.Get_PaymentTerm(txtPaymentTermsView_Search.Text, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                , gvPaymentTermsList);
        }

        protected void gvPaymentTermsList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion

        #region Property(ies)

        private void MainButton(bool _btnCreate, bool _btnBack)
        {
            btnPaymentTerms_Create.Visible = _btnCreate;
            btnPaymentTerms_Back.Visible = _btnBack;
        }

        private void NotificationModal(bool _ShowHide, string _HeaderText, string _BodyText, bool _Save, bool _Cancel)
        {
            if (_ShowHide) { modalNotification.Attributes.Add("class", "modal displayShow"); }
            else { modalNotification.Attributes.Add("class", "modal displayHide"); }

            lblPaymentTermsDetails_NotifHeader.Text = _HeaderText;
            lblPaymentTermsDetails_NotifBody.Text = _BodyText;

            btnPaymentTermsDetails_SaveYes.Visible = _Save;
            btnPaymentTermsDetails_CancelYes.Visible = _Cancel;
        }

        private void Clear()
        {
            hfPaymentTermsID.Value = "0";
            txtPaymentTermsDetails_Code.Text = "";
            txtPaymentTermsDetails_PaymentTerms.Text = "";

            lblPaymentTermsDetails_Alert.Text = "";
        }

        #endregion
    }
}