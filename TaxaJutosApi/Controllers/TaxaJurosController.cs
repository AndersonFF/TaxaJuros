using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using TaxaJutosApi.Domain.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaxaJutosApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TaxaJurosController : ControllerBase
    {
        private readonly ITaxaJurosRequest _taxaJurosService;
        public TaxaJurosController(ITaxaJurosRequest taxaJurosService)
        {
            _taxaJurosService = taxaJurosService;
        }

        [HttpGet("/taxaJuros")]
        [EnableCors("AllowMyOrigin")]
        [ProducesResponseType(200)]
        public ActionResult<decimal> Get()
        {
            try
            {
                return Ok(0.01);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

       
    }
}
