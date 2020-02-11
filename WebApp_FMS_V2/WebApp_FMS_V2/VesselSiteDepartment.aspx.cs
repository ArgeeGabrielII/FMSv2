using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp_FMS_V2.wcfFMSv2;

namespace WebApp_FMS_V2
{
    public partial class VesselSiteDept : System.Web.UI.Page
    {
        FMSV2Client wcfService = new FMSV2Client();
        _gControls _gc = new _gControls();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    _gc.DeserializeDataTable(wcfService.Get_VesselDepartment("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                          , gvVesselDeptList);

                    _gc.DeserializeDropDownList(wcfService.Get_VesselType("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"]), "VesselTypes", "VesselTypeID", ddlVesselDeptDetails_Type);
                    _gc.DeserializeDropDownList(wcfService.Get_FlagRegistration("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"]), "FlagName", "FlagID", ddlVesselDeptDetails_FlagRegistration);

                    MainButton(true, false);

                    mvVesselDept.SetActiveView(vwViewVesselDept);
                }
                else { }
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionLogs(_UID, "VesselSiteDepartment", "Page_Load", ex.ToString(), _gc.localComputerName, _gc.GetIPAddress());
                Response.Redirect("Login");
            }
        }


        protected void btnVesselDept_Create_Click(object sender, EventArgs e)
        {
            mvVesselDept.SetActiveView(vwDetailsVesselDept);
            MainButton(false, true);
            Clear();
        }

        protected void btnVesselDept_Back_Click(object sender, EventArgs e)
        {
            _gc.DeserializeDataTable(wcfService.Get_VesselDepartment("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                          , gvVesselDeptList);

            MainButton(true, false);
            Clear();

            mvVesselDept.SetActiveView(vwViewVesselDept);
        }


        protected void btnVesselDeptDetails_Save_Click(object sender, EventArgs e)
        {
            if (txtVesselDeptDetails_Code.Text != "")
            {
                if (txtVesselDeptDetails_Name.Text != "")
                {
                    NotificationModal(true, "Confirmation to Save", "Are you sure you want to save this transaction?", true, false);
                }
                else { lblVesselDeptDetails_Alert.Text = "Vessel/Department Name is a required field."; }
            }
            else { lblVesselDeptDetails_Alert.Text = "Vessel/Department Code is a required field."; }
        }

        protected void btnVesselDeptDetails_Cancel_Click(object sender, EventArgs e)
        {
            NotificationModal(true, "Confirmation to Cancel", "Are you sure you want to cancel this transaction?", true, false);
        }


        protected void btnVesselDeptDetails_SaveYes_Click(object sender, EventArgs e)
        {
            #region Save

            try
            {
                NotificationModal(false, "", "", false, false);

                //Save Vessel Department
                wcfService.Save_VesselDepartment(_gc.ToInt32(hfVesselDeptID.Value), txtVesselDeptDetails_Code.Text, txtVesselDeptDetails_Name.Text, ddlVesselDeptDetails_Type.SelectedValue
                    , ddlVesselDeptDetails_FlagRegistration.SelectedValue, chkVesselDeptDetails_Active.Checked, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"]);

                //Save User Trails
                string _TransType = "";
                _TransType = "Save VesselDepartment - VesselCode: " + txtVesselDeptDetails_Code.Text + "; VesselName: " + txtVesselDeptDetails_Name.Text + "; VesselType: " + ddlVesselDeptDetails_Type.SelectedValue
                    + "; FlagRegistration: " + ddlVesselDeptDetails_FlagRegistration.SelectedValue + "; Active: " + chkVesselDeptDetails_Active.Checked.ToString();

                wcfService.Trails_UserTrails(_gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), _gc.ToInt32(hfVesselDeptID.Value), 0, _TransType);

                //Save Transaction Logs
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionLogs(_UID, "VesselSiteDepartment", "btnVesselDeptDetails_SaveYes_Click", _TransType, _gc.localComputerName, _gc.GetIPAddress());

                lblVesselDeptDetails_Alert.Text = "";
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionLogs(_UID, "VesselSiteDepartment", "btnVesselDeptDetails_SaveYes_Click", ex.ToString(), _gc.localComputerName, _gc.GetIPAddress());
            }
            finally
            {
                _gc.DeserializeDataTable(wcfService.Get_VesselDepartment("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                          , gvVesselDeptList);

                MainButton(true, false);
                Clear();

                mvVesselDept.SetActiveView(vwViewVesselDept);
            }

            #endregion
        }

        protected void btnVesselDeptDetails_CancelYes_Click(object sender, EventArgs e)
        {
            NotificationModal(false, "", "", false, false);

            _gc.DeserializeDataTable(wcfService.Get_VesselDepartment("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                          , gvVesselDeptList);

            MainButton(true, false);
            Clear();

            mvVesselDept.SetActiveView(vwViewVesselDept);
        }

        protected void btnVesselDeptDetails_No_Click(object sender, EventArgs e)
        {
            NotificationModal(false, "", "", false, false);
        }

        #region GridView Events

        protected void lnkVesselDept_Search_Click(object sender, EventArgs e)
        {
            try
            {
                _gc.DeserializeDataTable(wcfService.Get_VesselDepartment(txtVesselDept_Search.Text, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                          , gvVesselDeptList);
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionLogs(_UID, "VesselSiteDepartment", "lnkVesselDept_Search_Click", ex.ToString(), _gc.localComputerName, _gc.GetIPAddress());
                Response.Redirect("Login");
            }
        }

        protected void gvVesselDeptList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int rowindex = Convert.ToInt32(e.CommandArgument) % gvVesselDeptList.PageSize;
                GridViewRow row = gvVesselDeptList.Rows[rowindex];

                if (e.CommandName == "Select")
                {
                    hfVesselDeptID.Value = row.Cells[0].Text;
                    txtVesselDeptDetails_Code.Text = row.Cells[1].Text;
                    txtVesselDeptDetails_Name.Text = row.Cells[2].Text;
                    ddlVesselDeptDetails_Type.SelectedValue = row.Cells[3].Text;
                    ddlVesselDeptDetails_FlagRegistration.SelectedValue = row.Cells[5].Text;
                    chkVesselDeptDetails_Active.Checked = _gc.Load_CheckBox(row.Cells[7].Text);

                    mvVesselDept.SetActiveView(vwDetailsVesselDept);
                    MainButton(false, true);
                }
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionLogs(_UID, "VesselSiteDepartment", "gvSupplierList_RowCommand", ex.ToString(), _gc.localComputerName, _gc.GetIPAddress());
            }
        }

        protected void gvVesselDeptList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvVesselDeptList.PageIndex = e.NewPageIndex;
            _gc.DeserializeDataTable(wcfService.Get_VesselDepartment("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                          , gvVesselDeptList);
        }

        protected void gvVesselDeptList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion

        #region Property(ies)

        private void MainButton(bool _btnCreate, bool _btnBack)
        {
            btnVesselDept_Create.Visible = _btnCreate;
            btnVesselDept_Back.Visible = _btnBack;
        }

        private void NotificationModal(bool _ShowHide, string _HeaderText, string _BodyText, bool _Save, bool _Cancel)
        {
            if (_ShowHide) { modalNotification.Attributes.Add("class", "modal displayShow"); }
            else { modalNotification.Attributes.Add("class", "modal displayHide"); }

            lblVesselDeptDetails_NotifHeader.Text = _HeaderText;
            lblVesselDeptDetails_NotifBody.Text = _BodyText;

            btnVesselDeptDetails_SaveYes.Visible = _Save;
            btnVesselDeptDetails_CancelYes.Visible = _Cancel;
        }

        private void Clear()
        {
            hfVesselDeptID.Value = "";
            txtVesselDeptDetails_Code.Text = "";
            txtVesselDeptDetails_Name.Text = "";
            ddlVesselDeptDetails_Type.SelectedValue = "0";
            ddlVesselDeptDetails_FlagRegistration.SelectedValue = "0";
            chkVesselDeptDetails_Active.Checked = true;

            lblVesselDeptDetails_Alert.Text = "";
        }

        #endregion


    }
}