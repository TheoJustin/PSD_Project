using ProjectPSD.Controllers;
using ProjectPSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectPSD.Layout
{
    public partial class Navbar : System.Web.UI.MasterPage
    {
        MsUser user;
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["User_Cookie"];
            if (Session["User_Session"] != null)
            {
                user = Session["User_Session"] as MsUser;
            }
            else if (cookie != null)
            {
                user = UserController.ReadUserByName(cookie["Username"]);
            }
            if(user != null)
            {
                if (user.UserRole == "customer")
                {
                    Login.Visible = false;
                    Register.Visible = false;
                    Cart.Visible = true;
                    Transaction.Visible = true;
                    UpdateProfile.Visible = true;
                    Logout.Visible = true;
                }
                else if(user.UserRole == "admin")
                {
                    Login.Visible = false;
                    Register.Visible = false;
                    Cart.Visible = false;
                    Transaction.Visible = true;
                    UpdateProfile.Visible = true;
                    Logout.Visible = true;
                }
            }
            else
            {
                Login.Visible = true;
                Register.Visible = true;
                Cart.Visible = false;
                Transaction.Visible = false;
                UpdateProfile.Visible = false;
                Logout.Visible = false;
            }
        }

        protected void Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/HomePage.aspx");
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/LoginPage.aspx");
        }

        protected void Register_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/RegisterPage.aspx");
        }

        protected void Cart_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/CartPage.aspx");
        }

        protected void Transaction_Click(object sender, EventArgs e)
        {
            if(user != null && user.UserRole == "customer")
            {
                Response.Redirect("~/Views/TransactionPage.aspx");

            }
            else if (user != null && user.UserRole == "admin")
            {
                Response.Redirect("~/Views/TransactionReportPage.aspx");
            }
        }

        protected void UpdateProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/UpdateProfilePage.aspx");
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Response.Cookies["User_Cookie"].Expires = DateTime.Now.AddDays(-1);
            Session["User_Session"] = null;
            Session.Abandon();
            Response.Redirect("~/Views/LoginPage.aspx");
        }
    }
}