using ProjectPSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Factories
{
    public class TransactionHeaderFactory
    {
        public static TransactionHeader Create(int transactionId, int userId, DateTime transactionDate)
        {
            TransactionHeader th = new TransactionHeader();
            th.TransactionID = transactionId;
            th.UserID = userId;
            th.TransactionDate = transactionDate;

            return th;
        }
    }
}