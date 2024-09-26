﻿namespace Catalog.API.Models;

public class CatalogBrand
{
    public Guid Id { get; set; }
    
    [Required]
    public string Name { get; set; }
}