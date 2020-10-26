using System;
using System.Collections.Generic;

namespace SiteCCZ.Models
{
    public partial class Animaisccz
    {
        public Animaisccz()
        {
            Animaisvacinas = new HashSet<Animaisvacinas>();
            Animaisvermifugos = new HashSet<Animaisvermifugos>();
            Contatosadocao = new HashSet<Contatosadocao>();
        }

        public int IdAnimal { get; set; }
        public string Especie { get; set; }
        public string Sexo { get; set; }
        public string Nome { get; set; }
        public string Foto { get; set; }
        public string IdadeAprox { get; set; }
        public string Porte { get; set; }
        public string Cor { get; set; }
        public string Raca { get; set; }
        public string Historia { get; set; }
        public string StatusAnimal { get; set; }
        public string Adotavel { get; set; }

        public virtual ICollection<Animaisvacinas> Animaisvacinas { get; set; }
        public virtual ICollection<Animaisvermifugos> Animaisvermifugos { get; set; }
        public virtual ICollection<Contatosadocao> Contatosadocao { get; set; }
    }
}
