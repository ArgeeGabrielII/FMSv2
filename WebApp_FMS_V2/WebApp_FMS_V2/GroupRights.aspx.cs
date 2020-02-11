using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp_FMS_V2.wcfFMSv2;

namespace WebApp_FMS_V2
{
    public partial class GroupRights : System.Web.UI.Page
    {
        FMSV2Client wcfService = new FMSV2Client();
        _gControls _gc = new _gControls();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    _gc.DeserializeDropDownList(wcfService.Get_UserGroups("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                        , "GroupName", "GroupID", ddlGroupRights_Selection);


                    _gc.DeserializeDataTable(wcfService.Get_GroupRights_Requisition(ddlGroupRights_Selection.SelectedValue, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase))
                        , (string)Session["tID"]), gvGroupRights_Requestition);
                    _gc.DeserializeDataTable(wcfService.Get_GroupRights(ddlGroupRights_Selection.SelectedValue, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase))
                        , (string)Session["tID"]), gvGroupRights);
                }
                else { }
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionLogs(_UID, "GroupRights", "Page_Load", ex.ToString(), _gc.localComputerName, _gc.GetIPAddress());
                Response.Redirect("Login");
            }
        }


        protected void ddlGroupRights_Selection_SelectedIndexChanged(object sender, EventArgs e)
        {
            _gc.DeserializeDataTable(wcfService.Get_GroupRights(ddlGroupRights_Selection.SelectedValue, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase))
                , (string)Session["tID"]), gvGroupRights);
            _gc.DeserializeDataTable(wcfService.Get_GroupRights_Requisition(ddlGroupRights_Selection.SelectedValue, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase))
                , (string)Session["tID"]), gvGroupRights_Requestition);
        }

        protected void btnGroupRights_Submit_Click(object sender, EventArgs e)
        {
            if (ddlGroupRights_Selection.SelectedValue != "0")
            {
                NotificationModal(true, "Confirmation to Save", "Are you sure you want to save this transaction?");
            }
        }


        protected void btnGroupRights_SaveYes_Click(object sender, EventArgs e)
        {
            #region Save

            try
            {
                NotificationModal(false, "", "");
                string _TransType = "";
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                foreach (GridViewRow row in gvGroupRights.Rows)
                {
                    #region Group Rights

                    Label lblGroupRightID = ((Label)row.FindControl("lblGroupRightID"));
                    Label lblGroupID = ((Label)row.FindControl("lblGroupID"));
                    Label lblModuleID = ((Label)row.FindControl("lblModuleID"));
                    Label lblModuleName = ((Label)row.FindControl("lblModuleName"));
                    CheckBox chkCanView = ((CheckBox)row.FindControl("chkCanView"));
                    CheckBox chkCanEdit = ((CheckBox)row.FindControl("chkCanEdit"));
                    CheckBox chkCanDelete = ((CheckBox)row.FindControl("chkCanDelete"));

                    //Save User Group
                    wcfService.Save_GroupRights(Convert.ToInt32(lblGroupRightID.Text), Convert.ToInt32(lblGroupID.Text), Convert.ToInt32(lblModuleID.Text), chkCanView.Checked
                        , chkCanEdit.Checked, chkCanDelete.Checked, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"]);

                    //Save User Trails
                    _TransType = "Save Group Rights - ModuleName: " + lblModuleName.Text + "; CanView: " + chkCanView.Checked.ToString() + "; CanEdit: " + chkCanEdit.Checked.ToString() + "; CanDelete: " + chkCanDelete.Checked.ToString();

                    wcfService.Trails_UserTrails(_UID, _gc.ToInt32(lblGroupID.Text), _gc.ToInt32(lblGroupRightID.Text), _TransType);

                    //Save Transaction Logs
                    wcfService.Save_TransactionLogs(_UID, "GroupRights", "btnGroupRights_SaveYes_Click", _TransType, _gc.localComputerName, _gc.GetIPAddress());

                    #endregion
                }

                foreach (GridViewRow row in gvGroupRights_Requestition.Rows)
                {
                    #region Group Rights Requisition

                    Label lblGroupRightRequestID = ((Label)row.FindControl("lblGroupRightRequestID"));
                    Label lblGroupID = ((Label)row.FindControl("lblGroupID"));
                    Label lblRequestProcessID = ((Label)row.FindControl("lblRequestProcessID"));
                    Label lblRequestProcessName = ((Label)row.FindControl("lblRequestProcessName"));
                    CheckBox chkCanView = ((CheckBox)row.FindControl("chkCanView"));
                    CheckBox chkCanEdit = ((CheckBox)row.FindControl("chkCanEdit"));

                    //Save User Group Requisition
                    wcfService.Save_GroupRights_Requisition(Convert.ToInt32(lblGroupRightRequestID.Text), Convert.ToInt32(lblGroupID.Text), Convert.ToInt32(lblRequestProcessID.Text)
                        , chkCanView.Checked, chkCanEdit.Checked, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"]);

                    //Save User Trails

                    _TransType = "Save Group Rights Requisition - RequestProcessName: " + lblRequestProcessName.Text + "; CanView: " + chkCanView.Checked.ToString() + "; CanEdit: " + chkCanEdit.Checked.ToString();

                    wcfService.Trails_UserTrails(_UID, _gc.ToInt32(lblGroupID.Text), _gc.ToInt32(lblGroupRightRequestID.Text), _TransType);

                    //Save Transaction Logs
                    wcfService.Save_TransactionLogs(_UID, "GroupRightsRequisition", "btnGroupRights_SaveYes_Click", _TransType, _gc.localComputerName, _gc.GetIPAddress());

                    #endregion
                }
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionLogs(_UID, "GroupRights", "btnGroupRights_SaveYes_Click", ex.ToString(), _gc.localComputerName, _gc.GetIPAddress());
            }
            finally
            {
                _gc.DeserializeDataTable(wcfService.Get_GroupRights(ddlGroupRights_Selection.SelectedValue, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                    , gvGroupRights);
            }
            
            #endregion
        }

        protected void btnGroupRights_No_Click(object sender, EventArgs e)
        {
            NotificationModal(false, "", "");
        }

        #region GridView Events

        protected void gvGroupRights_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvGroupRights_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void gvGroupRights_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void gvGroupRights_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        #endregion

        #region Properties

        private void NotificationModal(bool _ShowHide, string _HeaderText, string _BodyText)
        {
            if (_ShowHide) { modalNotification.Attributes.Add("class", "modal displayShow"); }
            else { modalNotification.Attributes.Add("class", "modal displayHide"); }

            lblGroupRights_NotifHeader.Text = _HeaderText;
            lblGroupRights_NotifBody.Text = _BodyText;
        }
        
        #endregion
    }
}