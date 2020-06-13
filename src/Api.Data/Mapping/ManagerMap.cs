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
            builder.HasIndex(p => p.Crm_IPV4);
            builder.HasIndex(p => p.Vendas_IPV4);
            builder.HasIndex(p => p.Faturamento_IPV4);
            builder.HasIndex(p => p.Site_IPV4);
            builder.HasIndex(p => p.Crm_TAG);
            builder.HasIndex(p => p.Vendas_TAG);
            builder.HasIndex(p => p.Faturamento_TAG);
            builder.HasIndex(p => p.Site_TAG);
            builder.HasIndex(p => p.Crm_START);
            builder.HasIndex(p => p.Vendas_START);
            builder.HasIndex(p => p.Faturamento_START);
            builder.HasIndex(p => p.Site_START);
            builder.HasIndex(p => p.Crm_PORT);
            builder.HasIndex(p => p.Vendas_PORT);
            builder.HasIndex(p => p.Faturamento_PORT);
            builder.HasIndex(p => p.Site_PORT);
            builder.HasIndex(p => p.Crm_LICENSES);
            builder.HasIndex(p => p.Vendas_LICENSES);
            builder.HasIndex(p => p.Faturamento_LICENSES);
            builder.HasIndex(p => p.Site_LICENSES);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(60);
            builder.Property(p => p.Email).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Crm_IPV4).HasMaxLength(100);
            builder.Property(p => p.Vendas_IPV4).HasMaxLength(100);
            builder.Property(p => p.Faturamento_IPV4).HasMaxLength(100);
            builder.Property(p => p.Site_IPV4).HasMaxLength(100);
            builder.Property(p => p.Crm_TAG).HasMaxLength(100);
            builder.Property(p => p.Vendas_TAG).HasMaxLength(100);
            builder.Property(p => p.Faturamento_TAG).HasMaxLength(100);
            builder.Property(p => p.Site_TAG).HasMaxLength(100);
            builder.Property(p => p.Crm_START).IsRequired();
            builder.Property(p => p.Vendas_START).IsRequired();
            builder.Property(p => p.Faturamento_START).IsRequired();
            builder.Property(p => p.Site_START).IsRequired();
            builder.Property(p => p.Crm_PORT).HasMaxLength(100);
            builder.Property(p => p.Vendas_PORT).HasMaxLength(100);
            builder.Property(p => p.Faturamento_PORT).HasMaxLength(100);
            builder.Property(p => p.Site_PORT).HasMaxLength(10);
            builder.Property(p => p.Crm_LICENSES).HasMaxLength(3);
            builder.Property(p => p.Vendas_LICENSES).HasMaxLength(3);
            builder.Property(p => p.Faturamento_LICENSES).HasMaxLength(3);
            builder.Property(p => p.Site_LICENSES).HasMaxLength(3);


        }


    }
}
