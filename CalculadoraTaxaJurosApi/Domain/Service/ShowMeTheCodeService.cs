using CalculadoraTaxaJurosApi.Domain.Interface;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxaJurosApi.Domain.Model;

namespace CalculadoraTaxaJurosApi.Domain.Service
{
    public class ShowMeTheCodeService : IShowmeTheCode
    {
        private readonly IOptions<AppSettings> configuracoes;
        public ShowMeTheCodeService(IOptions<AppSettings> configuracoes)
        {
            this.configuracoes = configuracoes;
        }
        public string GetUrlProjeto()
        {
            try
            {
                
                if (!string.IsNullOrWhiteSpace(this.configuracoes.Value.ProjetoGit))
                {
                    return this.configuracoes.Value.ProjetoGit;
                }
                throw new ApplicationException("Não foi encontrado o endereço do projeto, favor verificar o AppSettings");
            }
            catch (Exception)
            {
                throw new ApplicationException("Não foi encontrado o endereço do projeto, favor verificar o AppSettings");
            }
        }
    }
}
