using ProjectPSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Repositories
{
    public class DBSingleton
    {
        private DBSingleton() { }
        public static RAisoDatabaseEntities db = null;
        public static RAisoDatabaseEntities GetInstance()
        {
            if(db == null)
            {
                db = new RAisoDatabaseEntities();
            }
            return db;
        }
    }
}