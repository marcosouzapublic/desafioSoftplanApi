using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using desafioSoftplan.Models;
using desafioSoftplan.Contracts;
using System.Net.Http;
using Xunit;

namespace desafioSoftplanTestes.Models
{
    public class CalculaJurosTeste
    {
        ICalculaJuros _calculaJuros;

        public CalculaJurosTeste()
        {
            var apiConsumer = new ApiJurosConsumer(new HttpClient() {BaseAddress = new Uri("http://localhost:5001/taxajuros")});
            _calculaJuros = new CalculaJuros(apiConsumer);
        }

        [Fact]
        public void CalculaJurosFatura_QuandoChamado_SeCalculoEstaCorreto()
        {
            //Act
            var jurosCalculados = _calculaJuros.CalculaJurosFatura(100, 5);

            //Assert
            Assert.True(jurosCalculados == 105.10100501m);
        }

        [Fact]
        public void CalculaExibicaoJuros_QuandoChamado_SeExibicaoEstaCorreta()
        {
            //Act
            var jurosFormatados = _calculaJuros.ExibeJurosCalculados(100,5);

            //Assert
            Assert.True(jurosFormatados == "105,10");
        }
    }
}
