using Microsoft.AspNetCore.Mvc;
using desafioSoftplan.Contracts;
using System.ComponentModel.DataAnnotations;

namespace desafioSoftplan.Controllers
{
    /// <summary>
    /// Controlador JurosController.
    /// Controla o acesso do usu�rio �s classes e m�todos que manipulam os juros dentro do app.
    /// </summary>
    [ApiController]
    [Route("juros")]
    public class JurosController : ControllerBase
    {
        /// <summary>
        /// [GET] Endpoint ObterTaxaJuros.
        /// Prov� a taxa de juros atual fixada no sistema.
        /// </summary>
        [HttpGet]
        [Route("/taxajuros")]
        public decimal ObterTaxaJuros([FromServices] ITaxaJuros taxaJurosBase)
        {
            return taxaJurosBase.Taxa;
        }

        /// <summary>
        /// [GET] Endpoint CalculaJuros.
        /// Prov� o c�lculo dos juros compostos de uma conta vencida, com valor inicial e tempo corrido fornecidos pelo usu�rio.
        /// </summary>
        [HttpGet]
        [Route("/calculajuros")]
        public string ObterCalculoJuros([FromServices] ICalculaJuros calculaJuros, [Required] decimal valorInicial, [Required] int mesesCorridos)
        {
            return calculaJuros.ExibeJurosCalculados(valorInicial, mesesCorridos);
        }
    }

}