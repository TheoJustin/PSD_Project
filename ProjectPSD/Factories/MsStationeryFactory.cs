using ProjectPSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Factories
{
    public class MsStationeryFactory
    {
        public static MsStationery Create(int stationeryId, string stationeryName, int stationeryPrice)
        {
            MsStationery ms = new MsStationery();
            ms.StationeryID = stationeryId;
            ms.StationeryName = stationeryName;
            ms.StationeryPrice = stationeryPrice;

            return ms;
        }
    }
}