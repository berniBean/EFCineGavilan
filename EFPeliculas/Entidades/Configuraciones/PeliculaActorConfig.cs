using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EFPeliculas.Entidades.Configuraciones
{
    public class PeliculaActorConfig : IEntityTypeConfiguration<PeliculaActor>
    {
        public void Configure(EntityTypeBuilder<PeliculaActor> builder)
        {
            builder.HasKey(prop =>
            new { prop.ActorId, prop.PeliculaId });

            builder.Property(prop => prop.Personaje)
                .HasMaxLength(150);
        }
    }
}
