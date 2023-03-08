using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using back_end.DTOs.Genero;
using back_end.DTOs.Cine;

namespace back_end.DTOs.Pelicula
{
    public class PeliculaDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Resumen { get; set; }
        public string Trailer { get; set; }
        public bool EnCines { get; set; }
        public DateTime FechaLanzamiento { get; set; }
        public string Poster { get; set; }
        public List<GeneroDTO> Generos { get; set; }
        public List<PeliculaActorDTO> Actores{ get; set; }
        public List<CineDTO> Cines { get; set; }
        public int votoUsuario { get; set; }
        public double PromedioVoto { get; set; }
    }
}
