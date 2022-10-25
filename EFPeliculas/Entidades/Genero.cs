using System.ComponentModel.DataAnnotations;

namespace EFPeliculas.Entidades
{
    public class Genero
    {

        //[Key]
        public int Identificador { get; set; }
        public string Nombre { get; set; }
        public HashSet<Pelicula> Peliculas { get; set; }
    }
}
