using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NPMS.Models;
using NPMS.Repository;
using Microsoft.EntityFrameworkCore;


namespace NPMS
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
            services.AddRazorPages();
            services.AddControllers();
            services.AddScoped<IUser, UserRepo>();
            services.AddScoped<IAdmin, AdminRepo>();
            services.AddScoped<ICategory, CategoryRepo>();
            services.AddScoped<IAdds, AddsRepo>();
            services.AddScoped<IPayment, PaymentRepo>();
            services.AddScoped<IAddLists, AddListsRepo>();
            services.AddScoped<IBooking, BookingRepo>();
            services.AddDbContext<News_Paper_Management_SystemContext>(option => option.UseSqlServer(Configuration.GetConnectionString("NMSFSD")));
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "SWAGGER DEMO",
                    Description = "SWAGGER DEMO FOR Registration-DETAILS",
                    Version = "v1"
                });
            });

            //TO GIVE PERMISSION TO ACCESS API ACROSS PLATFORMS
            services.AddCors(c =>
            {
                //c.AddPolicy("AllowOrigin", option =>
                //option.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();

                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EMS-API"));
            }
            /* app.UseCors();

             app.UseCors(op => op.AllowAnyOrigin());*/

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}
