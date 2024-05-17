using ProjectPSD.Handlers;
using ProjectPSD.Models;
using ProjectPSD.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Controllers
{
    public class UserController
    {
        public static Response<MsUser> ValidateRegister(String name, String dob, String gender, String address, String password, String phone)
        {
            if (name == "" || !(name.Length > 5 && name.Length < 50))
            {
                return new Response<Models.MsUser>()
                {
                    Success = false,
                    Message = "Name must be filled, between 5 and 50 characters",
                    Payload = null
                };
            }else if (dob == "")
            {
                return new Response<Models.MsUser>()
                {
                    Success = false,
                    Message = "DOB must be filled",
                    Payload = null
                };
            }else if (gender == "")
            {
                return new Response<Models.MsUser>()
                {
                    Success = false,
                    Message = "gender must be filled",
                    Payload = null
                };
            }else if (password == "")
            {
                return new Response<Models.MsUser>()
                {
                    Success = false,
                    Message = "password must be filled",
                    Payload = null
                };
            }else if (phone == "")
            {
                return new Response<Models.MsUser>()
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
    }
}