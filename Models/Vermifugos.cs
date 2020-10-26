using System;
using System.Collections.Generic;

namespace SiteCCZ.Models
{
    public partial class Vermifugos
    {
        public Vermifugos()
        {
            Animaisvermifugos = new HashSet<Animaisvermifugos>();
        }

        public int IdVermifugo { get; set; }
        public string Nome { get; set; }
        public int? Periodicidade { get; set; }

        public virtual ICollection<Animaisvermifugos> Animaisvermifugos { get; set; }
    }
}
