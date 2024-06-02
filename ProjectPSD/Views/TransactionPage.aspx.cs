using ProjectPSD.Controllers;
using ProjectPSD.Dataset;
using ProjectPSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectPSD.Views
{
    public partial class TransactionPage : System.Web.UI.Page
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
                if(user != null && user.UserRole == "customer")
                {
                    TransactionGV.DataSource = TransactionController.ControlGetAllTransactionHeaderByUser(user.UserID);
                    TransactionGV.DataBind();
                }
                else
                {
                    Response.Redirect("~/Views/LoginPage.aspx");
                }
            }
        }

        

        protected void TransactionGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = TransactionGV.SelectedRow;
            string transactionID = row.Cells[0].Text;
            Response.Redirect($"~/Views/TransactionDetailPage.aspx?id={transactionID}");
        }
    }
}