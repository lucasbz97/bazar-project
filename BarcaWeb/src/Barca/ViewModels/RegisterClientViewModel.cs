﻿using System.ComponentModel.DataAnnotations;

namespace Barca.ViewModels
{
    public class RegisterClientViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [EmailAddress(ErrorMessage = "O campo {0} esta em formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "As senhas não conferem")]
        public string ComfirmPassword { get; set; }

        public string UserToken { get; set; }

        public string ClientToken { get; set; }
    }
}
