using CrystalDecisions.Web;
using ProjectPSD.Controllers;
using ProjectPSD.Dataset;
using ProjectPSD.Models;
using ProjectPSD.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Util;

namespace ProjectPSD.Views
{
    public partial class TransactionReportPage : System.Web.UI.Page
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
                    Session["User_Session"] = user;
                }
                if (user != null && user.UserRole == "admin")
                {
                    TransactionReport report = new TransactionReport();
                    CrystalReportViewer1.ReportSource = report;
                    List<TransactionHeader> transactionHeaders = TransactionController.ControlGetAllTransactionHeaders();

                    report.SetDataSource(GetData(transactionHeaders));
                }
                else
                {
                    Response.Redirect("~/Views/LoginPage.aspx");
                }
            }
        }
        private TransactionDataset GetData(List<TransactionHeader> transactionHeaders)
        {
            TransactionDataset data = new TransactionDataset();
            var TransactionTable = data.TransactionHeader;
            var DetailTable = data.TransactionDetail;
            foreach (var t in transactionHeaders)
            {
                var hrow = TransactionTable.NewRow();
                hrow["TransactionID"] = t.TransactionID;
                hrow["UserID"] = t.UserID;
                hrow["TransactionDate"] = t.TransactionDate;
                // grand total
                int grandTotal = t.TransactionDetail.Sum(detail => detail.Quantity * detail.MsStationery.StationeryPrice);
                hrow["GrandTotal"] = grandTotal;
                TransactionTable.Rows.Add(hrow);
                foreach (var d in t.TransactionDetail)
                {

                    var drow = DetailTable.NewRow();
                    drow["TransactionID"] = d.TransactionID;
                    drow["StationeryName"] = d.MsStationery.StationeryName;
                    drow["Quantity"] = d.Quantity;
                    drow["StationeryPrice"] = d.MsStationery.StationeryPrice;
                    int subTotal = d.Quantity * d.MsStationery.StationeryPrice;
                    drow["SubTotal"] = subTotal;
                    DetailTable.Rows.Add(drow);
                }
            }
            return data;
        }
    }
}