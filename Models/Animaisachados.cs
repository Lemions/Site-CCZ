using System;
using System.Collections.Generic;

namespace SiteCCZ.Models
{
    public partial class Animaisachados
    {
        public int IdAnimalAchado { get; set; }
        public string Foto { get; set; }
        public string DescricaoFoto { get; set; }
        public string Especie { get; set; }
        public string Raca { get; set; }
        public string AchadorNome { get; set; }
        public string AchadorTelefone { get; set; }
        public string Bairro { get; set; }
        public string Detalhes { get; set; }
    }
}
