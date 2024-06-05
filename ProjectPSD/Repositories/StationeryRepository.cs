using ProjectPSD.Factories;
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

        public static MsStationery GetStationeryByID(int id)
        {
            MsStationery stationery = db.MsStationeries.Find(id);
            return stationery;
        }

        public static int GetLastStationeryID()
        {
            // harus pake ? supaya dia bakal return null kalo gaada
            // kalau kita gapake ? maka bakal return empty rather than null

            int? lastID = db.MsStationeries.Max(x => (int?)x.StationeryID);

            if(lastID == null)
            {
                return 0;
            }
            else
            {
                return lastID.Value;
            }
        }

        public static void InsertStationery(int id, string name, int price)
        {
            MsStationery stationery = MsStationeryFactory.Create(id, name, price);
            db.MsStationeries.Add(stationery);
            db.SaveChanges();
        }

        public static void UpdateStationeryByID(int id, String name, int price)
        {
            MsStationery stationery = GetStationeryByID(id);
            stationery.StationeryName = name;
            stationery.StationeryPrice = price;
            db.SaveChanges();
        }

        public static void RemoveStationery(int id)
        {
            MsStationery stationery = GetStationeryByID(id);
            db.MsStationeries.Remove(stationery);
            db.SaveChanges();
        }

        
    }
}