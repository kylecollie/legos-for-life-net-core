using Innotech.LegosForLife.DataAccess;
using Innotech.LegosForLife.DataAccess.Repositories;
using InnoTech.LegosForLife.Core.IServices;
using InnoTech.LegosForLife.DataAccess;
using InnoTech.LegosForLife.Domain.IRepositories;
using InnoTech.LegosForLife.Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace InnoTech.LegosForLife.WebApi
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Innotech.LegosforLife.WebApi", Version = "v1" });
            });

            //Setting up Dependency Injection
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            //Setting up DB Info
            services.AddDbContext<MainDbContext>(
                options =>
                {
                    options.UseSqlite("Data Source=main.db");
                });

            //Setting up CORS policy
            services.AddCors(options =>
            {
                options.AddPolicy("Dev-cors", policy =>
                {
                    policy
                    .WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
                options.AddPolicy("Prod-cors", policy =>
                {
                    policy
                    .WithOrigins("https://legosforlife-c3be9.firebaseapp.com",
                        "https://legosforlife-c3be9.web.app")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MainDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Innotech.LegosforLife.WebApi v1"));
                app.UseCors("Dev-cors");
                new DbSeeder(context).SeedDevelopment();
            }
            else
            {
                app.UseCors("Prod-cors");
                new DbSeeder(context).SeedProduction();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}