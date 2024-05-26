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
    public partial class UpdateProfilePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpCookie userCookie = Request.Cookies["User_Cookie"];

                if (userCookie != null)
                {
                    string username = userCookie["Username"];
                    MsUser user = UserController.ReadUserByName(username);
                    NameTB.Text = user.UserName;
                    SelectedDateTB.Text = user.UserDOB.ToString("yyyy-MM-dd");
                    RadioButtonListGender.SelectedValue = user.UserGender;
                    AddressTB.Text = user.UserAddress;
                    PhoneTB.Text = user.UserPhone;
                    PasswordTB.Text = user.UserPassword;
                }
                else
                {
                    Response.Redirect("~/Views/LoginPage.aspx");
                }
            }
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            String name = NameTB.Text;
            String dob = SelectedDateTB.Text;
            String gender = RadioButtonListGender.SelectedValue;
            String address = AddressTB.Text;
            String password = PasswordTB.Text;
            String phone = PhoneTB.Text;
            HttpCookie userCookie = Request.Cookies["User_Cookie"];

            if (userCookie != null)
            {
                string username = userCookie["Username"];
                MsUser user = UserController.ReadUserByName(username);
                Response<MsUser> response = UserController.ValidateUpdateProfile(user.UserID, name, dob, gender, address, password, phone);
                if(!response.Success)
                {
                    ErrorMsg.Text = response.Message;
                }
                else
                {
                    Response.Redirect("~/Views/UpdateProfilePage.aspx");
                }
            }
            else
            {
                Response.Redirect("~/Views/LoginPage.aspx");
            }
        }
        protected void DobCalendar_SelectionChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = DobCalendar.SelectedDate;
            SelectedDateTB.Text = selectedDate.ToString("yyyy-MM-dd");
        }
    }
}