using System;
using System.Collections.Generic;

namespace SiteCCZ.Models
{
    public partial class Contatosadocao
    {
        public int IdContatoAdocao { get; set; }
        public int IdAnimal { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Justificativa { get; set; }

        public virtual Animaisccz IdAnimalNavigation { get; set; }
    }
}
