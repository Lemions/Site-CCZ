using System;
using System.Collections.Generic;

namespace SiteCCZ.Models
{
    public partial class Vacinas
    {
        public Vacinas()
        {
            Animaisvacinas = new HashSet<Animaisvacinas>();
        }

        public int IdVacina { get; set; }
        public string Nome { get; set; }
        public int? Periodicidade { get; set; }
        public int? Doses { get; set; }

        public virtual ICollection<Animaisvacinas> Animaisvacinas { get; set; }
    }
}
