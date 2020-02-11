using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp_FMS_V2.wcfFMSv2;

namespace WebApp_FMS_V2
{
    public partial class Currency : System.Web.UI.Page
    {
        FMSV2Client wcfService = new FMSV2Client();
        _gControls _gc = new _gControls();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    _gc.DeserializeDataTable(wcfService.Get_Currency("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                          , gvCurrencyList);

                    MainButton(true, false);

                    mvCurrency.SetActiveView(vwViewCurrency);
                }
                else { }
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionLogs(_UID, "Currency", "Page_Load", ex.ToString(), _gc.localComputerName, _gc.GetIPAddress());
                Response.Redirect("Login");
            }
        }


        protected void lnkCurrency_Search_Click(object sender, EventArgs e)
        {
            try
            {
                _gc.DeserializeDataTable(wcfService.Get_Currency(txtCurrency_Search.Text, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                    , gvCurrencyList);
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionLogs(_UID, "Currency", "lnkCurrency_Search_Click", ex.ToString(), _gc.localComputerName, _gc.GetIPAddress());
                Response.Redirect("Login");
            }
        }


        protected void btnCurrency_Create_Click(object sender, EventArgs e)
        {
            MainButton(false, true);
            Clear();

            mvCurrency.SetActiveView(vwDetailsCurrency);
        }

        protected void btnCurrency_Back_Click(object sender, EventArgs e)
        {
            _gc.DeserializeDataTable(wcfService.Get_Currency("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                , gvCurrencyList);

            MainButton(true, false);
            Clear();

            mvCurrency.SetActiveView(vwViewCurrency);
        }


        protected void btnCurrencyDetails_Submit_Click(object sender, EventArgs e)
        {
            if (txtCurrencyDetails_Code.Text != "")
            {
                if (txtCurrencyDetails_Currency.Text != "")
                {
                    NotificationModal(true, "Confirmation to Save", "Are you sure you want to save this transaction?", true, false);
                }
                else { lblCurrencyDetails_Alert.Text = "Currency is a required field."; }
            }
            else { lblCurrencyDetails_Alert.Text = "Code is a required field."; }
        }

        protected void btnCurrencyDetails_Cancel_Click(object sender, EventArgs e)
        {
            NotificationModal(true, "Confirmation to Cancel", "Are you sure you want to cancel this transaction?", false, true);
        }


        protected void btnCurrencyDetails_SaveYes_Click(object sender, EventArgs e)
        {
            #region Save

            try
            {
                NotificationModal(false, "", "", false, false);

                //Save Currency
                wcfService.Save_Currency(_gc.ToInt32(hfCurrencyID.Value), txtCurrencyDetails_Code.Text, txtCurrencyDetails_Currency.Text
                    , _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"]);

                //Save User Trails
                string _TransType = "";
                _TransType = "Save Currency - ID: " + hfCurrencyID.Value + "; Code: " + txtCurrencyDetails_Code.Text + "; Currency: " + txtCurrencyDetails_Currency;

                wcfService.Trails_UserTrails(_gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), _gc.ToInt32(hfCurrencyID.Value), 0, _TransType);

                //Save Transaction Logs
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionLogs(_UID, "Currency", "btnCurrencyDetails_SaveYes_Click", _TransType, _gc.localComputerName, _gc.GetIPAddress());

                lblCurrencyDetails_Alert.Text = "";
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionLogs(_UID, "Currency", "btnCurrencyDetails_SaveYes_Click", ex.ToString(), _gc.localComputerName, _gc.GetIPAddress());
            }
            finally
            {
                _gc.DeserializeDataTable(wcfService.Get_Currency("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                          , gvCurrencyList);

                MainButton(true, false);
                Clear();

                mvCurrency.SetActiveView(vwViewCurrency);
            }

            #endregion
        }

        protected void btnCurrencyDetails_CancelYes_Click(object sender, EventArgs e)
        {
            NotificationModal(false, "", "", false, false);

            _gc.DeserializeDataTable(wcfService.Get_Currency("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                , gvCurrencyList);

            MainButton(true, false);
            Clear();

            mvCurrency.SetActiveView(vwViewCurrency);
        }

        protected void btnCurrencyDetails_No_Click(object sender, EventArgs e)
        {
            NotificationModal(false, "", "", false, false);
        }

        #region GridView Events

        protected void gvCurrencyList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int rowindex = Convert.ToInt32(e.CommandArgument) % gvCurrencyList.PageSize;
                GridViewRow row = gvCurrencyList.Rows[rowindex];

                if (e.CommandName == "Select")
                {
                    hfCurrencyID.Value = row.Cells[0].Text;
                    txtCurrencyDetails_Code.Text = row.Cells[1].Text;
                    txtCurrencyDetails_Currency.Text = row.Cells[2].Text.Replace("&nbsp;", "");

                    mvCurrency.SetActiveView(vwDetailsCurrency);
                    MainButton(false, true);
                }
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionLogs(_UID, "Currency", "gvCurrencyList_RowCommand", ex.ToString(), _gc.localComputerName, _gc.GetIPAddress());
            }
        }

        protected void gvCurrencyList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvCurrencyList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion

        #region Property(ies)

        private void MainButton(bool _btnCreate, bool _btnBack)
        {
            btnCurrency_Create.Visible = _btnCreate;
            btnCurrency_Back.Visible = _btnBack;
        }

        private void NotificationModal(bool _ShowHide, string _HeaderText, string _BodyText, bool _Save, bool _Cancel)
        {
            if (_ShowHide) { modalNotification.Attributes.Add("class", "modal displayShow"); }
            else { modalNotification.Attributes.Add("class", "modal displayHide"); }

            lblCurrencyDetails_NotifHeader.Text = _HeaderText;
            lblCurrencyDetails_NotifBody.Text = _BodyText;

            btnCurrencyDetails_SaveYes.Visible = _Save;
            btnCurrencyDetails_CancelYes.Visible = _Cancel;
        }

        private void Clear()
        {
            hfCurrencyID.Value = "0";
            txtCurrencyDetails_Code.Text = "";
            txtCurrencyDetails_Currency.Text = "";

            lblCurrencyDetails_Alert.Text = "";
        }

        #endregion
    }
}