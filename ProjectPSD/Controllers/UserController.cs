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
            }
            else if (address == "")
            {
                return new Response<MsUser>()
                {
                    Success = false,
                    Message = "address must be filled",
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
            }
            else
            {
                return UserHandler.HandleRegister(name, dateOfBirth, gender, address, password, phone);
            }
        }

        public static Response<MsUser> ValidateUpdateProfile(int uid, String name, String dob, String gender, String address, String password, String phone)
        {
            if (name == "" || !(name.Length >= 5 && name.Length <= 50))
            {
                return new Response<MsUser>()
                {
                    Success = false,
                    Message = "Name must be filled, between 5 and 50 characters",
                    Payload = null
                };
            }
            else if (dob == "")
            {
                return new Response<MsUser>()
                {
                    Success = false,
                    Message = "DOB must be filled",
                    Payload = null
                };
            }
            else if (address == "")
            {
                return new Response<MsUser>()
                {
                    Success = false,
                    Message = "address must be filled",
                    Payload = null
                };
            }
            else if (password == "")
            {
                return new Response<MsUser>()
                {
                    Success = false,
                    Message = "password must be filled",
                    Payload = null
                };
            }
            else if (phone == "")
            {
                return new Response<MsUser>()
                {
                    Success = false,
                    Message = "phone must be filled",
                    Payload = null
                };
            }
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
            }
            else
            {
                return UserHandler.HandleUpdate(uid, name, dateOfBirth, gender, address, password, phone);
            }
        }

        private static bool IsAlphanumeric(string input)
        {
            return input.All(char.IsLetterOrDigit);
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