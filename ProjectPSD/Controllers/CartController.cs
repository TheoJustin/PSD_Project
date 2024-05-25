using ProjectPSD.Handlers;
using ProjectPSD.Models;
using ProjectPSD.Modules;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace ProjectPSD.Controllers
{
    public class CartController
    {
        public static Response<Cart> ValidateCartInsertion(int uid, int id, string qty)
        {
            if (qty == "" || !int.TryParse(qty, out int number))
            {
                return new Response<Cart>()
                {
                    Success = false,
                    Message = "Quantity should be an integer and it cannot be empty",
                    Payload = null
                };
            }
            else
            {
                return CartHandler.HandleCartInsertion(uid, id, Int32.Parse(qty));
            }
        }

        public static List<Cart> ReadAllCarts(int uid)
        {
            return CartHandler.HandleAllCartsByUser(uid);
        }

        public static Cart ReadCartById(String uid, String sid)
        {
            return CartHandler.HandleCartByID(uid, sid);
        }

        public static Response<Cart> ValidateCartUpdate(int uid, int sid, string qty)
        {
            if(qty == "" || !int.TryParse(qty, out int number))
            {
                return new Response<Cart>()
                {
                    Success = false,
                    Message = "Quantity should be an integer and it cannot be empty",
                    Payload = null
                };
            }
            int qtyInt = Convert.ToInt32(qty);
            return CartHandler.HandleCartUpdate(uid, sid, qtyInt);
        }
        public static void ControlRemoveFromCart(String userID, String stationeryID)
        {
            CartHandler.HandleRemoveCart(Convert.ToInt32(userID), Convert.ToInt32(stationeryID));
        }

        public static Response<string> ControlCheckOut(int uid)
        {
            Response<string> response = CartHandler.HandleCartCheckOut(uid);
            return response;
        }
    }
}