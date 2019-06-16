using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Email;
using Application.Commands;
using EFCommands;
using Application.Interfaces;
using EFDataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Api.Helpers;
using Newtonsoft.Json;
using Application.Logging;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;
using System.Reflection;

namespace Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<OnlineShopContext>();
            services.AddTransient<IGetCategoryCommand, EFGetCategoryCommand>();
            services.AddTransient<IGetCategoriesCommand, EFGetCategoriesCommand>();
            services.AddTransient<IAddCategoryCommand, EFAddCategoryCommand>();
            services.AddTransient<IEditCategoryCommand, EFEditCategoryCommand>();
            services.AddTransient<IDeleteCategoryCommand, EFDeleteCategoryCommand>();
            services.AddTransient<IGetBrandCommand, EFGetBrandCommand>();
            services.AddTransient<IGetBrandsCommand, EFGetBrandsCommand>();
            services.AddTransient<IAddBrandCommand, EFAddBrandCommand>();
            services.AddTransient<IDeleteBrandCommand, EFDeleteBrandCommand>();
            services.AddTransient<IGetRoleCommand, EFGetRoleCommand>();
            services.AddTransient<IGetRolesCommand, EFGetRolesCommand>();
            services.AddTransient<IAddRoleCommand, EFAddRoleCommand>();
            services.AddTransient<IDeleteRoleCommand, EFDeleteRoleCommand>();
            services.AddTransient<IGetUserCommand, EFGetUserCommand>();
            services.AddTransient<IGetUsersCommand, EFGetUsersCommand>();
            services.AddTransient<IAddUserCommand, EFAddUserCommand>();
            services.AddTransient<IEditUserCommand, EFEditUserCommand>();
            services.AddTransient<IDeleteUserCommand, EFDeleteUserCommand>();
            services.AddTransient<IGetCommentCommand, EFGetCommentCommand>();
            services.AddTransient<IGetCommentsCommand, EFGetCommentsCommand>();
            services.AddTransient<IAddCommentCommand, EFAddCommentCommand>();
            services.AddTransient<IDeleteCommentCommand, EFDeleteCommentCommand>();
            services.AddTransient<IGetOrderCommand, EFGetOrderCommand>();
            services.AddTransient<IGetOrdersCommand, EFGetOrdersCommand>();
            services.AddTransient<IAddOrderCommand, EFAddOrderCommand>();
            services.AddTransient<IDeleteOrderCommand, EFDeleteOrderCommand>();
            services.AddTransient<IGetProductCommand, EFGetProductCommand>();
            services.AddTransient<IGetProductsCommand, EFGetProductsCommand>();
            services.AddTransient<IAddProductCommand, EFAddProductCommand>();
            services.AddTransient<IEditProductCommand, EFEditProductCommand>();
            services.AddTransient<IDeleteProductCommand, EFDeleteProductCommand>();

            services.AddTransient<IGetProductOrderCommand, EFGetProductOrderCommand>();
            services.AddTransient<IGetProductCategoryCommand, EFGetProductCategoryCommand>();
            services.AddTransient<IAuthCommand, EFAuthCommand>();

            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            var key = Configuration.GetSection("Encryption")["key"];

            var enc = new Encryption(key);
            services.AddSingleton(enc);

            services.AddTransient(s => {
                var http = s.GetRequiredService<IHttpContextAccessor>();
                var value = http.HttpContext.Request.Headers["Authorization"].ToString();
                var encryption = s.GetRequiredService<Encryption>();

                try
                {
                    var decodedString = encryption.DecryptString(value);
                    decodedString = decodedString.Substring(0, decodedString.LastIndexOf("}") + 1);
                    var user = JsonConvert.DeserializeObject<LoggedUser>(decodedString);
                    user.IsLogged = true;
                    return user;
                }
                catch (Exception)
                {
                    return new LoggedUser
                    {
                        IsLogged = false
                    };
                }
            });





            //swagger specification
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Online Shop API", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });



            //za mailer
            var section = Configuration.GetSection("Email");

            var sender =
                new SmtpEmailSender(section["host"], Int32.Parse(section["port"]), section["fromaddress"], section["password"]);

            services.AddSingleton<IEmailSender>(sender);

                


           
           
           
           





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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });


            app.UseMvc();
            app.UseStaticFiles();
        }
    }
}
