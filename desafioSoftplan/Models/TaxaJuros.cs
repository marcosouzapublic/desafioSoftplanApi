using desafioSoftplan.Contracts;


namespace desafioSoftplan.Models{

    public class TaxaJuros : ITaxaJuros{
        public decimal Taxa { get; set; }
        public TaxaJuros(){
            this.Taxa = 0.01m;
        }
    }
}