using ProjectPSD.Controllers;
using ProjectPSD.Models;
using ProjectPSD.Modules;
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
                MsUser user = null;
                if (Session["User_Session"] != null)
                {
                    user = Session["User_Session"] as MsUser;
                }
                else if (userCookie != null)
                {
                    string username = userCookie["Username"];
                    user = UserController.ReadUserByName(username);
                }
                if(user != null)
                {
                    if(user.UserRole == "customer")
                    {
                        CartGV.DataSource = CartController.ReadAllCarts(user.UserID);
                        CartGV.DataBind();
                    }
                    else
                    {
                        Response.Redirect("~/Views/LoginPage.aspx");
                    }
                }
                else
                {
                    Response.Redirect("~/Views/HomePage.aspx");
                }
            }
        }

        protected void CartGV_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Cart cart = row.DataItem as Cart;
            String sid = CartGV.DataKeys[e.NewEditIndex]["StationeryId"].ToString();
            String uid = CartGV.DataKeys[e.NewEditIndex]["UserId"].ToString();
            //debug.Text = sid + uid;
            Response.Redirect("~/Views/UpdateCartPage.aspx?sid=" + sid + "&uid=" + uid);
        }

        protected void CartGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            String sid = CartGV.DataKeys[e.RowIndex]["StationeryId"].ToString();
            String uid = CartGV.DataKeys[e.RowIndex]["UserId"].ToString();
            CartController.ControlRemoveFromCart(uid, sid);
            Response.Redirect("~/Views/CartPage.aspx");
        }

        protected void CheckOutButton_Click(object sender, EventArgs e)
        {
            HttpCookie userCookie = Request.Cookies["User_Cookie"];
            MsUser user = UserController.ReadUserByName(userCookie["Username"]);

            Response<string> response = CartController.ControlCheckOut(user.UserID);
            if (response.Success)
            {
                Response.Redirect("~/Views/HomePage.aspx");
            }
            else
            {
                ErrorMsg.Text = response.Message;
            }
        }
    }
}