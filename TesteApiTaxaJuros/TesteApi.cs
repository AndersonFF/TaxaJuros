using Microsoft.Extensions.Options;
using System;
using System.Globalization;
using TaxaJutosApi.Domain.Extensão;
using TaxaJutosApi.Domain.Service;
using Xunit;

namespace TesteApiTaxaJuros
{
    public class TesteApi
    {
        private IOptions<AppSettings> configuracoes;
        public TesteApi(IOptions<AppSettings> configuracoes)
        {
            this.configuracoes = configuracoes;
        }

        [Fact]
        public void ObterTaxaJuros()
        {
            var taxajuros = new TaxaJurosService(this.configuracoes);
            decimal resultado = taxajuros.GetTaxaJuros();
            Assert.Equal("0,01", resultado.ToString("F2", CultureInfo.CurrentCulture));
        }
    }
}
