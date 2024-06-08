using ProjectPSD.Models;
using ProjectPSD.Modules;
using ProjectPSD.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Handlers
{
    public class StationeryHandler
    {
        public static List<MsStationery> HandleReadStationery()
        {
            return StationeryRepository.GetStationery();
        }
        public static MsStationery HandleStationeryByID(String id)
        {
            return StationeryRepository.GetStationeryByID(Int32.Parse(id));
        }

        public static int GenerateStationeryID()
        {
            int lastID = StationeryRepository.GetLastStationeryID() + 1;
            return lastID;
        }

        public static void HandleStationeryInsertion(string name, int price)
        {
            int id = GenerateStationeryID();
            StationeryRepository.InsertStationery(id, name, price);
        }

        public static void HandleStationeryUpdate(int id, string name, int price)
        {
            StationeryRepository.UpdateStationeryByID(id, name, price);
        }

        public static void HandleRemoveStationery(int id)
        {
            MsStationery stationery = StationeryRepository.GetStationeryByID(id);
            if(stationery == null)
            {
                return;
            }
            if(stationery.Carts.Count > 0)
            {
                CartRepository.RemoveCarts(stationery.Carts.ToList());
            }
            if(stationery.TransactionDetails.Count > 0)
            {
                //TransactionRepository.RemoveDetails(stationery.TransactionDetails.ToList());
                TransactionHandler.HandleRemoveDetails(stationery.TransactionDetails.ToList());
            }
            StationeryRepository.RemoveStationery(id);
        }
    }
}