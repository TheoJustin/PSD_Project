using ProjectPSD.Controllers;
using ProjectPSD.Models;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                String id = Request.QueryString["id"];
                MsStationery msStationery = StationeryController.ReadStationeryById(id);
                if (msStationery != null)
                {
                    StationeryNameLbl.Text = msStationery.StationeryName;
                    StationeryPriceLbl.Text = msStationery.StationeryPrice.ToString();
                }
            }
        }
    }
}