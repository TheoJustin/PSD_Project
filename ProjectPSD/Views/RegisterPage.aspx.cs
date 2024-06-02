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
    public partial class RegisterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["User_Cookie"];
            MsUser user = null;
            if (Session["User_Session"] != null)
            {
                user = Session["User_Session"] as MsUser;
            }
            else if (cookie != null)
            {
                user = UserController.ReadUserByName(cookie["Username"]);
            }
            if (user != null)
            {
                Response.Redirect("~/Views/HomePage.aspx");
            }
        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            String name = NameTB.Text;
            String dob = SelectedDateTB.Text;
            String gender = RadioButtonListGender.SelectedValue;
            String address = AddressTB.Text;
            String password = PasswordTB.Text;
            String phone = PhoneTB.Text;

            Response<MsUser> response = UserController.ValidateRegister(name, dob, gender, address, password, phone);
            if (response.Success)
            {
                Response.Redirect("~/Views/LoginPage.aspx");
            }
            else
            {
                ErrorMsg.Text = response.Message;
            }

        }

        protected void DobCalendar_SelectionChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = DobCalendar.SelectedDate;
            SelectedDateTB.Text = selectedDate.ToString("yyyy-MM-dd");
        }
    }
}