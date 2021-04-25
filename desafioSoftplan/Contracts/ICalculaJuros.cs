namespace desafioSoftplan.Contracts
{
    public interface ICalculaJuros
    {
        public decimal ValorInicial { get; set; }
        public int DiasCorridos { get; set; }
        public double CalculaJurosFatura(decimal valorInicial, int mesesCorridos);
    }
}
