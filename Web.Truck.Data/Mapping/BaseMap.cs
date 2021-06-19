using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web.Truck.Domain.Entities;

namespace Web.Truck.Data.Mapping
{
    public class BaseMap<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> entity)
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).IsRequired();
            entity.Property(x => x.Ativo).IsRequired();
            entity.Property(x => x.DataCadastro).IsRequired();
            entity.Ignore(x => x.Valido);
            entity.Ignore(x => x.ValidationResult);
        }
    }
}
