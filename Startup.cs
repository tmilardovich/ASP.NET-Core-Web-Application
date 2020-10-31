using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using news.DbModels;
using news.Repositories;
using news.Services;

namespace news
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        private void SetupDbContext(IServiceCollection services)
        {
            var connStr = Configuration.GetConnectionString("pma");

            services.AddDbContext<pmaDatabaseContext>(options => options.UseSqlServer(connStr));
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication("CookieAuth")
                .AddCookie("CookieAuth", configureOptions =>
                {
                    configureOptions.Cookie.Name = "My.Cookie";
                    configureOptions.LoginPath = "/login";
                    configureOptions.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                    configureOptions.Cookie.HttpOnly = true;
                    configureOptions.Cookie.SameSite = SameSiteMode.Lax;
                    configureOptions.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                });


            services.AddControllersWithViews();
            services.AddControllers().AddNewtonsoftJson();
            services.AddScoped<UserRepository>();
            services.AddScoped<UserService>();
            services.AddScoped<PostsRepository>();
            services.AddScoped<PostService>();
            services.AddScoped<FavRepository>();
            services.AddScoped<FavService>();
            SetupDbContext(services);
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

            app.UseRouting();


            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("Login",
                    "Auth/Login",
                    new { controller = "Auth", action = "Login" });

                endpoints.MapControllerRoute(
                    "users","users/all",
                    new { controller = "users", action = "Users" });

                endpoints.MapControllerRoute(
                    "posts", "posts/all",
                    new { controller = "posts", action = "Posts" });


                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    "headlines", "headlines",
                    new { controller = "home", action = "headlines" });

                

                endpoints.MapControllerRoute(
                    "posts", "posts",
                    new { controller = "Posts", action = "MyPosts" });

                

            });
        }
    }
}
