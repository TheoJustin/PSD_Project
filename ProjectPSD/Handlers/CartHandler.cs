using ProjectPSD.Models;
using ProjectPSD.Modules;
using ProjectPSD.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace ProjectPSD.Handlers
{
    public class CartHandler
    {
        public static Response<Cart> HandleCartInsertion(int uid, int id, int qty)
        {
            if(qty <= 0)
            {
                return new Response<Cart>()
                {
                    Success = false,
                    Message = "Quantity must be more than 0",
                    Payload = null
                };
            }
            else
            {
                CartRepository.InsertCart(uid, id, qty);
                return new Response<Cart>()
                {
                    Success = true,
                    Message = "",
                    Payload = null
                };
            }
        }

        public static List<Cart> HandleAllCartsByUser(int uid)
        {
            List<Cart> allCart = CartRepository.GetAllCarts();
            List<Cart> returnCart = new List<Cart>();

            foreach (Cart cart in allCart)
            {
                if (cart.UserID == uid)
                {
                    returnCart.Add(cart);
                }
            }

            return returnCart;
        }

        public static Cart HandleCartByID(String uid, String sid)
        {
            return CartRepository.GetCartByID(Int32.Parse(uid), Int32.Parse(sid));
        }

        public static Response<Cart> HandleCartUpdate(int uid, int sid, int qty)
        {
            if (qty <= 0)
            {
                return new Response<Cart>()
                {
                    Success = false,
                    Message = "Quantity must be more than 0",
                    Payload = null
                };
            }
            else
            {
                CartRepository.UpdateCart(uid, sid, qty);
                return new Response<Cart>()
                {
                    Success = true,
                    Message = "",
                    Payload = null
                };
            }
        }

        public static Response<string> HandleCartCheckOut(int uid)
        {
            List<Cart> userCarts = CartRepository.GetCartsByUser(uid);
            if(userCarts.Count <= 0)
            {
                return new Response<string>
                {
                    Success = false,
                    Message = "Your cart is empty!",
                    Payload = null
                };
            }
            else
            {
                TransactionRepository.CheckOutCart(TransactionHandler.GenerateTransactionID(), uid, userCarts);
                CartRepository.DeleteAllUserCart(uid);
                return new Response<string>
                {
                    Success = true,
                    Message = "Success",
                    Payload = null
                };
            }
        }
        public static void HandleRemoveCart(int userID, int stationeryID)
        {
            CartRepository.RemoveCart(userID, stationeryID);
        }

        
    }
}