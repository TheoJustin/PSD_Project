using ProjectPSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Repositories
{
    public class UserRepository
    {
        private static RAisoDatabaseEntities db = DBSingleton.GetInstance();

        public static bool CheckNameIsUnique(string name)
        {
            return !db.MsUsers.Any(u => u.UserName == name);
        }
        public static int GenerateUserID()
        {
            int newID = 1;
            if (db.MsUsers.Any())
            {
                int lastID = db.MsUsers.Max(u => u.UserID);
                newID = lastID + 1;
            }

            return newID;
        }

        public static MsUser CheckUserLogin(string userName, string password)
        {
            MsUser user = (from x in db.MsUsers where x.UserName.Equals(userName) select x).FirstOrDefault();
            if(user.UserPassword == password)   
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public static MsUser GetUserByName(string name) 
        {
            MsUser user = (from x in db.MsUsers where x.UserName.Equals(name) select x).FirstOrDefault();
            return user;
        }

        public static void addUser(MsUser user)
        {
            db.MsUsers.Add(user);
            db.SaveChanges();
        }
    }
}