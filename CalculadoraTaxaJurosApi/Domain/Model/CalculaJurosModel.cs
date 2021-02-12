using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculadoraTaxaJurosApi.Domain.Model
{
    public class CalculaJurosModel
    {
        public decimal TaxaJuros { get; set; }
        public decimal ValorInicial { get; set; }
        public int Meses { get; set; }

        public decimal Resultado { get; set; }
    }
}
