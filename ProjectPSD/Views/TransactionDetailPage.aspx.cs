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

                if (userCookie != null)
                {
                    string transactionID = Request.QueryString["id"];
                    MsUser user = UserController.ReadUserByName(userCookie["Username"]);
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