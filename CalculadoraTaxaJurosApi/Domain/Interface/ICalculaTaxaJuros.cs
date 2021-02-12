using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculadoraTaxaJurosApi.Domain.Interface
{
    public interface ICalculaTaxaJuros
    {
        decimal CalcularTaxaJuros(decimal valorInicial, int meses);
    }
}
