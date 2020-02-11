using System;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WebApp_FMS_V2.wcfFMSv2;

namespace WebApp_FMS_V2
{
    public partial class FMS : System.Web.UI.MasterPage
    {
        string _ClientName;
        FMSV2Client wcfService = new FMSV2Client();
        _gControls _gc = new _gControls();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Get UserAccount FullName
                if (!string.IsNullOrEmpty(Session["tID"] as string) && !string.IsNullOrEmpty(Session["ClientName"] as string))
                {
                    _ClientName = _Cypher.Decrypt(Session["ClientName"].ToString(), _Cypher._PassPhrase);
                    lblUserAccount_Name.Text = "Hello! " + _ClientName;

                    //ViewRights
                }
                else { Response.Redirect("Login"); }
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionLogs(_UID, "FMS.Master", "Page_Load", ex.ToString(), _gc.localComputerName, _gc.GetIPAddress());
                Response.Redirect("Login");
            }
        }

        protected void ViewRights(string _Session, HtmlGenericControl _control)
        {
            if (_Cypher.Decrypt(_Session, _Cypher._PassPhrase) == "True") { _control.Visible = true; } else { _control.Visible = false; }
        }
    }
}