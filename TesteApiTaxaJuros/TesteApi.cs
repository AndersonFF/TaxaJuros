using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Globalization;
using TaxaJutosApi.Domain.Interface;
using TaxaJutosApi.Domain.Service;
using Xunit;

namespace TesteApiTaxaJuros
{
    public class TesteApi : IClassFixture<Inicializar>
    {

        private readonly ServiceProvider provedorServico;

        public TesteApi(Inicializar inicializar)
        {
            provedorServico = inicializar.ProvedorServico;
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
