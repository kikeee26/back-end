﻿using backend.Migrations;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace back_end.Entidades
{
    public class Rating
    {
        public int Id{ get; set; }
        [Range(1, 5)]
        public int Puntuacion { get; set; }
        public int PeliculaId { get; set; }
        public Peliculas Pelicula { get; set; }
        public string UsuarioId { get; set; }
        public IdentityUser Usuario { get; set; }

    }
}
