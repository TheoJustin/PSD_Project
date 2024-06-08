using ProjectPSD.Handlers;
using ProjectPSD.Models;
using ProjectPSD.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Controllers
{
    public class StationeryController
    {
        public static List<MsStationery> ReadStationery()
        {
            return StationeryHandler.HandleReadStationery();
        }

        public static MsStationery ReadStationeryById(String id)
        {
            return StationeryHandler.HandleStationeryByID(id);
        }

        public static Response<MsStationery> ValidateStationeryInsertion(string name, string price)
        {
            if (!(name.Length >= 3 && name.Length <= 50))
            {
                return new Response<MsStationery>()
                {
                    Success = false,
                    Message = "Name must be between 3 and 50 characters",
                    Payload = null
                };
            }else if(price == "" )
            {
                return new Response<MsStationery>()
                {
                    Success = false,
                    Message = "Price must be filled",
                    Payload = null
                };
            }
            else if (!int.TryParse(price, out int number))
            {
                return new Response<MsStationery>()
                {
                    Success = false,
                    Message = "Price must be numeric",
                    Payload = null
                };
            }
            else if (number < 2000)
            {
                return new Response<MsStationery>()
                {
                    Success = false,
                    Message = "Price must be greater or equal to 2000",
                    Payload = null
                };
            }


            StationeryHandler.HandleStationeryInsertion(name, Int32.Parse(price));
            return new Response<MsStationery>()
            {
                Success = true,
                Message = "",
                Payload = null
            };
        }

        public static Response<MsStationery> ValidateStationeryUpdate(int id, string name, string price)
        {
            if (!(name.Length >= 3 && name.Length <= 50))
            {
                return new Response<MsStationery>()
                {
                    Success = false,
                    Message = "Name must be between 3 and 50 characters",
                    Payload = null
                };
            }
            else if (price == "")
            {
                return new Response<MsStationery>()
                {
                    Success = false,
                    Message = "Price must be filled",
                    Payload = null
                };
            }
            else if (!int.TryParse(price, out int number))
            {
                return new Response<MsStationery>()
                {
                    Success = false,
                    Message = "Price must be numeric",
                    Payload = null
                };
            }
            else if (number < 2000)
            {
                return new Response<MsStationery>()
                {
                    Success = false,
                    Message = "Price must be greater or equal to 2000",
                    Payload = null
                };
            }


            StationeryHandler.HandleStationeryUpdate(id, name, Int32.Parse(price));
            return new Response<MsStationery>()
            {
                Success = true,
                Message = "",
                Payload = null
            };
        }
        public static void ControlRemoveStationery(string id)
        {
            if(int.TryParse(id, out int stationeryID))
            {
                StationeryHandler.HandleRemoveStationery(stationeryID);
            }
            return;
        }
    }
}