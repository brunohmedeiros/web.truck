using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web.Truck.Domain.Entities;

namespace Web.Truck.Data.Mapping
{
    public class CaminhaoMap : BaseMap<Caminhao>
    {
        public override void Configure(EntityTypeBuilder<Caminhao> entity)
        {
            base.Configure(entity);
            entity.ToTable("Caminhao");

            entity.Property(x => x.AnoFabricacao).IsRequired();
            entity.Property(x => x.AnoModelo).IsRequired();

            entity.HasOne<Modelo>(x => x.Modelo)
                .WithMany(y => y.Caminhaos)
                .HasForeignKey(z => z.ModeloId);
        }
    }
}
