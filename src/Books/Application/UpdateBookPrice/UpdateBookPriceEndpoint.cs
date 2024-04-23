using FastEndpoints;

namespace Books.Application;

internal class UpdateBookPriceEndpoint(IBooksService booksService) : Endpoint<UpdateBookPriceRequest>
{
    private readonly IBooksService _booksService = booksService;

    public override void Configure()
    {
        Patch("/books/{id:Guid}/price");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateBookPriceRequest request, CancellationToken ct)
    {
        await _booksService.UpdatePriceAsync(request.Id, request.Price);
        await SendNoContentAsync(ct);
    }
}
