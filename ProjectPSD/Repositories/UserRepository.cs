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

        public static void addUser(MsUser user)
        {
            db.MsUsers.Add(user);
            db.SaveChanges();
        }
    }
}