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
        protected void Page_Load(object sender, EventArgs e)
        {

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
            Response.Redirect("~/Views/TransactionPage.aspx");
        }

        protected void UpdateProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/UpdateProfilePage.aspx");
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Response.Cookies["User_Cookie"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("~/Views/LoginPage.aspx");
        }
    }
}