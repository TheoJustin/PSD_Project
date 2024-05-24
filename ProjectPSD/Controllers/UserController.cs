using ProjectPSD.Handlers;
using ProjectPSD.Models;
using ProjectPSD.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Web;
using System.Xml.Linq;

namespace ProjectPSD.Controllers
{
    public class UserController
    {
        public static Response<MsUser> ValidateRegister(String name, String dob, String gender, String address, String password, String phone)
        {
            if (name == "" || !(name.Length >= 5 && name.Length <= 50))
            {
                return new Response<MsUser>()
                {
                    Success = false,
                    Message = "Name must be filled, between 5 and 50 characters",
                    Payload = null
                };
            }else if (dob == "")
            {
                return new Response<MsUser>()
                {
                    Success = false,
                    Message = "DOB must be filled",
                    Payload = null
                };
            }else if (gender == "")
            {
                return new Response<MsUser>()
                {
                    Success = false,
                    Message = "gender must be filled",
                    Payload = null
                };
            }else if (password == "")
            {
                return new Response<MsUser>()
                {
                    Success = false,
                    Message = "password must be filled",
                    Payload = null
                };
            }else if (phone == "")
            {
                return new Response<MsUser>()
                {
                    Success = false,
                    Message = "phone must be filled",
                    Payload = null
                };
            }
            else
            {
                return UserHandler.HandleRegister(name, dob, gender, address, password, phone);
            }
        }

        public static Response<MsUser> ValidateLogin(string username, string password, bool rememberMe)
        {
            if (username == "")
            {
                return new Response<MsUser>()
                {
                    Success = false,
                    Message = "Username must be filled",
                    Payload = null
                };
            }
            else if (password == "")
            {
                return new Response<MsUser>()
                {
                    Success = false,
                    Message = "Password must be filled",
                    Payload = null
                };
            }
            else
            {
                return UserHandler.HandleLogin(username, password, rememberMe);
            }
        }



        public static MsUser ReadUserByName(string name)
        {
            return UserHandler.HandleReadUserByName(name);
        }
        public static MsUser ReadUserFromCookie(HttpCookie cookie)
        {
            return UserHandler.HandleReadUserByName(cookie["Username"]);
        }
    }
}