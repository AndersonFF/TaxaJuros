using CalculadoraTaxaJurosApi.Domain.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CalculadoraTaxaJurosApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CalculaJurosController : Controller
    {
        private readonly ICalculaTaxaJuros _calculaTaxaJuros;
        private readonly IShowmeTheCode _showmeTheCode;

        public CalculaJurosController(ICalculaTaxaJuros calculaTaxaJuros, IShowmeTheCode showmeTheCode)
        {
            _calculaTaxaJuros = calculaTaxaJuros;
            _showmeTheCode = showmeTheCode;
        }

        [HttpGet("/calculajuros")]
        [EnableCors("AllowMyOrigin")]
        [ProducesResponseType(200)]
        public ActionResult<string> Get(decimal valorInicial, int Meses)
        {
            try
            {
                var CalculaTaxaJuros = _calculaTaxaJuros.CalcularTaxaJuros(valorInicial, Meses).ToString("F2", CultureInfo.CurrentCulture);

                return Ok(CalculaTaxaJuros);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("/showmethecode")]
        [EnableCors("AllowMyOrigin")]
        [ProducesResponseType(200)]
        public ActionResult<string> showmethecodeGet()
        {
            try
            {

                return Ok(_showmeTheCode.GetUrlProjeto());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
