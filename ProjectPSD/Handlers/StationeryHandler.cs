using ProjectPSD.Models;
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
            return StationeryRepository.GetStationeryByID(id);
        }
    }
}