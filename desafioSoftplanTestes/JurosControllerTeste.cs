using Xunit;
using desafioSoftplan.Controllers;
using desafioSoftplan.Contracts;
using desafioSoftplan.Models;
using System.Net.Http;

namespace desafioSoftplanTestes
{
    public class JurosControllerTeste
    {
        JurosController _controller;
        ITaxaJuros _taxaJuros;
        ICalculaJuros _calculaJuros;

        public JurosControllerTeste()
        {
            _controller = new JurosController();
            _taxaJuros = new TaxaJuros();
            _calculaJuros = new CalculaJuros(new ApiJurosConsumer(new HttpClient() { BaseAddress = new System.Uri("http://localhost:5001/taxajuros") }));
        }

        [Fact]
        public void ObterTaxaJuros_QuandoChamado_RetornaTaxaJurosFixa()
        {
            //Act
            var taxaJuros = _controller.ObterTaxaJuros(_taxaJuros);

            //Assert
            Assert.True(taxaJuros == 0.01m);
        }

        [Fact]
        public void ObterCalculoJuros_QuandoChamado_RetornaCalculoJuros()
        {
            //Act
            var valorFinal = _controller.ObterCalculoJuros(_calculaJuros, 100, 5);

            //Assert
            Assert.True(valorFinal == 105.10);
        }

    }
}
