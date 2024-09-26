namespace Catalog.API.Models;

public record PaginationRequest(int PageSize = 8, int PageIndex = 0);
