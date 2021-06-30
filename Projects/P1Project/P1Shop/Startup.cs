using BusinessLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace P1Shop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime.
        // Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)//========> services object i need it to create a service for me, since contex is a service
        {
            services.AddControllersWithViews();
            services.AddDbContext<ShopDB>(options =>
            {

                if (!options.IsConfigured)//if option are not configure create the DB. This mock the db 
                {
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));//create a DataBase but 
                                                                                                //i need to set up usersecrets for hidde the connection string
                }

            });//add your db context this is DEPENDECY INJECTION

            services.AddScoped<IShopLogic, ShopLogic>();//register IShopLogic with ShopLogic with the dependecy injection system
            services.AddScoped<IOrderLogic, OrderLogic>();
            services.AddScoped<IProduct, ProductLogic>();
            services.AddScoped<IOrderDetailLogic, OrderDetailLogic>();
            services.AddScoped<IStoreLogic, StoreLogic>();
            services.AddScoped<ICartLogic, CartLogic>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //Verry importan for direction of the web pages
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                //Direct default home in this case set the controller file HomeController(Home)
                //the action in ths case Index
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
