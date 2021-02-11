using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxaJutosApi.Domain.Extensão;
using TaxaJutosApi.Domain.Interface;

namespace TaxaJutosApi.Domain.Service
{
    public class TaxaJurosService : ITaxaJurosRequest
    {
        private IOptions<AppSettings> configuracoes;
        public decimal GetTaxaJuros()
        {
            return configuracoes.Value.TaxaJuros;
        }
    }
}
