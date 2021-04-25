using System;
using System.ComponentModel.DataAnnotations;
using desafioSoftplan.Contracts;

namespace desafioSoftplan.Models
{
    public class CalculaJuros : ICalculaJuros
    {
        private ApiJurosConsumer _apiJurosConsumer { get; set; }

        [Required]
        public decimal ValorInicial { get; set; }

        [Required]
        public int DiasCorridos { get; set; }

        public CalculaJuros(ApiJurosConsumer apiJurosConsumer)
        {
            _apiJurosConsumer = apiJurosConsumer;
        }

        public double CalculaJurosFatura(decimal valorInicial, int mesesCorridos)
        {
            var taxaJuros = _apiJurosConsumer.ObterTaxaJuros();
            var valorFinal = Math.Pow(Convert.ToDouble(valorInicial * (1 + taxaJuros)), Convert.ToDouble(mesesCorridos));

            return valorFinal;
        }
    }
}
