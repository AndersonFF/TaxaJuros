using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text;
using TaxaJutosApi.Domain.Extensão;
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

             RegistrarServicos(servicos);
           
             ProvedorServico = servicos.BuildServiceProvider();
        }

        private static void RegistrarServicos(IServiceCollection servicos)
        {
            servicos.AddControllers();

            servicos.AddScoped<ITaxaJurosRequest, TaxaJurosService>();
            
        }

    }
}