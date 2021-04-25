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

        public decimal CalculaJurosFatura(decimal valorInicial, int mesesCorridos)
        {
            var taxaJuros = _apiJurosConsumer.ObterTaxaJuros();
            var potencia = Math.Pow(Convert.ToDouble(1 + taxaJuros), Convert.ToDouble(mesesCorridos));
            var valorFinal = valorInicial * Convert.ToDecimal(potencia);

            return valorFinal;
        }

        public string ExibeJurosCalculados(decimal valorInicial, int mesesCorridos)
        {
            var jurosCalculados = CalculaJurosFatura(valorInicial, mesesCorridos);

            return String.Format("{0:0.00}", jurosCalculados);
        }
    }
}
