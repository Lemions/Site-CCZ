using System;
using System.Collections.Generic;

namespace SiteCCZ.Models
{
    public partial class Animaisvacinas
    {
        public int IdAnimalVacina { get; set; }
        public int IdAnimal { get; set; }
        public int IdVacina { get; set; }
        public DateTime? DataVacina { get; set; }
        public DateTime? DataProxVacina { get; set; }

        public virtual Animaisccz IdAnimalNavigation { get; set; }
        public virtual Vacinas IdVacinaNavigation { get; set; }
    }
}
