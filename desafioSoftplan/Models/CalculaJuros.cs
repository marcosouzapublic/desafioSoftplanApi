using System;
using System.ComponentModel.DataAnnotations;
using desafioSoftplan.Contracts;

namespace desafioSoftplan.Models
{
    /// <summary>
    /// Classe CalculaJuros.
    /// Trata do cálculo dos juros compostos gerados a partir de uma conta vencida.
    /// </summary>
    public class CalculaJuros : ICalculaJuros
    {
        private ApiJurosConsumer _apiJurosConsumer { get; set; }


        [Required(ErrorMessage = "O parâmetro valor inicial é obrigatório", AllowEmptyStrings = false)]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 9999999999999999.99)]
        public decimal ValorInicial { get; set; }

        [Required(ErrorMessage = "O parâmetro dias corridos é obrigatório", AllowEmptyStrings = false)]
        [Range(1, Int32.MaxValue)]
        public int DiasCorridos { get; set; }

        public CalculaJuros(ApiJurosConsumer apiJurosConsumer)
        {
            _apiJurosConsumer = apiJurosConsumer;
        }

        /// <summary>
        /// Método CalculaJurosFatura.
        /// Retorna um decimal com o montante da operação, utilizando a fórmula para juros compostos:
        /// ValorFinal = ValorInicial * (1 + Juros) ^ MesesCorridos.
        /// </summary>
        public decimal CalculaJurosFatura(decimal valorInicial, int mesesCorridos)
        {
            var taxaJuros = _apiJurosConsumer.ObterTaxaJuros();
            var potencia = Math.Pow(Convert.ToDouble(1 + taxaJuros), Convert.ToDouble(mesesCorridos));
            var valorFinal = valorInicial * Convert.ToDecimal(potencia);

            return valorFinal;
        }

        /// <summary>
        /// Método ExibeJurosCalculados.
        /// Retorna o valor gerado em CalculaJurosFatura formatado no padrão brasileiro de moeda, trucado, com 2 casas decimais.
        /// </summary>
        public string ExibeJurosCalculados(decimal valorInicial, int mesesCorridos)
        {
            var jurosCalculados = CalculaJurosFatura(valorInicial, mesesCorridos);

            return String.Format("{0:0.00}", jurosCalculados);
        }
    }
}
