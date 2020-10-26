using System;
using System.Collections.Generic;

namespace SiteCCZ.Models
{
    public partial class Postsblog
    {
        public int IdPostBlog { get; set; }
        public DateTime? DataPublicacao { get; set; }
        public string Autor { get; set; }
        public string Conteudo { get; set; }
        public string Imagem { get; set; }
        public string DescricaoImagem { get; set; }
    }
}
