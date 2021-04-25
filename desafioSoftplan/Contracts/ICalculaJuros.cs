namespace desafioSoftplan.Contracts
{
    /// <summary>
    /// Interface ICalculaJuros.
    /// Fornece uma base sólida para implementação de uma classe realiza cálculos de juros compostos.
    /// </summary>
    public interface ICalculaJuros
    {
        public decimal ValorInicial { get; set; }
        public int DiasCorridos { get; set; }
        public decimal CalculaJurosFatura(decimal valorInicial, int mesesCorridos);

        public string ExibeJurosCalculados(decimal valorInicial, int mesesCorridos);
    }
}
