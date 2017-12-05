using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ParkTrack.Data;
using ParkTrack.Models.Repositories;

namespace ParkTrack
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
            // Add automapper to repository
            services.AddAutoMapper();
            //Inject UserRepo interface
            services.AddScoped<ISensorRepository, SensorRepository>();

            // Database connection
            services.AddDbContext<SensorContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));

            // Cross origin 
            services.AddCors(o => o.AddPolicy("AllowClient", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowClient");

            app.UseMvcWithDefaultRoute();
        }
    }
}
