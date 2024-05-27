using ProjectPSD.Factories;
using ProjectPSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Repositories
{
    public class TransactionRepository
    {
        private static RAisoDatabaseEntities db = DBSingleton.GetInstance();

        public static int GetLastTransactionID()
        {
            // harus pake ? supaya dia bakal return null kalo gaada
            // kalau kita gapake ? maka bakal return empty rather than null

            int? lastID = db.TransactionHeaders.Max(x => x.TransactionID);

            if (lastID == null)
            {
                return 0;
            }
            else
            {
                return lastID.Value;
            }
        }
        public static void CheckOutCart(int newID, int uid, List<Cart> carts)
        {
            TransactionHeader transactionHeader = TransactionHeaderFactory.Create(newID, uid, DateTime.Now);
            db.TransactionHeaders.Add(transactionHeader);
            foreach (Cart cart in carts)
            {
                TransactionDetail transactionDetail = TransactionDetailFactory.Create(newID, cart.StationeryID, cart.Quantity);
                db.TransactionDetails.Add(transactionDetail);
            }
            db.SaveChanges();
        }

        public static List<TransactionHeader> GetAllTransactionHeaderByUser(int uid)
        {
            return db.TransactionHeaders.Where(transaction => transaction.UserID == uid).ToList();
        }

        public static List<TransactionHeader> GetAllTransactions()
        {
            return db.TransactionHeaders.ToList();
        }

        public static List<TransactionDetail> GetAllTransactionDetails()
        {
            return db.TransactionDetails.ToList();

        }

        public static List<TransactionDetail> GetTransactionDetailsFromID(int transactionID)
        {
            return db.TransactionDetails.Where(transaction => transaction.TransactionID == transactionID).ToList();
        }
    }
}