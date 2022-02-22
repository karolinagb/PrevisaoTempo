using System;
using System.Collections.Generic;

#nullable disable

namespace PrevisaoTempo.Models
{
    public partial class Cidade
    {
        public Cidade()
        {
            PrevisaoClimas = new HashSet<PrevisaoClima>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int EstadoId { get; set; }

        public virtual Estado Estado { get; set; }
        public virtual ICollection<PrevisaoClima> PrevisaoClimas { get; set; }
    }
}
