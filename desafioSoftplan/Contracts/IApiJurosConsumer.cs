using System.Net.Http;

namespace desafioSoftplan.Contracts
{
    public interface IApiJurosConsumer
    {
        public HttpClient HttpClient { get; set; }
        public decimal ObterTaxaJuros();
    }
}
