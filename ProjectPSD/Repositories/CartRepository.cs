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
    }
}