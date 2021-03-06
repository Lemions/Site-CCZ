using System;
using SiteCCZ.Models;

namespace SiteCCZ.ViewModel
{
    public class AdocaoViewModel
    {
        public Animaisccz Animal;
        public int IdAnimal { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Justificativa { get; set; }
        public virtual Animaisccz IdAnimalNavigation { get; set; }

    }
}