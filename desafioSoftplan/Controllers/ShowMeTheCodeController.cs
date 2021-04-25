using Microsoft.AspNetCore.Mvc;
using desafioSoftplan.Contracts;
using desafioSoftplan.Models;

namespace desafioSoftplan.Controllers{

    /// <summary>
    /// Controlador ShowMeTheCode.
    /// Controla o acesso do usuário às classes e métodos que manipulam a URL do repositório do GitHub que contém o código fonte da aplicação.
    /// </summary>
    [ApiController]
    [Route("showmethecode")]
    public class ShowMeTheCodeController : ControllerBase {

        /// <summary>
        /// [GET] Endpoint ShowMeTheCode.
        /// Retorna uma string contendo a URL do repositório onde se encontra o código fonte da aplicação.
        /// </summary>
        [HttpGet]
        [Route("/showmethecode")]
        public string ObterCodigoFonte([FromServices] IShowMeTheCode showMeTheCode)
        {
            return showMeTheCode.ShowMeTheCode();
        }
    }

}