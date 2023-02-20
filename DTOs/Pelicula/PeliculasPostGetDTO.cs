using back_end.DTOs.Cine;
using back_end.DTOs.Genero;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace back_end.DTOs.Pelicula
{
    public class PeliculasPostGetDTO
    {
        public List<GeneroDTO> Generos { get; set; }
        public List<CineDTO> Cines { get; set; }
    }
}
