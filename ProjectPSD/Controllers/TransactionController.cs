using ProjectPSD.Handlers;
using ProjectPSD.Models;
using ProjectPSD.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Controllers
{
    public class TransactionController
    {

        public static List<TransactionHeader> ControlGetAllTransactionHeaderByUser(int uid)
        {
            return TransactionHandler.HandleGetAllTransactionHeaderByUser(uid);
        }
        public static List<TransactionDetail> GetAllTransactionDetailsByID(int transactionID)
        {
            return TransactionHandler.HandleGetAllTransactionDetailsByID(transactionID);
        }

        public static List<TransactionDetail> ControlGetAllTransactionDetails()
        {
            return TransactionHandler.HandleGetAllTransactionDetails();
        }

        public static List<TransactionHeader> ControlGetAllTransactionHeaders()
        {
            return TransactionHandler.HandleGetAllTransactionHeaders();
        }
    }
}