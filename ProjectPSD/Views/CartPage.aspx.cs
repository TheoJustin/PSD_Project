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
            if (!IsPostBack)
            {
                HttpCookie userCookie = Request.Cookies["User_Cookie"];

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
            //Cart cart = row.DataItem as Cart;
            String sid = CartGV.DataKeys[e.NewEditIndex]["StationeryId"].ToString();
            String uid = CartGV.DataKeys[e.NewEditIndex]["UserId"].ToString();
            debug.Text = sid + uid;
            Response.Redirect("~/Views/UpdateCartPage.aspx?sid=" + sid + "&uid=" + uid);
        }

        protected void CartGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            String sid = CartGV.DataKeys[e.RowIndex]["StationeryId"].ToString();
            String uid = CartGV.DataKeys[e.RowIndex]["UserId"].ToString();
            CartController.ControlRemoveFromCart(uid, sid);
            Response.Redirect("~/Views/CartPage.aspx");
        }
    }
}