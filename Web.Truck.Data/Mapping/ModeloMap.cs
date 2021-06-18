using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web.Truck.Domain.Entities;

namespace Web.Truck.Data.Mapping
{
    public class ModeloMap : BaseMap<Modelo>
    {
        public override void Configure(EntityTypeBuilder<Modelo> entity)
        {
            base.Configure(entity);
            entity.ToTable("Modelo");

            entity.Property(x => x.Descricao).IsRequired();
            entity.HasIndex(x => x.Descricao).IsUnique();
        }
    }
}
