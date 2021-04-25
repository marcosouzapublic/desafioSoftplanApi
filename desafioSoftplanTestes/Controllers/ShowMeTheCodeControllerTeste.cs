using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using desafioSoftplan.Contracts;
using desafioSoftplan.Controllers;
using desafioSoftplan.Models;
using Xunit;

namespace desafioSoftplanTestes.Controllers
{
    public class ShowMeTheCodeControllerTeste
    {
        ShowMeTheCodeController _controller;
        IShowMeTheCode _contract;

        public ShowMeTheCodeControllerTeste()
        {
            _controller = new ShowMeTheCodeController();
            _contract = new ShowMeTheCode("https://github.com/marcosouzapublic/desafioSoftplanApi");
        }

        [Fact]
        public void ObterCodigoFonte_QuandoChamado_ObtemUrlCodigoFonte()
        {
            //Act
            var urlGitHub = _controller.ObterCodigoFonte(_contract);

            //Assert
            Assert.True(!String.IsNullOrEmpty(urlGitHub));
        }

    }
}
