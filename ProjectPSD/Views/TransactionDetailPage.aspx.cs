using ProjectPSD.Controllers;
using ProjectPSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Util;

namespace ProjectPSD.Views
{
    public partial class TransactionDetailPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpCookie userCookie = Request.Cookies["User_Cookie"];
                string transactionID = null;
                MsUser user = null;
                if (Session["User_Session"] != null)
                {
                    transactionID = Request.QueryString["id"];
                    user = Session["User_Session"] as MsUser;
                }
                else if (userCookie != null)
                {
                    transactionID = Request.QueryString["id"];
                    user = UserController.ReadUserByName(userCookie["Username"]);
                }
                if(user != null)
                {
                    if (user.UserRole != "customer" || transactionID == null)
                    {
                        Response.Redirect("~/Views/LoginPage.aspx");
                    }
                    List<TransactionDetail> transactionDetails = TransactionController.GetAllTransactionDetailsByID(Convert.ToInt32(transactionID));
                    TransactionDetailsGV.DataSource = transactionDetails;
                    TransactionDetailsGV.DataBind();

                }
                else
                {
                    Response.Redirect("~/Views/LoginPage.aspx");
                }
            }
        }
    }
}