using ProjectPSD.Factories;
using ProjectPSD.Models;
using ProjectPSD.Modules;
using ProjectPSD.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace ProjectPSD.Handlers
{
    public class UserHandler
    {
        // Method to check if a string is alphanumeric
        private static bool IsAlphanumeric(string input)
        {
            return input.All(char.IsLetterOrDigit);
        }


        public static Response<MsUser> HandleRegister(String name, DateTime dob, String gender, String address, String password, String phone)
        {
            if (!UserRepository.CheckNameIsUnique(name))
            {
                return new Response<MsUser>()
                {
                    Success = false,
                    Message = "Name must be unique",
                    Payload = null
                };
            }
            else
            {
                MsUser user = UserFactory.Create(UserRepository.GenerateUserID(), name, gender, dob, phone, password, address, "customer");
                UserRepository.addUser(user);


                return new Response<MsUser>()
                {
                    Success = true,
                    Message = "",
                    Payload = null
                };
            }
        }

        public static Response<MsUser> HandleUpdate(int uid, String name, DateTime dob, String gender, String address, String password, String phone)
        {
            if (!UserRepository.CheckNameIsUniqueUpdate(name, uid))
            {
                return new Response<MsUser>()
                {
                    Success = false,
                    Message = "Name must be unique",
                    Payload = null
                };
            }
            else
            {
                UserRepository.UpdateUser(uid, name, dob, gender, address, password, phone);
                return new Response<MsUser>()
                {
                    Success = true,
                    Message = "",
                    Payload = null
                };
            }
        }

        public static Response<MsUser> HandleLogin(string username, string password, bool rememberMe)
        {
            MsUser user = UserRepository.CheckUserLogin(username, password);
            if (user == null)
            {
                return new Response<MsUser>()
                {
                    Success = false,
                    Message = "Username or password is incorrect",
                    Payload = null
                };
            }else
            {
                if (rememberMe)
                {
                    HttpCookie cookie = new HttpCookie("User_Cookie");
                    cookie["Username"] = username;
                    cookie["Password"] = password;
                    cookie.Expires = DateTime.Now.AddHours(1);
                    HttpContext.Current.Response.Cookies.Add(cookie);
                }
                else
                {
                    HttpCookie cookie = new HttpCookie("User_Cookie");
                    cookie["Username"] = username;
                    cookie["Password"] = password;
                    cookie.Expires = DateTime.Now.AddMinutes(10);
                    HttpContext.Current.Response.Cookies.Add(cookie);
                }
                HttpContext.Current.Session["User_Session"] = user;
                return new Response<MsUser>()
                {
                    Success = true,
                    Message = "",
                    Payload = user
                };
            }
        }

        public static MsUser HandleReadUserByName(string name)
        {
            return UserRepository.GetUserByName(name);
        }

    }
}