using ProjectPSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Repositories
{
    public class StationeryRepository
    {
        private static RAisoDatabaseEntities db = DBSingleton.GetInstance();
        public static List<MsStationery> GetStationery()
        {
            return db.MsStationeries.ToList();
        }

        public static MsStationery GetStationeryByID(String id)
        {
            System.Diagnostics.Debug.WriteLine("id " + id);
            System.Diagnostics.Debug.WriteLine("type : " + id.GetType());
            MsStationery stationery = db.MsStationeries.Find(Int32.Parse(id));
            return stationery;
        }
    }
}