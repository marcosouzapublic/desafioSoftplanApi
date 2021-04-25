namespace desafioSoftplan.Contracts
{
    /// <summary>
    /// Interface IApiJurosConsumer.
    /// Fornece uma base sólida para implementação de uma classe que retorna uma URL de código fonte do GitHub.
    /// </summary>
    public interface IShowMeTheCode
    {
        string Url { get; set; }
        string ShowMeTheCode();
    }
}
