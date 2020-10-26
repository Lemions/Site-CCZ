using System;
using System.Collections.Generic;

namespace SiteCCZ.Models
{
    public partial class Animaisperdidos
    {
        public int IdAnimalPerdido { get; set; }
        public string Nome { get; set; }
        public string Especie { get; set; }
        public string Raca { get; set; }
        public string Foto { get; set; }
        public string TelefoneDono { get; set; }
        public string Detalhes { get; set; }
    }
}
