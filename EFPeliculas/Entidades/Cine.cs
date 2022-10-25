using NetTopologySuite.Geometries;

namespace EFPeliculas.Entidades
{
    public class Cine
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Point Ubicacion { get; set; }
        public CineOferta cineOferta { get; set; }
        public HashSet<SalaCine> SalaCines { get; set; }
        
    }
}
