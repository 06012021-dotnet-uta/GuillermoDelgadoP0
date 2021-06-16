using System;
using System.Linq;
using ShopDBContext;

namespace Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            ShopContext context = new ShopContext();
            UserRegistration x = new UserRegistration();

            x.Registration();
            
        }

    }
}
