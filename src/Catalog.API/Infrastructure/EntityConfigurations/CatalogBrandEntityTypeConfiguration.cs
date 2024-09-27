namespace Catalog.API.Infrastructure.EntityConfigurations;

public class CatalogBrandEntityTypeConfiguration : 
    IEntityTypeConfiguration<CatalogBrand>
{
    public void Configure(EntityTypeBuilder<CatalogBrand> builder)
    {
        builder.ToTable("CatalogBrand");

        builder.Property(cb => cb.Name).HasMaxLength(50);
    }
}
