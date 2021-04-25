namespace desafioSoftplan.Contracts
{
    public interface ICalculaJuros
    {
        public decimal ValorInicial { get; set; }
        public int DiasCorridos { get; set; }
        public decimal CalculaJurosFatura(decimal valorInicial, int mesesCorridos);

        public string ExibeJurosCalculados(decimal valorInicial, int mesesCorridos);
    }
}
