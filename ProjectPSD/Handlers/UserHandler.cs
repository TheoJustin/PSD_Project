using ProjectPSD.Factories;
using ProjectPSD.Models;
using ProjectPSD.Modules;
using ProjectPSD.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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


                return new Response<Models.MsUser>()
                {
                    Success = true,
                    Message = "",
                    Payload = null
                };
            }
        }
    }
}