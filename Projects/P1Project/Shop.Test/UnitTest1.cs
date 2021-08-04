using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using ModelsLibary;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;


namespace Shop.Test
{
    public class UnitTest1 
    {

        //create the in-memory DataBase //EF core Installed
        private readonly DbContextOptions options = new DbContextOptionsBuilder<ShopDB>().UseInMemoryDatabase(databaseName:"ShopUnitTest").Options;


        [Fact]
        public async Task RegisterCustomerInsertCustomerCorrectly()
        {
            //Arrange
            //create a customer to insert into the inmemory DB.
            CustomerModel customerTest = new CustomerModel()
            {
                Customer_City = "city",
                Customer_FName = "name",
                Customer_LName = "lname",
                Customer_Address = "address",
                Customer_State = "NY",
                Password = "1234"
                
            };
            
            bool result = false;


            //Act
            //add to the in-memory db
            //instanciate the inmemory db
            using(var context = new ShopDB(options))//pass a db in memory as parameter
            {

                //verify that the db was deleted and created anew
                context.Database.EnsureDeleted();//delete any Db from a previous test

                context.Database.EnsureCreated();// create a new Db.. you will need to seed it again.

                //intaciate the ShopLogic class that we are going to unit test
                ShopLogic shopLogicTest = new ShopLogic(context);

                result = await shopLogicTest.RegisterCustomerAsync(customerTest);

                context.SaveChanges();
            }


            //Asset
            using(var context = new ShopDB(options))//pass a db in memory as parameter
            {

                int c = await context.Customers.CountAsync();
                var cust = context.Customers.Where(x => x.Customer_FName == "name").FirstOrDefault();
                Assert.True(result);
                Assert.Equal(1,c);
                Assert.NotNull(cust);
               
            }

        }



        [Fact]
        public async Task ShowCustomerListUnitTest()
        {

            //Arrange
            //Create a List of Customers

            Task<List<CustomerModel>> list = null;

            //Act
            using (var context = new ShopDB(options))
            {
                //verify that the db was deleted and created anew
                context.Database.EnsureDeleted();//delete any Db from a previous test

                context.Database.EnsureCreated();// create a new Db.. you will need to seed it again.

                ShopLogic shopLogicTest = new ShopLogic(context);

                list = shopLogicTest.CustomerListAsync();
            }

            //Assert
                Assert.NotNull(list);

        }

    }
}
