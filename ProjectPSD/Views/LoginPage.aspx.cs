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
            HttpCookie cookie = Request.Cookies["User_Cookie"];
            MsUser user = null;
            if (Session["User_Session"] != null)
            {
                user = Session["User_Session"] as MsUser;
            }
            else if (cookie != null)
            {
                user = UserController.ReadUserByName(cookie["Username"]);
                Session["User_Session"] = user;
            }
            if (user != null)
            {
                Response.Redirect("~/Views/HomePage.aspx");
            }
            errorMsg.ForeColor = System.Drawing.Color.Red;
        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            String username = NameTB.Text;
            String password = PasswordTB.Text;
            Response<MsUser> response = UserController.ValidateLogin(username, password, RememberCB.Checked);

            if (response.Success)
            {
                //errorMsg.Text = (response.Payload as MsUser).UserName;
                Response.Redirect("~/Views/HomePage.aspx");
            }
            else
            {
                errorMsg.Text = response.Message;
            }
        }
    }
}