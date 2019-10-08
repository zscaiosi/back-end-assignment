using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Products.API.Interfaces;
using Products.API.Services;
using Products.API.Data.Repositories;
using MongoDB.Driver;

namespace Products.API
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
            // OAuth2.0
            // services.AddAuthentication(authOpt => {
            //     authOpt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            // })
            // .AddJwtBearer(bearerOpt => {
            //     bearerOpt.TokenValidationParameters = new TokenValidationParameters
            //     {
            //         ValidateIssuer = true,
            //         ValidateAudience = true,
            //         ValidateLifetime = true,
            //         ValidateIssuerSigningKey = true,
            //         ValidIssuer = "zscaiosi",
            //         ValidAudience = "zscaiosi",
            //         IssuerSigningKey = new SymmetricSecurityKey(
            //             Encoding.UTF8.GetBytes(Configuration["SecurityKey"])
            //         )
            //     };
            // });
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton<IMongoRepository, MongoRepository>(obj => new MongoRepository(Configuration, new MongoClient(Configuration.GetConnectionString("MONGO_CONN_STR"))));            
            services.AddSingleton<IProductsRepository, ProductsRepository>();
            services.AddSingleton<IProductsService, ProductsService>();
            // services.AddSingleton<IPurchasesService, PurchasesService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
