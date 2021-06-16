using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    
    class Messages
    {
        public int choice;
     
        public Messages() {
        
        }

        /// <summary>
        /// Display the main menu
        /// return the user choise
        /// </summary>
        /// <returns></returns>
        public int SelectionMessage()
        {
            Console.WriteLine("\n******** Login Command Interface *********");
            Console.WriteLine("****** Welcome GUNGULE Search Store ******\n\n");
            Console.WriteLine("\n\t1.Login\n\t2.Sign Up\n\t3.Quit");
            Console.WriteLine("\n\n**********************************************\n");
            Console.Write("Ente your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            if(choice > 3 && choice < 1)
            {
                Console.WriteLine("The value you inserted is not valid");
                return SelectionMessage();
            }
            else
            {
                return choice;
            }
        }

        /// <summary>
        /// Display the sub menu
        /// return user choice
        /// </summary>
        /// <returns></returns>
        public int UserMenu()
        {
            Console.WriteLine("\n******** User Display Menu *********");
            Console.WriteLine("\n\t1.Store List\n\t2.Order List\n\t3.Log Out");
            Console.WriteLine("\n\n********************************\n");
            Console.Write("Ente your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            if (choice > 3 && choice < 1)
            {
                Console.WriteLine("The value you inserted is not valid");
                return SelectionMessage();
            }
            else
            {
                return choice;
            }
        }


        /// <summary>
        /// Mehtod for enter the store id
        /// return the store id int
        /// </summary>
        /// <returns></returns>
        public int storeSelection()
        {
            Console.WriteLine("Select in wich store you will like to check....");
            Console.Write("Enter the Store Location ID: ");
            int locationId = Convert.ToInt32(Console.ReadLine());
            return locationId;
        }


        /// <summary>
        /// Ask for the name and return a string of it
        /// </summary>
        /// <returns></returns>
        public string Name()
        {
            Console.Write("\n User Firts Name: ");
            string name = Console.ReadLine();
            return name;
        }

        /// <summary>
        /// Ask for the last name and return a string of it
        /// </summary>
        /// <returns></returns>
        public string LastName()
        {
            Console.Write("\n User Last Name: ");
            string lname = Console.ReadLine();
            return lname;

        }

        /// <summary>
        /// Ask for the password and return a string of it
        /// </summary>
        /// <returns></returns>
        public string Password()
        {
            Console.Write("\n User Password: ");
            string password = Console.ReadLine();
          
            return password;

        }

        /// <summary>
        /// Ask for the Address and return a string of it
        /// </summary>
        /// <returns></returns>
        public string Address()
        {
            Console.Write("\n User Address: ");
            string address = Console.ReadLine();
            return address;
        }

        /// <summary>
        /// Ask for the city and return a string of it
        /// </summary>
        /// <returns></returns>
        public string City()
        {
            Console.Write("\n User City: ");
            string city = Console.ReadLine();
            return city;
        }

        /// <summary>
        /// Ask for the state and return a string of it
        /// </summary>
        /// <returns></returns>
        public string State()
        {
            Console.Write("\n User State: ");
            string state = Console.ReadLine();
            return state;
        }

        /// <summary>
        /// Display login and register option
        /// </summary>
        public void LoginRegister()
        {
            Console.WriteLine("\n\n\n\t          1.Login                     ");
            Console.WriteLine("\t         2.Register                   \n\n");
        }

        /// <summary>
        /// display a message if the user exist
        /// </summary>
        public void UserExists()
        {
            Console.WriteLine("User Account is already exist......");
        }

        /// <summary>
        /// display a message asking to register
        /// </summary>
        public void UserRegisterQuestion()
        {
            Console.WriteLine("Did you want to Registes?....");
        }
    }
}
