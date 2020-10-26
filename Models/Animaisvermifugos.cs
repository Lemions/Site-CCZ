using System;
using System.Collections.Generic;

namespace SiteCCZ.Models
{
    public partial class Animaisvermifugos
    {
        public int IdAnimalVermifugo { get; set; }
        public int IdAnimal { get; set; }
        public int IdVermifugo { get; set; }
        public DateTime? DataVermifugo { get; set; }
        public DateTime? DataProxVermifugo { get; set; }

        public virtual Animaisccz IdAnimalNavigation { get; set; }
        public virtual Vermifugos IdVermifugoNavigation { get; set; }
    }
}
