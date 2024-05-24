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
        String id = null;
        MsUser user = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                id = Request.QueryString["id"];
                HttpCookie userCookie = Request.Cookies["User_Cookie"];
                if(userCookie != null)
                {
                    user = UserController.ReadUserByName(userCookie["Username"]);
                    if (user != null && user.UserRole == "customer")
                    {
                        ShowActions();
                    }
                    else
                    {
                        HideActions();
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
            }
        }

        protected void AddToCartBtn_Click(object sender, EventArgs e)
        {
            //String id = Request.QueryString["id"];
            //HttpCookie userCookie = Request.Cookies["UserInfo"];
            //string username = userCookie["Username"];
            //MsUser user = UserController.ReadUserByName(username);

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