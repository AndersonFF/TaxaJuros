using CalculadoraTaxaJurosApi.Infra.Interface;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TaxaJutosApi.Domain.Model;

namespace CalculadoraTaxaJurosApi.Infra.Service
{
    public class TaxaJurosApiService : ITaxaJurosApi
    {
        private readonly HttpClient _httpClient;
        private readonly IOptions<AppSettings> _configuracoes;
        private string Endpoint;
        public TaxaJurosApiService(HttpClient httpClient, IOptions<AppSettings> configuracoes)
        {
            _httpClient = httpClient;
            _configuracoes = configuracoes;
        }

        public async Task<decimal> GetTaxaJurosApi()
        {
             Endpoint = _configuracoes.Value.TaxaJurosApi;

             var resposta = await _httpClient.GetStringAsync($"{Endpoint}/taxajuros");
            decimal Valor = decimal.Parse(resposta, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture); ;
            return Valor;
        }
    }
}
