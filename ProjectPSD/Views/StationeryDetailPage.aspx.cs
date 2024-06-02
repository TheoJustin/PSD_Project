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
    public partial class StationeryDetail : System.Web.UI.Page
    {
        //String id = null;
        //MsUser user = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                String id = Request.QueryString["id"];
                if(id == null)
                {
                    Response.Redirect("~/Views/HomePage.aspx");
                }
                HttpCookie userCookie = Request.Cookies["User_Cookie"];
                MsUser user = null;
                if (Session["User_Session"] != null)
                {
                    user = Session["User_Session"] as MsUser;
                }
                else if (userCookie != null)
                {
                    user = UserController.ReadUserByName(userCookie["Username"]);
                }
                if (user != null && user.UserRole == "customer")
                {
                    ShowActions();
                    // if this item mis already on user's cart, will be redirected to update the cart instead of the details
                    Cart cart = CartController.ReadCartById(user.UserID.ToString(), id);
                    if(cart != null)
                    {
                        Response.Redirect("~/Views/UpdateCartPage.aspx?sid=" + id + "&uid=" + user.UserID.ToString());
                    }
                }
                else
                {
                    HideActions();
                }
                MsStationery msStationery = StationeryController.ReadStationeryById(id);
                if (msStationery != null)
                {
                    StationeryNameLbl.Text = msStationery.StationeryName;
                    StationeryPriceLbl.Text = msStationery.StationeryPrice.ToString();
                }
                else
                {
                    Response.Redirect("~/Views/HomePage.aspx");
                }
            }
        }

        protected void AddToCartBtn_Click(object sender, EventArgs e)
        {
            String id = Request.QueryString["id"];
            HttpCookie userCookie = Request.Cookies["User_Cookie"];
            string username = userCookie["Username"];
            MsUser user = UserController.ReadUserByName(username);

            string quantity = QtyTB.Text;
            Response<Cart> response = CartController.ValidateCartInsertion(user.UserID, Int32.Parse(id), quantity);

            if(response.Success == true)
            {
                Response.Redirect("~/Views/CartPage.aspx");
            }
            else
            {
                errorMsg.Text = response.Message;
            }
        }

        protected void ShowActions()
        {

            QtyTB.Visible = true;
            QtyLbl.Visible = true;
            AddToCartBtn.Visible = true;
        }
        protected void HideActions()
        {
            QtyTB.Visible = false;
            QtyLbl.Visible = false;
            AddToCartBtn.Visible = false;
        }
    }
}