using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sprint16.Data;
using Sprint16.Models;
using Sprint16.Service;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Sprint16
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ShoppingContext>(options =>
                options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
            
            services.AddMvc();
            services.AddControllersWithViews();
            services.AddScoped<IDataService<Customer>, CustomerService>();
            //services.AddRouting();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
