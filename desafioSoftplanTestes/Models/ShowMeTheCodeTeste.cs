using desafioSoftplan.Models;
using desafioSoftplan.Contracts;
using Xunit;

namespace desafioSoftplanTestes.Models
{
    public class ShowMeTheCodeTeste
    {
        IShowMeTheCode _showMeTheCode;

        public ShowMeTheCodeTeste()
        {
            _showMeTheCode = new ShowMeTheCode("https://github.com/marcosouzapublic/desafioSoftplanApi");
        }

        [Fact]
        public void ShowMeTheCode_QuandoChamado_SeRetornaUrlCorreta()
        {
            //Act
            var urlRepository = _showMeTheCode.ShowMeTheCode();

            //Assert
            Assert.True(urlRepository == "https://github.com/marcosouzapublic/desafioSoftplanApi");
        }
    }
}
