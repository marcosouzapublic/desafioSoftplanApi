using System.Net.Http;
using desafioSoftplan.Contracts;

namespace desafioSoftplan.Models
{
    /// <summary>
    /// Classe ApiJurosComsumer.
    /// Classe responsável por consumir a API que exibe os juros atuais.
    /// </summary>
    public class ApiJurosConsumer : IApiJurosConsumer
    {
        public HttpClient HttpClient { get; set; }

        public ApiJurosConsumer(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public decimal ObterTaxaJuros()
        {
            var response = HttpClient.GetAsync(HttpClient.BaseAddress.AbsoluteUri).Result;
            var juros = decimal.Parse(response.Content.ReadAsStringAsync().Result);

            return juros / 100;
        }
    }
}
