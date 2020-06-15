using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class ManagerMap : IEntityTypeConfiguration<ManagerEntity>
    {
        public void Configure(EntityTypeBuilder<ManagerEntity> builder)
        {
            builder.ToTable("Manager");

            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Email);
            builder.HasIndex(p => p.IPV4);
            builder.HasIndex(p => p.TAG);
            builder.HasIndex(p => p.Crm_START);
            builder.HasIndex(p => p.Vendas_START);
            builder.HasIndex(p => p.Faturamento_START);
            builder.HasIndex(p => p.Site_START);
            builder.HasIndex(p => p.PORT);
            builder.HasIndex(p => p.LICENSES);

            builder.Property(p => p.Name).IsRequired().HasMaxLength(60);
            builder.Property(p => p.Email).IsRequired().HasMaxLength(100);
            builder.Property(p => p.IPV4).HasMaxLength(100);
            builder.Property(p => p.TAG).HasMaxLength(100);
            builder.Property(p => p.Crm_START).IsRequired();
            builder.Property(p => p.Vendas_START).IsRequired();
            builder.Property(p => p.Faturamento_START).IsRequired();
            builder.Property(p => p.Site_START).IsRequired();
            builder.Property(p => p.PORT).HasMaxLength(100);
            builder.Property(p => p.LICENSES).HasMaxLength(3);
        }


    }
}
