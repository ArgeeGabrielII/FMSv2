using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp_FMS_V2.wcfFMSv2;

namespace WebApp_FMS_V2
{
    public partial class Supplier : System.Web.UI.Page
    {
        FMSV2Client wcfService = new FMSV2Client();
        _gControls _gc = new _gControls();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    _gc.DeserializeDataTable(wcfService.Get_Supplier("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                          , gvSupplierList);

                    _gc.DeserializeDropDownList(wcfService.Get_Currency("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"]), "CurrencyCodeName", "CurrencyID", ddlSupplierDetails_Currency);
                    _gc.DeserializeDropDownList(wcfService.Get_PaymentMode("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"]), "PaymentModes", "PaymentModeCode", ddlSupplierDetails_ModeOfPayment);
                    _gc.DeserializeDropDownList(wcfService.Get_PaymentTerm("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"]), "PaymentTerms", "PaymentTermsCode", ddlSupplierDetails_PaymentTerms);

                    MainButton(true, false);

                    mvSupplier.SetActiveView(vwViewSupplier);
                }
                else { }
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionLogs(_UID, "Supplier", "Page_Load", ex.ToString(), _gc.localComputerName, _gc.GetIPAddress());
                Response.Redirect("Login");
            }
        }


        protected void lnkSupplier_Search_Click(object sender, EventArgs e)
        {
            try
            {
                _gc.DeserializeDataTable(wcfService.Get_Supplier(txtSupplier_Search.Text, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                    , gvSupplierList);
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionLogs(_UID, "Supplier", "lnkSupplier_Search_Click", ex.ToString(), _gc.localComputerName, _gc.GetIPAddress());
                Response.Redirect("Login");
            }
        }


        protected void btnSupplier_Create_Click(object sender, EventArgs e)
        {
            mvSupplier.SetActiveView(vwDetailsSupplier);
            MainButton(false, true);
            Clear();
        }

        protected void btnSupplier_Back_Click(object sender, EventArgs e)
        {
            _gc.DeserializeDataTable(wcfService.Get_Supplier("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
               , gvSupplierList);

            MainButton(true, false);
            Clear();

            mvSupplier.SetActiveView(vwViewSupplier);
        }


        protected void btnSupplierDetails_Submit_Click(object sender, EventArgs e)
        {
            if (txtSupplierDetails_SupplierName.Text != "")
            {
                NotificationModal(true, "Confirmation to Save", "Are you sure you want to save this transaction?", true, false);
            }
            else { lblSupplierDetails_Alert.Text = "Supplier Name is a required field."; }
        }

        protected void btnSupplierDetails_Cancel_Click(object sender, EventArgs e)
        {
            NotificationModal(true, "Confirmation to Cancel", "Are you sure you want to cancel this transaction?", false, true);
        }


        protected void btnSupplierDetails_SaveYes_Click(object sender, EventArgs e)
        {
            #region Save

            try
            {
                NotificationModal(false, "", "", false, false);

                //Save Supplier
                wcfService.Save_Supplier(_gc.ToInt32(hfSupplierID.Value), txtSupplierDetails_SupplierName.Text, txtSupplierDetails_ContactPerson.Text, txtSupplierDetails_ContactNo.Text
                    , _gc.ToInt32(ddlSupplierDetails_Currency.SelectedValue), ddlSupplierDetails_PaymentTerms.SelectedValue, ddlSupplierDetails_ModeOfPayment.SelectedValue
                    , _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"]);

                //Save User Trails
                string _TransType = "";
                _TransType = "Save Supplier - Supplier Name: " + txtSupplierDetails_SupplierName.Text + "; Contact Person: " + txtSupplierDetails_ContactPerson.Text + "; Contact No: " +
                    txtSupplierDetails_ContactNo.Text + "; Payment Terms: " + ddlSupplierDetails_PaymentTerms.SelectedValue + "; Mode of Payment: " + ddlSupplierDetails_ModeOfPayment.SelectedValue +
                    "; Currency: " + ddlSupplierDetails_Currency.SelectedValue;

                wcfService.Trails_UserTrails(_gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), _gc.ToInt32(hfSupplierID.Value), 0, _TransType);

                //Save Transaction Logs
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionLogs(_UID, "Supplier", "btnSupplierDetails_SaveYes_Click", _TransType, _gc.localComputerName, _gc.GetIPAddress());

                lblSupplierDetails_Alert.Text = "";
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionLogs(_UID, "Supplier", "btnSupplierDetails_SaveYes_Click", ex.ToString(), _gc.localComputerName, _gc.GetIPAddress());
            }
            finally
            {
                _gc.DeserializeDataTable(wcfService.Get_Supplier("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                , gvSupplierList);

                MainButton(true, false);
                Clear();

                mvSupplier.SetActiveView(vwViewSupplier);
            }

            #endregion
        }

        protected void btnSupplierDetails_CancelYes_Click(object sender, EventArgs e)
        {
            NotificationModal(false, "", "", false, false);

            _gc.DeserializeDataTable(wcfService.Get_Supplier("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                , gvSupplierList);

            MainButton(true, false);
            Clear();

            mvSupplier.SetActiveView(vwViewSupplier);
        }

        protected void btnSupplierDetails_No_Click(object sender, EventArgs e)
        {
            NotificationModal(false, "", "", false, false);
        }

        #region GridView Events

        protected void gvSupplierList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int rowindex = Convert.ToInt32(e.CommandArgument) % gvSupplierList.PageSize;
                GridViewRow row = gvSupplierList.Rows[rowindex];

                if (e.CommandName == "Select")
                {
                    hfSupplierID.Value = row.Cells[0].Text;
                    txtSupplierDetails_SupplierName.Text = row.Cells[1].Text;
                    txtSupplierDetails_ContactPerson.Text = row.Cells[2].Text.Replace("&nbsp;", "");
                    txtSupplierDetails_ContactNo.Text = row.Cells[3].Text.Replace("&nbsp;", "");
                    ddlSupplierDetails_Currency.SelectedValue = row.Cells[4].Text;
                    ddlSupplierDetails_PaymentTerms.SelectedValue = row.Cells[6].Text;
                    ddlSupplierDetails_ModeOfPayment.SelectedValue = row.Cells[7].Text;

                    mvSupplier.SetActiveView(vwDetailsSupplier);
                    MainButton(false, true);
                }
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionLogs(_UID, "Supplier", "gvSupplierList_RowCommand", ex.ToString(), _gc.localComputerName, _gc.GetIPAddress());
            }
        }

        protected void gvSupplierList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSupplierList.PageIndex = e.NewPageIndex;
            _gc.DeserializeDataTable(wcfService.Get_Supplier(txtSupplier_Search.Text, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                , gvSupplierList);
        }

        protected void gvSupplierList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion

        #region Property(ies)

        private void MainButton(bool _btnCreate, bool _btnBack)
        {
            btnSupplier_Create.Visible = _btnCreate;
            btnSupplier_Back.Visible = _btnBack;
        }

        private void NotificationModal(bool _ShowHide, string _HeaderText, string _BodyText, bool _Save, bool _Cancel)
        {
            if (_ShowHide) { modalNotification.Attributes.Add("class", "modal displayShow"); }
            else { modalNotification.Attributes.Add("class", "modal displayHide"); }

            lblSupplierDetails_NotifHeader.Text = _HeaderText;
            lblSupplierDetails_NotifBody.Text = _BodyText;

            btnSupplierDetails_SaveYes.Visible = _Save;
            btnSupplierDetails_CancelYes.Visible = _Cancel;
        }

        private void Clear()
        {
            hfSupplierID.Value = "0";
            txtSupplierDetails_SupplierName.Text = "";
            txtSupplierDetails_ContactPerson.Text = "";
            txtSupplierDetails_ContactNo.Text = "";
            ddlSupplierDetails_PaymentTerms.SelectedValue = "0";
            ddlSupplierDetails_ModeOfPayment.SelectedValue = "0";
            ddlSupplierDetails_Currency.SelectedValue = "0";

            lblSupplierDetails_Alert.Text = "";
        }

        #endregion
    }
}