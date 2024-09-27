using Microsoft.AspNetCore.Http.HttpResults;

namespace Catalog.API.Apis;

public static class CatalogApi
{
    public static IEndpointRouteBuilder MapCatalogApiV1(this IEndpointRouteBuilder app)
    {
        var api = app.MapGroup("api/catalog").HasApiVersion(1.0);

        api.MapGet("/items", GetAllItems);
        api.MapGet("/items/{id:guid}", GetItemById);
        api.MapGet("/items/by/{name:minlength(1)}", GetItemsByName);
        
        api.MapGet("/items/type/{typeId}/brand/{brandId?}", GetItemsByBrandAndTypeId);
        api.MapGet("/items/type/all/brand/{brandId:guid?}", GetItemsByBrandId);
        
        api.MapGet("/catalogtypes", async (CatalogContext context) => await context.CatalogTypes.OrderBy(x => x.Name).ToListAsync());
        api.MapGet("/catalogbrands", async (CatalogContext context) => await context.CatalogBrands.OrderBy(x => x.Name).ToListAsync());
        
        api.MapPut("/items", UpdateItem);
        api.MapPost("/items", CreateItem);
        api.MapDelete("/items/{id:guid}", DeleteItemById);

        return app;
    }

    public static async Task<Results<Ok<PaginatedItems<CatalogItem>>, BadRequest<string>>> GetAllItems(
        [AsParameters] PaginationRequest paginationRequest,
        [AsParameters] CatalogServices services)
    {
        var pageSize = paginationRequest.PageSize;
        var pageIndex = paginationRequest.PageIndex;

        var totalItems = await services.Context.CatalogItems
            .LongCountAsync();
        
        var itemsOnPage = await services.Context.CatalogItems
            .OrderBy(c => c.Name)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();

        return TypedResults.Ok(new PaginatedItems<CatalogItem>(pageIndex, pageSize, totalItems, itemsOnPage));
    }
}
