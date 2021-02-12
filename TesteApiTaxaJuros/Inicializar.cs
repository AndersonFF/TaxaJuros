using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text;
using TaxaJutosApi.Domain.Model;
using TaxaJutosApi.Domain.Interface;
using TaxaJutosApi.Domain.Service;

namespace TesteApiTaxaJuros
{
    public class Inicializar
    {
        public ServiceProvider ProvedorServico { get; private set; }
        public IConfiguration configuracao { get; }

        public Inicializar()
        {
            var servicos = new ServiceCollection();

            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true);

            builder.AddEnvironmentVariables();
            configuracao = builder.Build();

            servicos.Configure<AppSettings>(configuracao.GetSection("AppSettings"));
            RegistrarServicos(servicos);
            
            ProvedorServico = servicos.BuildServiceProvider();
        }

        private static void RegistrarServicos(IServiceCollection servicos)
        {
            servicos.AddControllers();

            servicos.AddScoped<ITaxaJurosRequest, TaxaJurosService>();

            //servicos.Configure<AppSettings>(Configuracao.GetSection("AppSettings"));

        }

    }
}