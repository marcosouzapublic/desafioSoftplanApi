using desafioSoftplan.Contracts;


namespace desafioSoftplan.Models{

    /// <summary>
    /// Classe Taxa Juros
    /// Fornece a taxa de juros atual, fixada a 1%. 
    /// </summary>
    public class TaxaJuros : ITaxaJuros{
        public decimal Taxa { get; set; }
        public TaxaJuros(){
            this.Taxa = 0.01m;
        }
    }
}