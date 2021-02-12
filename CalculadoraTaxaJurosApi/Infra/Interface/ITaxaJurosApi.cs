using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculadoraTaxaJurosApi.Infra.Interface
{
    public interface ITaxaJurosApi
    {
        Task<decimal> GetTaxaJurosApi();
    }
}
