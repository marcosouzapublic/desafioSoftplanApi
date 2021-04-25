using Microsoft.AspNetCore.Mvc;
using desafioSoftplan.Contracts;
using desafioSoftplan.Models;

namespace desafioSoftplan.Controllers{

    /// <summary>
    /// Controlador ShowMeTheCode.
    /// Controla o acesso do usu�rio �s classes e m�todos que manipulam a URL do reposit�rio do GitHub que cont�m o c�digo fonte da aplica��o.
    /// </summary>
    [ApiController]
    [Route("showmethecode")]
    public class ShowMeTheCodeController : ControllerBase {

        /// <summary>
        /// [GET] Endpoint ShowMeTheCode.
        /// Retorna uma string contendo a URL do reposit�rio onde se encontra o c�digo fonte da aplica��o.
        /// </summary>
        [HttpGet]
        [Route("/showmethecode")]
        public string ObterCodigoFonte([FromServices] IShowMeTheCode showMeTheCode)
        {
            return showMeTheCode.ShowMeTheCode();
        }
    }

}