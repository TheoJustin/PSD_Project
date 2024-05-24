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
    public partial class UpdateCartPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpCookie cookie = Request.Cookies["User_Cookie"];
                String sid = Request.QueryString["sid"];
                String uid = Request.QueryString["uid"];
                if (cookie != null)
                {
                    MsUser user = UserController.ReadUserByName(cookie["Username"]);
                    if (user == null || sid == null || uid == null)
                    {
                        errorMsg.Text = sid + uid;
                        Response.Redirect("~/Views/HomePage.aspx");
                    }
                }
                Cart cart = CartController.ReadCartById(uid, sid);
                if (cart != null)
                {
                    StationeryName.Text = cart.MsStationery.StationeryName;
                    StationeryPrice.Text = cart.MsStationery.StationeryPrice.ToString();
                    qtyTB.Text = cart.Quantity.ToString();
                }
            }
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            String sid = Request.QueryString["sid"];
            String uid = Request.QueryString["uid"];
            String qty = qtyTB.Text;
            Response<Cart> response = CartController.ValidateCartUpdate(Int32.Parse(uid), Int32.Parse(sid), qty);
            if (response.Success == true)
            {
                Response.Redirect("~/Views/CartPage.aspx");
            }
            else
            {
                errorMsg.Text = response.Message;
            }
        }
    }
}