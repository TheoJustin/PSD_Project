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
        }

        protected void UpdateRow(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = StationeryGV.Rows[e.NewEditIndex];
            String index = row.Cells[0].Text;
            Response.Redirect("~/Views/StationeryDetail.aspx?id=" + index);
        }

        protected void InsertBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/InsertStationeryPage.aspx");
        }

        protected void StationeryGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = StationeryGV.SelectedRow;
            string stationeryId = row.Cells[0].Text;
            Response.Redirect($"~/Views/StationeryDetail.aspx?id={stationeryId}");
        }
    }
}