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

        public static void HandleRemoveDetails(List<TransactionDetail> transactionDetails)
        {
            foreach (TransactionDetail transactionDetail in transactionDetails)
            {
                // removing the transaction header if the deleted detail is the only detail the transaction has
                int detailsCount = transactionDetail.TransactionHeader.TransactionDetail.Count;
                TransactionHeader transactionHeader = transactionDetail.TransactionHeader;
                TransactionRepository.RemoveTransactionDetail(transactionDetail);
                if (detailsCount == 1)
                {
                    TransactionRepository.RemoveTransactionHeader(transactionHeader);
                }
            }
        }

        public static List<TransactionHeader> HandleGetAllTransactionHeaders()
        {
            return TransactionRepository.GetAllTransactions();
        }
    }
}