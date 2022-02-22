using System.Collections.Generic;

namespace PrevisaoTempo.Models.ViewModels
{
    public class PrevisaoCidadeViewModel
    {
        public List<PrevisaoClima> PrevisoesMaxima { get; set; }
        public List<PrevisaoClima> PrevisoesMinima { get; set; }
        public List<Cidade> Cidades { get; set; }
    }
}
