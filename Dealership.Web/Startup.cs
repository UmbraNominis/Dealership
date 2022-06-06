using Dealership.Data.DataModels.IdentityModels;
using Dealership.Data.Models.IdentityModels;
using Dealership.Data.Interfaces;
using Dealership.Data.Services.DatabaseContext;
using Dealership.Data.Services.ImageServices;
using Dealership.Data.Services.SQLServices;
using Dealership.Entities.Profiles;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Dealership.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICarsData, SQLCarsData>();
            services.AddDbContext<DealershipDbContext>();

            // Inject Profile Picture Service
            services.AddTransient<IPictureService<ProfilePicture>, ProfilePictureService>();

            // Inject Auto Mapper
            services.AddAutoMapper(typeof(CarsProfile));
            services.AddAutoMapper(typeof(ApplicationUsersProfile));

            // Inject Identity
            services.AddDefaultIdentity<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<DealershipDbContext>();
            
            services.AddControllersWithViews();
            services.AddRazorPages();
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
                app.UseExceptionHandler("/Cars/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // User Authentication Middleware
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Cars}/{action=Index}/{id?}");
                // Add Support for Razor Pages
                endpoints.MapRazorPages();
            });
        }
    }
}
