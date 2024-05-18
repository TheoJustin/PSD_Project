using ProjectPSD.Handlers;
using ProjectPSD.Models;
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
    }
}