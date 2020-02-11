using System;
using System.Web.UI;
using WebApp_FMS_V2.wcfFMSv2;
using Newtonsoft.Json;

namespace WebApp_FMS_V2
{
    public partial class Login : System.Web.UI.Page
    {
        FMSV2Client wcfService = new FMSV2Client();
        _gControls _gc = new _gControls();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtLogin_Username.Text = "";
                txtLogin_Password.Text = "";

                Session.Clear();
                txtLogin_Username.Focus();
                lblLogin_Alert.Text = "";
            }
        }

        protected void btnLogin_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                string _jsonResponseUserAccount = wcfService.GetUserPass(txtLogin_Username.Text, txtLogin_Password.Text);

                if (_jsonResponseUserAccount != "")
                {
                    dynamic _jData = JsonConvert.DeserializeObject<dynamic>(_jsonResponseUserAccount);

                    if ((bool)_jData[0].Active == true)
                    {
                        lblLogin_Alert.Text = "Login Successful!";

                        //Sessions and Token
                        Session["UserID"] = _Cypher.Encrypt((string)_jData[0].UserID, _Cypher._PassPhrase);
                        Session["UserName"] = _Cypher.Encrypt((string)_jData[0].UserName, _Cypher._PassPhrase);
                        Session["ClientName"] = _Cypher.Encrypt((string)_jData[0].FirstName + " " + (string)_jData[0].LastName, _Cypher._PassPhrase);
                        Session["GroupID"] = _Cypher.Encrypt((string)_jData[0].GroupID, _Cypher._PassPhrase);
                        Session["DepartmentID"] = _Cypher.Encrypt((string)_jData[0].DepartmentID, _Cypher._PassPhrase);
                        Session["Office"] = _Cypher.Encrypt((string)_jData[0].Office, _Cypher._PassPhrase);
                        Session["tID"] = (string)_jData[0].Token;

                        //User Access Rights
                        UserAccessRights(_gc.ToInt32((string)_jData[0].GroupID));

                        //Page Redirect to Home
                        Response.AddHeader("REFRESH", "0.2;URL=Home");
                    }
                    else { lblLogin_Alert.Text = "Account is Inactive!<br />Please contact your System Administrator"; }
                }
                else { lblLogin_Alert.Text = "Invalid Username or Password"; }
            }
            catch(Exception ex)
            {
                wcfService.Save_TransactionLogs(0, "Login", "btnLogin_Submit_Click", ex.ToString(), _gc.localComputerName, _gc.GetIPAddress());
                Response.Redirect("Login");
            }
        }

        protected void UserAccessRights(int _gID)
        {
            //User Access Rights
            string _jsonResponseUserAccessRights = wcfService.Get_UserAccessRights(_gID);

            if (_jsonResponseUserAccessRights != "")
            {
                dynamic _jData = JsonConvert.DeserializeObject<dynamic>(_jsonResponseUserAccessRights);

                foreach (var _data in _jData)
                {
                    Session["CV_" + (string)_data.ModuleName] = (string)_data.CanView;
                    Session["CE_" + (string)_data.ModuleName] = (string)_data.CanEdit;
                    Session["CD_" + (string)_data.ModuleName] = (string)_data.CanDelete;
                }
            }
        }
    }
}