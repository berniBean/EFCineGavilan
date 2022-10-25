using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EFPeliculas.Entidades.Configuraciones
{
    public class SalaCineConfig : IEntityTypeConfiguration<SalaCine>
    {
        public void Configure(EntityTypeBuilder<SalaCine> builder)
        {
            builder.Property(prop => prop.Precio)
                .HasPrecision(precision: 9, scale: 2);
            builder.Property(prop => prop.TipoSalaCine)
                .HasDefaultValue(TipoSalaCine.DosDimensiones);
        }
    }
}
