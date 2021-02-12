using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Globalization;
using TaxaJurosApi.Domain.Interface;
using TaxaJurosApi.Domain.Service;
using Xunit;

namespace TesteApiTaxaJuros
{
    public class TesteApi : IClassFixture<Inicializar>
    {

        private readonly ServiceProvider provedorServico;
        private readonly IConfiguration configuracao;
        public TesteApi(Inicializar inicializar)
        {
            provedorServico = inicializar.ProvedorServico;
            configuracao = inicializar.configuracao;
        }

        [Fact]
        public void ObterTaxaJuros()
        {
            
            var teste = provedorServico.GetService<ITaxaJurosRequest>();
            
            decimal resultado = teste.GetTaxaJuros();
            Assert.Equal("0,01", resultado.ToString("F2", CultureInfo.CurrentCulture));
        }
    }
}
