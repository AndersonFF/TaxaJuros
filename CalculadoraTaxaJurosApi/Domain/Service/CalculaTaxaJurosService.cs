using CalculadoraTaxaJurosApi.Domain.Interface;
using CalculadoraTaxaJurosApi.Infra.Interface;
using Microsoft.Extensions.Options;
using System;
using TaxaJurosApi.Domain.Model;

namespace CalculadoraTaxaJurosApi.Domain.Service
{
    public class CalculaTaxaJurosService : ICalculaTaxaJuros
    {
        private readonly ITaxaJurosApi _taxaJurosApi;
        public CalculaTaxaJurosService(ITaxaJurosApi taxaJurosApi)
        {
            this._taxaJurosApi = taxaJurosApi;
        }
        public decimal CalcularTaxaJuros(decimal valorInicial, int meses)
        {
            decimal taxaJuros = RecuperarTaxaJuros();
           
            var juros  = (decimal)Math.Pow((double)(1 + taxaJuros), meses);
            var Resultado = valorInicial * juros;

            return Truncate(Resultado, 2);
        }

        private static decimal Truncate(decimal valor, int CasasDecimais)
        {
            //var ajustaValor = (decimal)Math.Pow(10, CasasDecimais);
            valor *= 100;
            valor = Math.Truncate(valor);
            valor /= 100;
            return valor;
        }

        private decimal RecuperarTaxaJuros()
        {
            decimal TaxaJuros = decimal.Parse(_taxaJurosApi.GetTaxaJurosApi().ToString());
            return TaxaJuros;
        }
    }
}
