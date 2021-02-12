using CalculadoraTaxaJurosApi.Domain.Interface;
using CalculadoraTaxaJurosApi.Domain.Service;
using CalculadoraTaxaJurosApi.Infra.Interface;
using CalculadoraTaxaJurosApi.Infra.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TaxaJutosApi.Domain.Model;

namespace CalculadoraTaxaJurosApi
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

            services.AddScoped<ICalculaTaxaJuros, CalculaTaxaJurosService>();
            services.AddScoped<IShowmeTheCode, ShowMeTheCodeService>();
            services.AddTransient<ITaxaJurosApi, TaxaJurosApiService>();
            services.AddTransient<HttpClient, HttpClient>();

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CalculaTaxaJurosAPI", Version = "v1" });
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
                opt.SwaggerEndpoint("/swagger/v1/swagger.json", "CalculaTaxaJurosAPI");
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
