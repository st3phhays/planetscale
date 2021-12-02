using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Planetscale.Data;
using Microsoft.AspNetCore.Http;
//using MySQL.Data.EntityFrameworkCore;
//using Myql.Data.EntityFrameworkCore.Extensions;
using MySql.EntityFrameworkCore;
using MySql.EntityFrameworkCore.DataAnnotations;
using MySql.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading;

namespace planetscale
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            if (Environment.IsDevelopment())
            {
                services.AddDbContext<PlanetscaleContext>(options =>
                    options.UseMySQL(Configuration.GetConnectionString("Development")));
            }
            else
            {
                services.AddDbContext<PlanetscaleContext>(options =>
                    options.UseMySQL(Configuration.GetConnectionString("Production")));
            }
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
