using ProjectPSD.Factories;
using ProjectPSD.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace ProjectPSD.Repositories
{
    public class CartRepository
    {
        private static RAisoDatabaseEntities db = DBSingleton.GetInstance();
        public static void InsertCart(int uid, int id, int quantity)
        {
            Cart cart = CartFactory.Create(uid, id, quantity);
            db.Carts.Add(cart);
            db.SaveChanges();
        }

        public static List<Cart> GetAllCarts()
        {
            return db.Carts.ToList();
        }

        public static List<Cart> GetCartsByUser(int uid)
        {
            return db.Carts.Where(cart => cart.UserID == uid).ToList();
        }

        public static void DeleteAllUserCart(int uid)
        {
            List<Cart> userCarts = GetCartsByUser(uid);
            db.Carts.RemoveRange(userCarts);
            db.SaveChanges();
        }

        public static Cart GetCartByID(int uid, int sid)
        {
            return db.Carts.Where(cart => cart.UserID == uid && cart.StationeryID == sid).FirstOrDefault();
        }

        public static void UpdateCart(int userID, int stationeryID, int quantity)
        {
            Cart cart = GetCartByID(userID, stationeryID);
            cart.Quantity = quantity;
            db.SaveChanges();
        }
        public static void RemoveCart(int userID, int stationeryID)
        {
            Cart cart = GetCartByID(userID, stationeryID);
            db.Carts.Remove(cart);
            db.SaveChanges();
        }

        public static void RemoveCarts(List<Cart> carts)
        {
            db.Carts.RemoveRange(carts);
            db.SaveChanges();
        }
    }
}