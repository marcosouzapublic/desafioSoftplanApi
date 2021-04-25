using Microsoft.AspNetCore.Mvc;
using desafioSoftplan.Contracts;
using desafioSoftplan.Models;
using System.ComponentModel.DataAnnotations;

namespace desafioSoftplan.Controllers
{

    [ApiController]
    [Route("juros")]
    public class JurosController : ControllerBase
    {

        [HttpGet]
        [Route("/taxajuros")]
        public decimal ObterTaxaJuros([FromServices] ITaxaJuros taxaJurosBase)
        {
            return taxaJurosBase.Taxa;
        }

        [HttpGet]
        [Route("/calculajuros")]
        public string ObterCalculoJuros([FromServices] ICalculaJuros calculaJuros, [Required] decimal valorInicial, [Required] int mesesCorridos)
        {
            return calculaJuros.ExibeJurosCalculados(valorInicial, mesesCorridos);
        }
    }

}