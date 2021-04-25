using Microsoft.AspNetCore.Mvc;
using desafioSoftplan.Contracts;
using desafioSoftplan.Models;

namespace desafioSoftplan.Controllers{

    [ApiController]
    [Route("showmethecode")]
    public class ShowMeTheCodeController : ControllerBase {

        [HttpGet]
        [Route("/showmethecode")]
        public string ObterCodigoFonte([FromServices] IShowMeTheCode showMeTheCode)
        {
            return showMeTheCode.ShowMeTheCode();
        }
    }

}