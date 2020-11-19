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
        public string Foto { get; set; }
        public string DescricaoImagem { get; set; }
        public string Titulo { get; set; }
        public string OlhoPost { get; set; }
    }
}