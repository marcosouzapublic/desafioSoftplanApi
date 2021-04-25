using desafioSoftplan.Contracts;

namespace desafioSoftplan.Models
{
    /// <summary>
    /// Classe ShowMeTheCode.
    /// Fornece uma URL contendo o repositório do GitHub onde se encontra o código fonte da aplicação.
    /// </summary>
    public class ShowMeTheCode : IShowMeTheCode
    {
        public string Url { get; set; }

        public ShowMeTheCode(string Url)
        {
            this.Url = Url;
        }
        string IShowMeTheCode.ShowMeTheCode()
        {
            return Url;
        }
    }
}
