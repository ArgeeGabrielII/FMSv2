using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp_FMS_V2.wcfFMSv2;

namespace WebApp_FMS_V2
{
    public partial class FlagRegistration : System.Web.UI.Page
    {
        FMSV2Client wcfService = new FMSV2Client();
        _gControls _gc = new _gControls();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    _gc.DeserializeDataTable(wcfService.Get_FlagRegistration("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                            , gvFlagRegistrationList);

                    MainButton(true, false);

                    mvFlagRegistration.SetActiveView(vwViewFlagRegistration);
                }
                else { }
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionLogs(_UID, "FlagRegistration", "Page_Load", ex.ToString(), _gc.localComputerName, _gc.GetIPAddress());
                Response.Redirect("Login");
            }
        }


        protected void btnFlagRegistration_Create_Click(object sender, EventArgs e)
        {
            mvFlagRegistration.SetActiveView(vwDetailsFlagRegistration);
            MainButton(false, true);
            Clear();
        }

        protected void btnFlagRegistration_Back_Click(object sender, EventArgs e)
        {
            _gc.DeserializeDataTable(wcfService.Get_FlagRegistration("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                            , gvFlagRegistrationList);

            MainButton(true, false);
            Clear();

            mvFlagRegistration.SetActiveView(vwViewFlagRegistration);
        }


        protected void lnkFlagRegistrationView_Search_Click(object sender, EventArgs e)
        {
            try
            {
                _gc.DeserializeDataTable(wcfService.Get_FlagRegistration(txtFlagRegistrationView_Search.Text, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                    , gvFlagRegistrationList);
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionLogs(_UID, "FlagRegistration", "lnkFlagRegistrationView_Search_Click", ex.ToString(), _gc.localComputerName, _gc.GetIPAddress());
                Response.Redirect("Login");
            }
        }


        protected void btnFlagRegistrationDetails_Submit_Click(object sender, EventArgs e)
        {
            if (txtFlagRegistrationDetails_FlagName.Text != "")
            {
                NotificationModal(true, "Confirmation to Save", "Are you sure you want to save this transaction?", true, false);
            }
            else { lblFlagRegistrationDetails_Alert.Text = "Flag Name is a required field."; }
        }

        protected void btnFlagRegistrationDetails_Cancel_Click(object sender, EventArgs e)
        {
            NotificationModal(true, "Confirmation to Cancel", "Are you sure you want to cancel this transaction?", false, true);
        }


        protected void btnFlagRegistrationDetails_SaveYes_Click(object sender, EventArgs e)
        {
            #region Save

            try
            {
                NotificationModal(false, "", "", false, false);

                //Save Supplier
                wcfService.Save_FlagRegistration(_gc.ToInt32(hfFlagRegistrationID.Value), txtFlagRegistrationDetails_FlagName.Text
                    , _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"]);

                //Save User Trails
                string _TransType = "";
                _TransType = "Save Flag Registration - Flag ID: " + hfFlagRegistrationID.Value + "; Flag Name: " + txtFlagRegistrationDetails_FlagName.Text;

                wcfService.Trails_UserTrails(_gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), _gc.ToInt32(hfFlagRegistrationID.Value), 0, _TransType);

                //Save Transaction Logs
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionLogs(_UID, "FlagRegistration", "btnFlagRegistrationDetails_SaveYes_Click", _TransType, _gc.localComputerName, _gc.GetIPAddress());

                lblFlagRegistrationDetails_Alert.Text = "";
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionLogs(_UID, "FlagRegistration", "btnFlagRegistrationDetails_SaveYes_Click", ex.ToString(), _gc.localComputerName, _gc.GetIPAddress());
            }
            finally
            {
                _gc.DeserializeDataTable(wcfService.Get_FlagRegistration("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                    , gvFlagRegistrationList);

                MainButton(true, false);
                Clear();

                mvFlagRegistration.SetActiveView(vwViewFlagRegistration);
            }

            #endregion
        }

        protected void btnFlagRegistrationDetails_CancelYes_Click(object sender, EventArgs e)
        {
            NotificationModal(false, "", "", false, false);

            _gc.DeserializeDataTable(wcfService.Get_FlagRegistration("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                            , gvFlagRegistrationList);

            MainButton(true, false);
            Clear();

            mvFlagRegistration.SetActiveView(vwViewFlagRegistration);
        }

        protected void btnFlagRegistrationDetails_No_Click(object sender, EventArgs e)
        {
            NotificationModal(false, "", "", false, false);
        }

        #region GridView Events

        protected void gvFlagRegistrationList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int rowindex = Convert.ToInt32(e.CommandArgument) % gvFlagRegistrationList.PageSize;
                GridViewRow row = gvFlagRegistrationList.Rows[rowindex];

                if (e.CommandName == "Select")
                {
                    hfFlagRegistrationID.Value = row.Cells[0].Text;
                    txtFlagRegistrationDetails_FlagName.Text = row.Cells[1].Text.Replace("&nbsp;", "");

                    mvFlagRegistration.SetActiveView(vwDetailsFlagRegistration);
                    MainButton(false, true);
                }
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionLogs(_UID, "FlagRegistration", "gvFlagRegistrationList_RowCommand", ex.ToString(), _gc.localComputerName, _gc.GetIPAddress());
            }
        }

        protected void gvFlagRegistrationList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvFlagRegistrationList.PageIndex = e.NewPageIndex;
            _gc.DeserializeDataTable(wcfService.Get_FlagRegistration(txtFlagRegistrationView_Search.Text, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                , gvFlagRegistrationList);
        }

        protected void gvFlagRegistrationList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion

        #region Property(ies)

        private void MainButton(bool _btnCreate, bool _btnBack)
        {
            btnFlagRegistration_Create.Visible = _btnCreate;
            btnFlagRegistration_Back.Visible = _btnBack;
        }

        private void NotificationModal(bool _ShowHide, string _HeaderText, string _BodyText, bool _Save, bool _Cancel)
        {
            if (_ShowHide) { modalNotification.Attributes.Add("class", "modal displayShow"); }
            else { modalNotification.Attributes.Add("class", "modal displayHide"); }

            lblFlagRegistrationDetails_NotifHeader.Text = _HeaderText;
            lblFlagRegistrationDetails_NotifBody.Text = _BodyText;

            btnFlagRegistrationDetails_SaveYes.Visible = _Save;
            btnFlagRegistrationDetails_CancelYes.Visible = _Cancel;
        }

        private void Clear()
        {
            hfFlagRegistrationID.Value = "0";
            txtFlagRegistrationDetails_FlagName.Text = "";

            lblFlagRegistrationDetails_Alert.Text = "";
        }

        #endregion
    }
}