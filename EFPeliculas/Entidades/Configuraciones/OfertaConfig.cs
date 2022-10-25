using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EFPeliculas.Entidades.Configuraciones
{
    public class OfertaConfig : IEntityTypeConfiguration<CineOferta>
    {
        public void Configure(EntityTypeBuilder<CineOferta> builder)
        {
            builder.Property(prop => prop.PorcentajeDescuento)
                .HasPrecision(precision: 5, scale: 2);
        }
    }
}
