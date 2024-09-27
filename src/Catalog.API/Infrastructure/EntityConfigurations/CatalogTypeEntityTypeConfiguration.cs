namespace Catalog.API.Infrastructure.EntityConfigurations;

class CatalogTypeEntityTypeConfiguration : 
    IEntityTypeConfiguration<CatalogType>
{
    public void Configure(EntityTypeBuilder<CatalogType> builder)
    {
        builder.ToTable("CatalogType");

        builder.Property(cb => cb.Name)
            .HasMaxLength(50);
    }
}
