using ProjectPSD.Controllers;
using ProjectPSD.Models;
using ProjectPSD.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;


namespace ProjectPSD.Views
{
    public partial class InsertPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                errMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void InsertBtn_Click(object sender, EventArgs e)
        {
            Response<MsStationery> response = StationeryController.ValidateStationeryInsertion(NameTB.Text, PriceTB.Text);
            if (response.Success == true)
            {
                Response.Redirect("~/Views/HomePage.aspx");
            }
            else
            {
                errMsg.Text = response.Message;
            }
        }
    }
}