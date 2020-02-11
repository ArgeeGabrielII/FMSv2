using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp_FMS_V2.wcfFMSv2;

namespace WebApp_FMS_V2
{
    public partial class TransactionLogs : System.Web.UI.Page
    {
        FMSV2Client wcfService = new FMSV2Client();
        _gControls _gc = new _gControls();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    _gc.DeserializeDataTable(wcfService.Get_TransactionLogs("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                    , gvTransactionLogs);
                }
                else { }
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionLogs(_UID, "TransactionLogs", "Page_Load", ex.ToString(), _gc.localComputerName, _gc.GetIPAddress());
                Response.Redirect("Login");
            }
        }

        protected void lnkTransactionLogs_Search_Click(object sender, EventArgs e)
        {
            try
            {
                _gc.DeserializeDataTable(wcfService.Get_TransactionLogs(txtTransactionLogs_Search.Text, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                    , gvTransactionLogs);
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionLogs(_UID, "TransactionLogs", "lnkTransactionLogs_Search_Click", ex.ToString(), _gc.localComputerName, _gc.GetIPAddress());
            }
        }

        protected void gvTransactionLogs_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[5].Text.ToString().Length > 100)
                {
                    e.Row.Cells[5].ToolTip = e.Row.Cells[5].Text;
                    e.Row.Cells[5].Text = e.Row.Cells[5].Text.ToString().Substring(0, 100) + " ... ";
                }
            }
        }

        protected void gvTransactionLogs_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (txtTransactionLogs_Search.Text != "")
            {
                gvTransactionLogs.PageIndex = e.NewPageIndex;
                _gc.DeserializeDataTable(wcfService.Get_TransactionLogs(txtTransactionLogs_Search.Text, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                        , gvTransactionLogs);
            }
            else
            {
                _gc.DeserializeDataTable(wcfService.Get_TransactionLogs("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                    , gvTransactionLogs);
            }
        }
    }
}