using desafioSoftplan.Contracts;

namespace desafioSoftplan.Models
{
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
