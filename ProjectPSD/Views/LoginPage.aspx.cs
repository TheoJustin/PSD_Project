using ProjectPSD.Controllers;
using ProjectPSD.Models;
using ProjectPSD.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace ProjectPSD.Views
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            errorMsg.ForeColor = System.Drawing.Color.Red;
        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            String username = NameTB.Text;
            String password = PasswordTB.Text;
            Response<MsUser> response = UserController.ValidateLogin(username, password, RememberCB.Checked);

            if (response.Success)
            {
                Response.Redirect("~/Views/HomePage.aspx");
            }
            else
            {
                errorMsg.Text = response.Message;
            }
        }
    }
}