using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using desafioSoftplan.Contracts;
using desafioSoftplan.Models;
using System.Net.Http;
using Xunit;

namespace desafioSoftplanTestes.Models
{
    public class ApiConsumerTeste
    {
        IApiJurosConsumer _apiJurosConsumer;

        public ApiConsumerTeste()
        {
            _apiJurosConsumer = new ApiJurosConsumer(new HttpClient() {BaseAddress = new Uri("http://localhost:5001/taxajuros")});
        }

        [Fact]
        public void ObterTaxaJuros_QuandoChamado_RetornaTaxaJurosFixa()
        {
            //Act
            var taxaJuros = _apiJurosConsumer.ObterTaxaJuros();

            //Assert
            Assert.True(taxaJuros == 0.01m);
        }
    }
}
