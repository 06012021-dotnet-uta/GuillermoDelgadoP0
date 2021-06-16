using ShopDBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class UserRegistration : User
    {
        //For get notification from the class Messages
        Messages message = new Messages();
        StoreBusiness storeB = new StoreBusiness();
        TheCart cart = new TheCart();


        /// <summary>
        /// Constructor
        /// </summary>
        public UserRegistration() {}

        /// <summary>
        /// Method that run all the app
        /// </summary>
        public void Registration()
        {
            Menu(message.SelectionMessage());
        }

        /// <summary>
        /// Main Menu of this app
        /// </summary>
        /// <param name="choice"></param>
        public void Menu(int choice)
        {
            switch (choice)
            {
                case 1:
                    Console.WriteLine("********** Login *********");

                    string name = message.Name();
                    string password = message.Password();
                    SubMenu(name, password);

                    break;

                case 2:
                    Console.WriteLine("******** Sing Up ********/n");

                    AddUserAccount();
                    Registration();
                    break;

                case 3:
                    Console.WriteLine("********  Quit  ***********");
                    break;
            }
        }

        /// <summary>
        /// For seach if the user exist in the database
        /// returning true if exist if not
        /// return false
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private bool Validation(string name, string password)
        {
            using (var context = new ShopContext())
            {
                var user = context.Users.ToList();

                foreach (var c in user)
                {
                    if (name == c.UserFirstName && password == c.Password)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        /// <summary>
        /// Display order info
        /// </summary>
        /// <param name="userID"></param>
        public void DisplayOrderInfo(int userID)
        {
            using (var context = new ShopContext())
            {
                var query = context.Orders.ToList();

                foreach (var order in query)
                {
                    Console.WriteLine($"\t\tOrder ID: {order.OrderId}\n\t\tUser ID: {order.UserId}" +
                        $"\n\t\tTotal Purshes: {order.TotalPurches}\n\t\tItem Id:{order.TimeDate}\n\n");
                }
            }
        }

        /// <summary>
        /// UserToken If to keed check that the real user is theo ne connected
        /// using he userId as validation 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int UserToken(string name, string password)
        {
            using (var context = new ShopContext())
            {
                var user = context.Users.ToList();

                foreach (var c in user)
                {
                    if (name == c.UserFirstName && password == c.Password)
                    {
                        return c.UserId;
                    }
                }
                return -1;
            }
        }

        /// <summary>
        /// Add user to the dataBase
        /// </summary>
        public void AddUserAccount()
        {

            using(var contex = new ShopContext())
            {
                var newUser = new User()
                {
                    UserFirstName = message.Name(),
                    UserLastName = message.LastName(),
                    Password = message.Password(),
                    UserAddress = message.Address(),
                    UserCity = message.City(),
                    UserState = message.State()
                };
                contex.Users.Add(newUser);
                contex.SaveChanges();

            }
        }


        /// <summary>
        /// The second menu were the user is already log in
        /// and complete the validations.
        /// </summary>
        public void SubMenu(string name, string password)
        {
            if (Validation(name,password))
            {
                int userID = UserToken(name, password);

                switch (message.UserMenu())
                {
                    case 1:
                        Console.WriteLine("******** Store List ********\n");

                        storeB.DisplayStoresInfo();

                        int storeSelection = message.storeSelection();
                        cart.AddItems(storeSelection,userID);
                        

                        SubMenu(name,password);
                        break;

                    case 2:
                        Console.WriteLine("******** Order List *******\n");

                        DisplayOrderInfo(userID);
                        SubMenu(name,password);
                        break;

                    case 3:
                        Console.WriteLine("********* Log Out ************");
                        Registration();
                        break;
                }
            }
            else
            {
                Registration();
            }
        }

    }
}
