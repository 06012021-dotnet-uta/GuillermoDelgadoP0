using ShopDBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class TheCart
    {
        public List<Item> StoreItems { get; set; }

        private Dictionary<int, int> CartItems = new Dictionary<int, int>();

        /// <summary>
        /// Contructor a empty cart
        /// </summary>
        public TheCart(){ }

        /// <summary>
        /// Method to add the order and check out
        /// </summary>
        /// <param name="storeLocationID"></param>
        /// <param name="userId"></param>
        //adding items
        public void AddItems(int storeLocationID, int userId)
        {
            using (var context = new ShopContext())
            {

                List<Product> productsAtLoc = context.Products.Where(x => x.LocationId == storeLocationID).ToList();

                //start order loop
                decimal TotalAmount = 0;
                bool check = true;

                while (check)
                {
                    //display the items in the store
                    Console.WriteLine("Choose items and quantity....");

                    int count = 1;
                    foreach (var item in productsAtLoc)
                    {
                        Console.WriteLine($"\n{count++}.ItemID: {item.ProductId} ---> Item Name: {item.ProductName}" +
                            $"  \n\tItem Price: ${item.ProductPrice}  Qty:{item.Stock}");
                    }

                    //user can choose to check out.

                    // get the users choice
                    Console.Write("*******************************************************");
                    Console.Write($"\n\nPlease enter the NUMBER of the item you want, NOT THE NUMBER ID:");
                    int choiceInt = 0;
                    bool choice = Int32.TryParse(Console.ReadLine(), out choiceInt);// make a validation here

                    //add the chosen item to the Distionary<int,int>
                    Product productItem = productsAtLoc[choiceInt - 1];// get the item chosen
                    Console.WriteLine($"\nHow many {productItem.ProductName}'s do you want?");
                    choiceInt = 0;
                    choice = Int32.TryParse(Console.ReadLine(), out choiceInt);// make a validation here

                    // check it there is enough in the Db.. Query the Context to see how many of this item there is.
                    int howMany = productItem.Stock;
                    Console.WriteLine($"Test {howMany}");

                    //if not enough, tell user and list products again
                    if (howMany < choiceInt || howMany == 0)
                    {
                        Console.WriteLine($"Sorry the store only have {howMany}");

                    }
                    else
                    {
                        //Adding the   total price of the items added
                        //and subtract the qty from the store
                        TotalAmount = TotalAmount + (choiceInt * productItem.ProductPrice);
                        productItem.Stock = howMany - choiceInt;
                        CartItems.Add(productItem.ProductId, choiceInt);
                    }

                    //check for keep buying
                    check = checkAgain();
                }//end loop
                
                Console.WriteLine("\n********* Your Oreder Item ********\n");
                foreach (KeyValuePair<int, int> kvp in CartItems)
                {
                    Console.WriteLine("ProductID: {0}, Qty: {1}", kvp.Key, kvp.Value);
                }

                Console.WriteLine($"Total Amount: ${TotalAmount} ");

                //Saving a order
                var order = new Order() {

                    UserId = userId,
                    TotalPurches = TotalAmount,
                    
                 };
                 context.Orders.Add(order);
                 context.SaveChanges();
                

                //Loop for insert the items in
                //the OrderItem Table Goes here
                /*foreach ( KeyValuePair<int,int> kvp in CartItems ){

                    var orderItem = new OrderItem()
                    {
                        OrderId = 
                    };

                }*/

                Console.WriteLine("Order Sumited...");

                //example or writing back to the Db.
                /* Product p = new Product()
                 {
                     ProductName = "Marks Product",
                     ProductPrice = 3.99m,
                     Stock = 42,
                     ProductDescription = "It's ok",
                     LocationId = 1000
                 };
                 context.Products.Add(p);
                 Console.WriteLine($"{p.ProductId}");
                 context.SaveChanges();
                 Console.WriteLine($"{p.ProductId}");*/

            }//using
        }//end of add

        /// <summary>
        /// Method for pull items out of the cart
        /// </summary>
        public void PullOut() { }


        /// <summary>
        /// Method the place the order in the DB 
        /// </summary>
        public void CheckOut() { }

        /// <summary>
        ///Method for validation of the store 
        /// </summary>
        /// <param name="storeLocation"></param>
        /// <returns></returns>
        private bool ValidationStore(int storeLocation)
        {
            using (var context = new ShopContext())
            {
                var storeId = context.Products.ToList();

                foreach (var c in storeId)
                {
                    if (storeLocation == c.LocationId)
                    {
                        return true;
                    }
                }
                return false;
            }
        }


        /// <summary>
        /// Method ask for aproval to keep in the store and buy
        /// more items return bool
        /// </summary>
        /// <returns></returns>
        private bool checkAgain()
        {
            Console.WriteLine("You get more items from the store y/n?....");
            string repeat = Console.ReadLine();

            if (repeat.ToLower().Equals("n"))
            {
                Console.WriteLine("Thanks for buying from us....");
                return false;

            }
            else if (repeat.ToLower().Equals("y"))
            {
                System.Console.WriteLine("Checking againg!!!!");

                return true;
            }
            else
            {
                System.Console.WriteLine("Not valid input......");

                return checkAgain();
            }

        }
    }
}
