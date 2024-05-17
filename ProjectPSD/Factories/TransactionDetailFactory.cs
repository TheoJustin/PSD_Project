using ProjectPSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Factories
{
    public class TransactionDetailFactory
    {
        public static TransactionDetail Create(int transactionId, int stationeryId, int quantity)
        {
            TransactionDetail td = new TransactionDetail();
            td.TransactionID = transactionId;
            td.StationeryID = stationeryId;
            td.Quantity = quantity;

            return td;
        }
    }
}