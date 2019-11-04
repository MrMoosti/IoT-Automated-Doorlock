using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rfid.Persistence.MongoDb;
using Rfid.Persistence.MongoDb.Repositories;
using Rfid.Persistence.MongoDb.UnitOfWorks;
using Rfid.Persistence.Repositories;
using Rfid.Persistence.UnitOfWorks;
using RfidApi.Core.Led;
using RfidApi.Core.Services;
using RfidApi.Core.Services.Implementations;

namespace RfidApi
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
            services.AddMvc(x => x.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICpuTempService, CpuService>();
            services.AddScoped<IDoorService, DoorService>();
            services.AddScoped<ILogService, LogService>();
            services.AddScoped<ICpuRepository, CpuRepository>();
            services.AddScoped<IDoorRepository, DoorRepository>();
            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<MongoContext>();
            services.AddSingleton<BlinkLed>();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(builder => builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin());
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
