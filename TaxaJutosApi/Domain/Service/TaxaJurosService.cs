using Microsoft.Extensions.Options;
using System;
using TaxaJurosApi.Domain.Model;
using TaxaJurosApi.Domain.Interface;

namespace TaxaJurosApi.Domain.Service
{
    public class TaxaJurosService : ITaxaJurosRequest
    {
        private readonly IOptions<AppSettings> configuracoes;
        public TaxaJurosService(IOptions<AppSettings> configuracoes)
        {
            this.configuracoes = configuracoes;
        }

        public decimal GetTaxaJuros()
        {
            try
            {
                int valorInteiro;
                if(int.TryParse(this.configuracoes.Value.TaxaJuros.ToString(), out valorInteiro))
                {
                    return this.configuracoes.Value.TaxaJuros / 100;
                }
                return this.configuracoes.Value.TaxaJuros;
            }
            catch (Exception e) {
                throw new ApplicationException("Valor de taxa de juros configurado se encontra fora do padrão aceito pela aplicação, favor verificar.");
            }
        }
    }
}
