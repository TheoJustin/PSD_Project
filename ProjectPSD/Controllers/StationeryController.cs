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
            if (!(name.Length > 3 && name.Length < 50))
            {
                return new Response<MsStationery>()
                {
                    Success = false,
                    Message = "Name must be between 3 and 50 characters",
                    Payload = null
                };
            }else if(price == "" || !int.TryParse(price, out int number) || number < 2000)
            {
                return new Response<MsStationery>()
                {
                    Success = false,
                    Message = "Price must be filled, numeric, and greater or equal to 2000",
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
            if (!(name.Length > 3 && name.Length < 50))
            {
                return new Response<MsStationery>()
                {
                    Success = false,
                    Message = "Name must be between 3 and 50 characters",
                    Payload = null
                };
            }
            else if (price == "" || !int.TryParse(price, out int number) || number < 2000)
            {
                return new Response<MsStationery>()
                {
                    Success = false,
                    Message = "Price must be filled, numeric, and greater or equal to 2000",
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
    }
}