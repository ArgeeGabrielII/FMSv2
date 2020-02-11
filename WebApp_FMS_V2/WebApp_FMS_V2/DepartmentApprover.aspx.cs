using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp_FMS_V2.wcfFMSv2;

namespace WebApp_FMS_V2
{
    public partial class DepartmentApprover : System.Web.UI.Page
    {
        FMSV2Client wcfService = new FMSV2Client();
        _gControls _gc = new _gControls();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    //Load Data
                    _gc.DeserializeDataTable(wcfService.Get_Departments("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                        , gvDeptApproverList);

                    _gc.DeserializeDropDownList(wcfService.Get_DepartmentApprover("Manila", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                        , "Name", "UserID", ddlDeptApproverDetails_ManilaApprover1);
                    _gc.DeserializeDropDownList(wcfService.Get_DepartmentApprover("Manila", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                        , "Name", "UserID", ddlDeptApproverDetails_ManilaApprover2);
                    _gc.DeserializeDropDownList(wcfService.Get_DepartmentApprover("GenSan", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                        , "Name", "UserID", ddlDeptApproverDetails_GenSanApprover1);
                    _gc.DeserializeDropDownList(wcfService.Get_DepartmentApprover("GenSan", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                        , "Name", "UserID", ddlDeptApproverDetails_GenSanApprover2);


                    MainButton(true, false);

                    mvDeptApproverList.SetActiveView(vwViewDeptApproverList);
                }
                else { }
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionLogs(_UID, "DepartmentApprover", "Page_Load", ex.ToString(), _gc.localComputerName, _gc.GetIPAddress());
                Response.Redirect("Login");
            }
        }


        protected void btnDeptApprover_Create_Click(object sender, EventArgs e)
        {
            mvDeptApproverList.SetActiveView(vwDetailsDeptApproverList);
            MainButton(false, true);
            Clear();
        }

        protected void btnDeptApprover_Back_Click(object sender, EventArgs e)
        {
            mvDeptApproverList.SetActiveView(vwViewDeptApproverList);
            MainButton(true, false);
            Clear();
        }


        protected void btnDeptApproverDetails_Submit_Click(object sender, EventArgs e)
        {
            if (txtDeptApproverDetails_DepartmentName.Text != "")
            {
                NotificationModal(true, "Confirmation to Save", "Are you sure you want to save this transaction?", true, false);
            }
            else { lblDeptApproverDetails_Alert.Text = "Department Name is a required field."; }
        }

        protected void btnDeptApproverDetails_Cancel_Click(object sender, EventArgs e)
        {
            NotificationModal(true, "Confirmation to Cancel", "Are you sure you want to cancel this transaction?", false, true);
        }


        protected void btnDeptApproverDetails_SaveYes_Click(object sender, EventArgs e)
        {
            #region Save

            try
            {
                NotificationModal(false, "", "", false, false);

                //Save Department Approver
                wcfService.Save_Department(_gc.ToInt32(hfDeptApproverID.Value), txtDeptApproverDetails_DepartmentName.Text, _gc.ToInt32(ddlDeptApproverDetails_ManilaApprover1.SelectedValue)
                    , _gc.ToInt32(ddlDeptApproverDetails_ManilaApprover2.SelectedValue), _gc.ToInt32(ddlDeptApproverDetails_GenSanApprover1.SelectedValue), _gc.ToInt32(ddlDeptApproverDetails_GenSanApprover2.SelectedValue)
                    , _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"]);

                //Save User Trails
                string _TransType = "";
                _TransType = "Save Department Approver - DeptApproverID: " + hfDeptApproverID.Value + "; DepartmentName: " + txtDeptApproverDetails_DepartmentName.Text + "; MNLApprover1: "
                    + ddlDeptApproverDetails_ManilaApprover1.SelectedValue + "; MNLApprover2: " + ddlDeptApproverDetails_ManilaApprover2.SelectedValue + "; GSApprover1: "
                    + ddlDeptApproverDetails_GenSanApprover1.SelectedValue + "; GSApprover2: " + ddlDeptApproverDetails_GenSanApprover2.SelectedValue;

                wcfService.Trails_UserTrails(_gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), _gc.ToInt32(hfDeptApproverID.Value), 0, _TransType);

                //Save Transaction Logs
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionLogs(_UID, "DepartmentApprover", "btnDeptApproverDetails_SaveYes_Click", _TransType, _gc.localComputerName, _gc.GetIPAddress());

                lblDeptApproverDetails_Alert.Text = "";
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionLogs(_UID, "DepartmentApprover", "btnDeptApproverDetails_SaveYes_Click", ex.ToString(), _gc.localComputerName, _gc.GetIPAddress());
            }
            finally
            {
                _gc.DeserializeDataTable(wcfService.Get_Departments("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                , gvDeptApproverList);

                MainButton(true, false);
                Clear();

                mvDeptApproverList.SetActiveView(vwViewDeptApproverList);
            }

            #endregion
        }

        protected void btnDeptApproverDetails_CancelYes_Click(object sender, EventArgs e)
        {
            NotificationModal(false, "", "", false, false);

            mvDeptApproverList.SetActiveView(vwViewDeptApproverList);
            MainButton(true, false);
            Clear();
        }

        protected void btnDeptApproverDetails_No_Click(object sender, EventArgs e)
        {
            NotificationModal(false, "", "", false, false);
        }

        #region GridView Events

        protected void lnkDeptApproverList_Search_Click(object sender, EventArgs e)
        {
            try
            {
                _gc.DeserializeDataTable(wcfService.Get_Departments(txtApproverList_Search.Text, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                    , gvDeptApproverList);
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionLogs(_UID, "DepartmentApprover", "lnkDeptApproverList_Search_Click", ex.ToString(), _gc.localComputerName, _gc.GetIPAddress());
                Response.Redirect("Login");
            }
        }

        protected void gvDeptApproverList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int rowindex = Convert.ToInt32(e.CommandArgument) % gvDeptApproverList.PageSize;
                GridViewRow row = gvDeptApproverList.Rows[rowindex];

                if (e.CommandName == "Select")
                {
                    txtDeptApproverDetails_DepartmentName.Text = row.Cells[1].Text;
                    ddlDeptApproverDetails_ManilaApprover1.SelectedValue = row.Cells[2].Text;
                    ddlDeptApproverDetails_ManilaApprover2.SelectedValue = row.Cells[3].Text;
                    ddlDeptApproverDetails_GenSanApprover1.SelectedValue = row.Cells[4].Text;
                    ddlDeptApproverDetails_GenSanApprover2.SelectedValue = row.Cells[5].Text;

                    mvDeptApproverList.SetActiveView(vwDetailsDeptApproverList);
                    MainButton(false, true);
                }
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionLogs(_UID, "DepartmentApprover", "gvDeptApproverList_RowCommand", ex.ToString(), _gc.localComputerName, _gc.GetIPAddress());
            }
        }

        protected void gvDeptApproverList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDeptApproverList.PageIndex = e.NewPageIndex;
            _gc.DeserializeDataTable(wcfService.Get_Departments(txtApproverList_Search.Text, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                , gvDeptApproverList);
        }

        protected void gvDeptApproverList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion

        #region Property(ies)

        private void MainButton(bool _btnCreate, bool _btnBack)
        {
            btnDeptApprover_Create.Visible = _btnCreate;
            btnDeptApprover_Back.Visible = _btnBack;
        }

        private void NotificationModal(bool _ShowHide, string _HeaderText, string _BodyText, bool _Save, bool _Cancel)
        {
            if (_ShowHide) { modalNotification.Attributes.Add("class", "modal displayShow"); }
            else { modalNotification.Attributes.Add("class", "modal displayHide"); }

            lblDeptApproverDetails_NotifHeader.Text = _HeaderText;
            lblDeptApproverDetails_NotifBody.Text = _BodyText;

            btnDeptApproverDetails_SaveYes.Visible = _Save;
            btnDeptApproverDetails_CancelYes.Visible = _Cancel;
        }

        private void Clear()
        {
            hfDeptApproverID.Value = "0";
            txtDeptApproverDetails_DepartmentName.Text = "";
            ddlDeptApproverDetails_ManilaApprover1.SelectedValue = "0";
            ddlDeptApproverDetails_ManilaApprover2.SelectedValue = "0";
            ddlDeptApproverDetails_GenSanApprover1.SelectedValue = "0";
            ddlDeptApproverDetails_GenSanApprover2.SelectedValue = "0";

            lblDeptApproverDetails_Alert.Text = "";
        }

        #endregion


    }
}