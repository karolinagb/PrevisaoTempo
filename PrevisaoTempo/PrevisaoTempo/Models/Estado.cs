using System;
using System.Collections.Generic;

#nullable disable

namespace PrevisaoTempo.Models
{
    public partial class Estado
    {
        public Estado()
        {
            Cidades = new HashSet<Cidade>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Uf { get; set; }

        public virtual ICollection<Cidade> Cidades { get; set; }
    }
}
