﻿using ProjectPSD.Controllers;
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
    public partial class UpdateStationeryPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            errorMsg.ForeColor = System.Drawing.Color.Red;

            if (!IsPostBack)
            {
                HttpCookie cookie = Request.Cookies["User_Cookie"];
                String id = Request.QueryString["id"];
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
                if (user == null || user.UserRole != "admin" || id == null)
                {
                    Response.Redirect("~/Views/HomePage.aspx");
                }
                MsStationery msStationery = StationeryController.ReadStationeryById(id);

                if (msStationery != null)
                {
                    NameTB.Text = msStationery.StationeryName;
                    PriceTB.Text = msStationery.StationeryPrice.ToString();
                }
                else
                {
                    Response.Redirect("~/Views/HomePage.aspx");
                }
            }
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            String id = Request.QueryString["id"];
            String name = NameTB.Text;
            String price = PriceTB.Text;
            Response<MsStationery> response = StationeryController.ValidateStationeryUpdate(Int32.Parse(id), name, price);
            if(response.Success == true)
            {
                Response.Redirect("~/Views/HomePage.aspx");
            }
            else
            {
                errorMsg.Text = response.Message;
            }
        }
    }
}