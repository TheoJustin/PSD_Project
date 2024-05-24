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


        public static Response<MsUser> HandleRegister(String name, String dob, String gender, String address, String password, String phone)
        {
            // Parse the provided DOB string to DateTime
            if (!DateTime.TryParse(dob, out DateTime dateOfBirth))
            {
                return new Response<MsUser>()
                {
                    Success = false,
                    Message = "Invalid DOB format",
                    Payload = null
                };
            }

            TimeSpan ageDifference = DateTime.Now - dateOfBirth;
            int ageInYears = (int)(ageDifference.TotalDays / 365);

            if (ageInYears < 1) // Checks if the age is less than 1 year
            {
                return new Response<MsUser>()
                {
                    Success = false,
                    Message = "User must be at least 1 year old",
                    Payload = null
                };
            }
            else if (!IsAlphanumeric(password)) // Checks if the password is alphanumeric
            {
                return new Response<MsUser>()
                {
                    Success = false,
                    Message = "Password must be alphanumeric",
                    Payload = null
                };
            }else if (!UserRepository.CheckNameIsUnique(name))
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
                MsUser user = UserFactory.Create(UserRepository.GenerateUserID(), name, gender, dateOfBirth, address, password, phone, "customer");
                UserRepository.addUser(user);


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
                // HttpContext.Current.Session["User_Session"] = user;
                return new Response<MsUser>()
                {
                    Success = true,
                    Message = "",
                    Payload = null
                };
            }
        }

        public static MsUser HandleReadUserByName(string name)
        {
            return UserRepository.GetUserByName(name);
        }

    }
}