using System.ComponentModel.DataAnnotations;

namespace back_end.Entidades
{
    public class PeliculasActores
    {
        public int PeliculaId { get; set; }
        public int ActorId { get; set; }
        public Peliculas Pelicula { get; set; }
        public Actor Actor { get; set; }
        [StringLength(maximumLength: 100)]
        public string Personaje { get; set; }
        public int Orden { get; set; }
    }
}
