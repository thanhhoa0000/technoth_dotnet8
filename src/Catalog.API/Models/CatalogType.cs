namespace Catalog.API.Models;

public class CatalogType
{
    public Guid Id { get; set; }
    
    [Required] 
    public string Name { get; set; }
}
