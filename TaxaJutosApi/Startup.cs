using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using TaxaJutosApi.Domain.Extensão;
using TaxaJutosApi.Domain.Interface;
using TaxaJutosApi.Domain.Service;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace TaxaJutosApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            Configuration = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", optional: false)
              .AddEnvironmentVariables()
              .Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        
            services.AddScoped<ITaxaJurosRequest, TaxaJurosService>();

            services.Configure<AppSettings>(options => Configuration.GetSection("AppSettings"));

            services.AddCors(options =>
            {
                options.AddPolicy("AllowMyOrigin",
                    builder => builder.WithOrigins(Environment.GetEnvironmentVariable("CORS_ALLOWED"))
                                        .AllowAnyMethod()
                                        .AllowAnyHeader());
                options.AddPolicy("AllowAnyOrigin",
                        builder => builder.AllowAnyOrigin());
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TodoAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
           
            app.UseRouting();

            app.UseSwagger();

            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint("/swagger/v1/swagger.json", "TaxaJurosAPI");
                opt.RoutePrefix = string.Empty;
            });

            app.UseCors(options =>
            {
                options.WithOrigins(origins: Environment.GetEnvironmentVariable("CORS_ALLOWED"));
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
