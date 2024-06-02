using ProjectPSD.Controllers;
using ProjectPSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectPSD.Views
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<MsStationery> msStationeries = StationeryController.ReadStationery();
            StationeryGV.DataSource = msStationeries;
            StationeryGV.DataBind();
            HttpCookie cookie = Request.Cookies["User_Cookie"];
            MsUser user = null;
            if (Session["User_Session"] != null)
            {
                user = Session["User_Session"] as MsUser;
            }
            else if (cookie != null)
            {
                user = UserController.ReadUserByName(cookie["Username"]);
                Session["User_Session"] = user;
            }
            if (user == null || user.UserRole != "admin")
            {
                InsertBtn.Visible = false;
                StationeryGV.Columns[3].Visible = false;
            }
            else if(user.UserRole == "customer")
            {
                InsertBtn.Visible = true;
                StationeryGV.Columns[3].Visible = true;
            }
        }

        protected void UpdateRow(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = StationeryGV.Rows[e.NewEditIndex];
            String index = row.Cells[0].Text;
            Response.Redirect("~/Views/UpdateStationeryPage.aspx?id=" + index);
        }

        protected void InsertBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/InsertStationeryPage.aspx");
        }

        protected void StationeryGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = StationeryGV.SelectedRow;
            string stationeryId = row.Cells[0].Text;
            Response.Redirect($"~/Views/StationeryDetailPage.aspx?id={stationeryId}");
        }
    }
}