namespace back_end.Entidades
{
    public class PeliculasGeneros
    {
        public int PeliculaId { get; set; }
        public int GeneroId { get; set; }
        public Peliculas Pelicula { get; set; }
        public Genero Genero { get; set; }
    }
}
