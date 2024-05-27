using ProjectPSD.Models;
using ProjectPSD.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Handlers
{
    public class TransactionHandler
    {
        public static List<TransactionHeader> HandleGetAllTransactionHeaderByUser(int uid)
        {
            return TransactionRepository.GetAllTransactionHeaderByUser(uid);
        }

        public static List<TransactionDetail> HandleGetAllTransactionDetailsByID(int transactionID)
        {
            return TransactionRepository.GetTransactionDetailsFromID(transactionID);
        }

        public static int GenerateTransactionID()
        {
            return TransactionRepository.GetLastTransactionID()+1;
        }

        public static List<TransactionDetail> HandleGetAllTransactionDetails()
        {
            return TransactionRepository.GetAllTransactionDetails();
        }

        public static List<TransactionHeader> HandleGetAllTransactionHeaders()
        {
            return TransactionRepository.GetAllTransactions();
        }
    }
}