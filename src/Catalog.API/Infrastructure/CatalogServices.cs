﻿namespace Catalog.API.Infrastructure;

public class CatalogServices(
    CatalogContext context,
    IOptions<CatalogOptions> options,
    ILogger<CatalogServices> logger
    // ICatalogIntegrationEventService EventService eventService
    )
{
    public CatalogContext Context { get; } = context;
    public IOptions<CatalogOptions> Options { get; } = options;
    public ILogger<CatalogServices> Logger { get; } = logger;
    // public ICatalogIntegrationEventService EventService { get; } = eventService;
}
