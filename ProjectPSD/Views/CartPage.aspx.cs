using ProjectPSD.Controllers;
using ProjectPSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectPSD.Views
{
    public partial class CartPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                HttpCookie userCookie = Request.Cookies["UserInfo"];

                if (userCookie != null)
                {
                    string username = userCookie["Username"];
                    MsUser user = UserController.ReadUserByName(username);

                    CartGV.DataSource = CartController.ReadAllCarts(user.UserID);
                    CartGV.DataBind();
                }
                else
                {
                    Response.Redirect("~/Views/LoginPage.aspx");
                }
            }
        }

        protected void CartGV_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = CartGV.Rows[e.NewEditIndex];
            String sid = row.Cells[1].Text;
            Response.Redirect("~/Views/UpdateCartPage.aspx?sid=" + sid);
        }

        protected void CartGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}