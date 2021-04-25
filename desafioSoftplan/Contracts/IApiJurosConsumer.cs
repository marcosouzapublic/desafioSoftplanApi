using System.Net.Http;

namespace desafioSoftplan.Contracts
{
    /// <summary>
    /// Interface IApiJurosConsumer.
    /// Fornece uma base sólida para implementação de uma classe que fará o consumo de uma API para controle de juros.
    /// </summary>
    public interface IApiJurosConsumer
    {
        public HttpClient HttpClient { get; set; }
        public decimal ObterTaxaJuros();
    }
}
