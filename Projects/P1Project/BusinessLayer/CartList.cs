using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelsLibary;
using BusinessLayer;

namespace BusinessLayer
{


    /// <summary>
    /// Statics methos in this class for save the items and dont get null accros my app
    /// </summary>
    public class CartList
    {

        static List<CartModel> _list;


        static CartList()
        {
            _list = new List<CartModel>();
        }


        /// <summary>
        /// For add items in the cart
        /// </summary>
        /// <param name="item"></param>
        public static void AddItem(CartModel item)
        {
            _list.Add(item);
        }

        /// <summary>
        /// For retrive the list of item in the cart
        /// </summary>
        /// <returns></returns>
        public static List<CartModel> GetCartList()
        {
            return _list;
        }


        /// <summary>
        /// For clear the cart ant the checkout
        /// </summary>
        /// <returns></returns>
        public static bool ClearCart()
        {

            _list.Clear();
            return true;
        }
    }
}
