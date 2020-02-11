using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp_FMS_V2.wcfFMSv2;

namespace WebApp_FMS_V2
{
    public partial class VesselType : System.Web.UI.Page
    {
        FMSV2Client wcfService = new FMSV2Client();
        _gControls _gc = new _gControls();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    _gc.DeserializeDataTable(wcfService.Get_VesselType("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                      , gvVesselTypeList);

                    MainButton(true, false);

                    mvVesselType.SetActiveView(vwViewVesselType);
                }
                else { }
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionLogs(_UID, "VesselType", "Page_Load", ex.ToString(), _gc.localComputerName, _gc.GetIPAddress());
                Response.Redirect("Login");
            }
        }


        protected void btnVesselType_Create_Click(object sender, EventArgs e)
        {
            mvVesselType.SetActiveView(vwDetailsVesselType);
            MainButton(false, true);
            Clear();
        }

        protected void btnVesselType_Back_Click(object sender, EventArgs e)
        {
            _gc.DeserializeDataTable(wcfService.Get_VesselType("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                , gvVesselTypeList);

            MainButton(true, false);
            Clear();

            mvVesselType.SetActiveView(vwViewVesselType);
        }


        protected void lnkVesselTypeView_Search_Click(object sender, EventArgs e)
        {
            try
            {
                _gc.DeserializeDataTable(wcfService.Get_VesselType(txtVesselTypeView_Search.Text, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                    , gvVesselTypeList);
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionLogs(_UID, "VesselType", "lnkVesselTypeView_Search_Click", ex.ToString(), _gc.localComputerName, _gc.GetIPAddress());
                Response.Redirect("Login");
            }
        }


        protected void btnVesselTypeDetails_Submit_Click(object sender, EventArgs e)
        {
            if (txtVesselTypeDetails_VesselType.Text != "")
            {
                NotificationModal(true, "Confirmation to Save", "Are you sure you want to save this transaction?", true, false);
            }
            else { lblVesselTypeDetails_Alert.Text = "Code is a required field."; }
        }

        protected void btnVesselTypeDetails_Cancel_Click(object sender, EventArgs e)
        {
            NotificationModal(true, "Confirmation to Cancel", "Are you sure you want to cancel this transaction?", false, true);
        }


        protected void btnVesselTypeDetails_SaveYes_Click(object sender, EventArgs e)
        {
            #region Save

            try
            {
                NotificationModal(false, "", "", false, false);

                //Save Vessel Type
                wcfService.Save_VesselType(_gc.ToInt32(hfVesselTypeID.Value), txtVesselTypeDetails_VesselType.Text
                    , _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"]);

                //Save User Trails
                string _TransType = "";
                _TransType = "Save VesselType - ID: " + hfVesselTypeID.Value + "; VesselType: " + txtVesselTypeDetails_VesselType.Text;

                wcfService.Trails_UserTrails(_gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), _gc.ToInt32(hfVesselTypeID.Value), 0, _TransType);

                //Save Transaction Logs
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionLogs(_UID, "VesselType", "btnVesselTypeDetails_SaveYes_Click", _TransType, _gc.localComputerName, _gc.GetIPAddress());

                lblVesselTypeDetails_Alert.Text = "";
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionLogs(_UID, "VesselType", "btnVesselTypeDetails_SaveYes_Click", ex.ToString(), _gc.localComputerName, _gc.GetIPAddress());
            }
            finally
            {
                _gc.DeserializeDataTable(wcfService.Get_VesselType(txtVesselTypeView_Search.Text, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                    , gvVesselTypeList);

                MainButton(true, false);
                Clear();

                mvVesselType.SetActiveView(vwViewVesselType);
            }

            #endregion
        }

        protected void btnVesselTypeDetails_CancelYes_Click(object sender, EventArgs e)
        {
            NotificationModal(false, "", "", false, false);

            _gc.DeserializeDataTable(wcfService.Get_VesselType("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                , gvVesselTypeList);

            MainButton(true, false);
            Clear();

            mvVesselType.SetActiveView(vwViewVesselType);
        }

        protected void btnVesselTypeDetails_No_Click(object sender, EventArgs e)
        {
            NotificationModal(false, "", "", false, false);
        }

        #region GridView Events

        protected void gvVesselTypeList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int rowindex = Convert.ToInt32(e.CommandArgument) % gvVesselTypeList.PageSize;
                GridViewRow row = gvVesselTypeList.Rows[rowindex];

                if (e.CommandName == "Select")
                {
                    hfVesselTypeID.Value = row.Cells[0].Text;
                    txtVesselTypeDetails_VesselType.Text = row.Cells[1].Text.Replace("&nbsp;", "");

                    mvVesselType.SetActiveView(vwDetailsVesselType);
                    MainButton(false, true);
                }
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionLogs(_UID, "VesselType", "gvVesselTypeList_RowCommand", ex.ToString(), _gc.localComputerName, _gc.GetIPAddress());
            }
        }

        protected void gvVesselTypeList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvVesselTypeList.PageIndex = e.NewPageIndex;
            _gc.DeserializeDataTable(wcfService.Get_VesselType("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                , gvVesselTypeList);
        }

        protected void gvVesselTypeList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion

        #region Property(ies)

        private void MainButton(bool _btnCreate, bool _btnBack)
        {
            btnVesselType_Create.Visible = _btnCreate;
            btnVesselType_Back.Visible = _btnBack;
        }

        private void NotificationModal(bool _ShowHide, string _HeaderText, string _BodyText, bool _Save, bool _Cancel)
        {
            if (_ShowHide) { modalNotification.Attributes.Add("class", "modal displayShow"); }
            else { modalNotification.Attributes.Add("class", "modal displayHide"); }

            lblVesselTypeDetails_NotifHeader.Text = _HeaderText;
            lblVesselTypeDetails_NotifBody.Text = _BodyText;

            btnVesselTypeDetails_SaveYes.Visible = _Save;
            btnVesselTypeDetails_CancelYes.Visible = _Cancel;
        }

        private void Clear()
        {
            hfVesselTypeID.Value = "0";
            txtVesselTypeDetails_VesselType.Text = "";

            lblVesselTypeDetails_Alert.Text = "";
        }

        #endregion
    }
}