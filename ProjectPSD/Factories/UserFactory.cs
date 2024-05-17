using ProjectPSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Factories
{
    public class UserFactory
    {
        public static MsUser Create(int userId, string userName, string userGender, DateTime userDob, string userPhone,  string userPassword, string userAddress, string userRole)
        {
            MsUser user = new MsUser();
            user.UserID = userId;
            user.UserName = userName;
            user.UserGender = userGender;
            user.UserDOB = userDob;
            user.UserPhone = userPhone;
            user.UserAddress = userAddress;
            user.UserPassword = userPassword;
            user.UserRole = userRole;

            return user;
        }
    }
}