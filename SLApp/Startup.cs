using System;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SLEntities;
using SLHelpers;
using System.Collections.Generic;
using SLHelpers.AppEnvironement;
using System.IO;

namespace SLApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration.GetSectionValue(ConfigurationCodes.JwtIssuerKey),
                        ValidAudience = Configuration.GetSectionValue(ConfigurationCodes.JwtIssuerKey),
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSectionValue(ConfigurationCodes.JwtKeyKey)))
                    };
                });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //services.AddDbContext<UserDbContext>(options => { options.UseSqlite(Configuration.GetConnectionString("sldb")); });
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
                app.UseHsts();
            }

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseAuthentication();
            app.UseDefaultFiles();
            app.UseStaticFiles();

            /*ne pas faire ça ici*/
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            config.GetSection("EnvironementVariabless").Bind(EnvironementVariables.Instance);
            IList<ConnectionProvider> cnx = new List<ConnectionProvider>();
            config.GetSection("ConnectionStrings").Bind(cnx);
            foreach (var item in cnx)
            {
                EnvironementVariables.Instance.AddConnectionProviders(item);
            }

        }
    }
}
