using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using EFCommands;
using EFDataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApp
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<OnlineShopContext>();
            services.AddTransient<IGetUsersWebCommand, EFGetUsersWebCommand>();
            services.AddTransient<IGetUserWebCommand, EFGetUserWebCommand>();
            services.AddTransient<IAddUserCommand, EFAddUserCommand>();
            services.AddTransient<IEditUserWebCommand, EFEditUserWebCommand>();
            services.AddTransient<IDeleteUserCommand, EFDeleteUserCommand>();

            services.AddTransient<IGetProductsWebCommand, EFGetProductsWebCommand>();
            services.AddTransient<IGetProductWebCommand, EFGetProductWebCommand>();
            services.AddTransient<IAddProductWebCommand, EFAddProductWebCommand>();
            services.AddTransient<IEditProductWebCommand, EFEditProductWebCommand>();
            services.AddTransient<IDeleteProductCommand, EFDeleteProductCommand>();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
