using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiteCCZ.Models
{
    public class LoginViewModel
    {
        [Display(Name = "E-mail de Acesso", Prompt = "{0}")]
        [Required(ErrorMessage = "Por favor, informe seu E-mail de Acesso")]
        [EmailAddress(ErrorMessage = "Por favor, informe um E-mail Válido")]
        [StringLength(100, ErrorMessage = "Seu E-mail de acesso não possui mais de 100 caracteres")]
        public string Email { get; set; }

        [Display(Name = "Senha", Prompt = "{0}")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Por favor, informe sua Senha")]
        [StringLength(10, ErrorMessage = "Sua Senha não possui mais de {1} caracteres")]
        public string Senha { get; set; }
    }
}
