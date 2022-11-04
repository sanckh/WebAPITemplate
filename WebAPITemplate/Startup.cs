using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPITemplate.Data;

namespace WebAPITemplate
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public string ConnectionString { get; }
        public Startup(IConfiguration config)
        {
            Configuration = config;
            ConnectionString = Configuration.GetConnectionString("DefaultConnectionString");
        }
        // Dependency Injection
        public void ConfigureServices(IServiceCollection service)
        {
            service.AddControllers();

            //Configure DbContext with SQL
            service.AddDbContext<AppDbContext>(options => options.UseSqlServer(ConnectionString));

            service.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApiTemplate", Version = "v1" });
            });
            //service.AddControllersWithViews();
            //service.AddMvc();

            //Repositories


            //database injection


            //inject jwt token service

        }

        // Middleware
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApiTemplate v1"));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();


        }
    }
}
