namespace Catalog.API.Models;

public class CatalogItem
{
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    public Decimal Price { get; set; }
    public string PictureFileName { get; set; }
    public int AvailableStock { get; set; }
    public int RestockThreshold { get; set; }
    public int MaxStockThreshold { get; set; }
    public bool OnReorder { get; set; }
    
    public Guid CatalogTypeId { get; set; }
    public CatalogType CatalogType { get; set; }
    
    public Guid CatalogBrandId { get; set; }
    public CatalogBrand CatalogBrand { get; set; }

    public int RemoveStock(int quantityDesired)
    {
        if (AvailableStock == 0)
        {
            throw new CatalogDomainException($"Product '{Name}' is sold out");
        }

        if (quantityDesired <= 0)
        {
            throw new CatalogDomainException($"Quantity should be greater than 0");
        }

        int removed = Math.Min(quantityDesired, AvailableStock);

        AvailableStock -= removed;

        return removed;
    }

    public int AddStock(int quantity)
    {
        int original = AvailableStock;

        if ((AvailableStock + quantity) > MaxStockThreshold)
        {
            // TODO: Handle overstock
            AvailableStock += (MaxStockThreshold - AvailableStock);
        }
        else
        {
            AvailableStock += quantity;
        }

        OnReorder = false;

        return AvailableStock - original;
    }
}
