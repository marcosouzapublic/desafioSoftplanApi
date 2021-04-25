using Microsoft.AspNetCore.Mvc;
using desafioSoftplan.Contracts;
using desafioSoftplan.Models;
using System.ComponentModel.DataAnnotations;

namespace desafioSoftplan.Controllers
{
    /// <summary>
    /// Controlador JurosController.
    /// Controla o acesso do usuário às classes e métodos que manipulam os juros dentro do app.
    /// </summary>
    [ApiController]
    [Route("juros")]
    public class JurosController : ControllerBase
    {
        /// <summary>
        /// [GET] Endpoint ObterTaxaJuros.
        /// Provê a taxa de juros atual fixada no sistema.
        /// </summary>
        [HttpGet]
        [Route("/taxajuros")]
        public decimal ObterTaxaJuros([FromServices] ITaxaJuros taxaJurosBase)
        {
            return taxaJurosBase.Taxa;
        }

        /// <summary>
        /// [GET] Endpoint CalculaJuros.
        /// Provê o cálculo dos juros compostos de uma conta vencida, com valor inicial e tempo corrido fornecidos pelo usuário.
        /// </summary>
        [HttpGet]
        [Route("/calculajuros")]
        public string ObterCalculoJuros([FromServices] ICalculaJuros calculaJuros, [Required] decimal valorInicial, [Required] int mesesCorridos)
        {
            return calculaJuros.ExibeJurosCalculados(valorInicial, mesesCorridos);
        }
    }

}