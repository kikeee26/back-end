﻿using System.ComponentModel.DataAnnotations;

namespace back_end.DTOs.Usuarios
{
    public class CredencialesUsuario
    {
        [EmailAddress]
        [Required]
        public string Email{ get; set; }
        [Required]
        public string Password { get; set; }
    }
}
