using Microsoft.EntityFrameworkCore;
using ModelsLibary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RepositoryLayer
{
   public class ShopDB : DbContext
    {
        /// <summary>
        /// DbSets representing by tables in my data base: You need set the classes, that you need from The models
        /// to create the data base CODE FIRST APROACH
        /// 
        /// NOTE:Each Project need to be reference: RepositoryLayer reference the BusinessLayer
        /// the BusninessLayer referencce the ViewLayer and all of them ref the ModelsLibary project.
        /// </summary>
        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<OrderDetailModel> OrderDetails { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<StoreModel> Stores { get; set; }


        //create a constructor--> zero parameter constructor
        public ShopDB() { }


        /// <summary>
        /// Second constructor takes a dbContextOptions optiops object
        /// helps for testing 
        /// </summary>
        /// <param name="options"></param>
        public ShopDB(DbContextOptions options) : base(options){ }
        
        //Override OnConfiguring()
       protected override void OnConfiguring(DbContextOptionsBuilder options)//Override this method that is inheretid from dbContext: use this options for
                                                                              //testing unit test
        {
            //check if option have already configure in the testing suite.
            /*if (!options.IsConfigured)//if option are not configure create the DB. This mock the db 
            {
                options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=P1_Project;Trusted_Connection=True;");//create a DataBase
            }*/
        }//In testing you create a sql Databases that mirror this database but is all in memory



        /// <summary>
        /// For make keys in case give me trouble att the time of creating the db
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Composite Key for table Orderdetail
            modelBuilder.Entity<OrderDetailModel>().HasKey(x => new {x.OrderId, x.ProductId});
        }

        
    }
}
