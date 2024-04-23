using FastEndpoints;

namespace Books.Application;

internal class DeleteBookEndpoint(IBooksService booksService) : Endpoint<DeleteBookRequest>
{
    private readonly IBooksService _booksService = booksService;

    public override void Configure()
    {
        Delete("books/{id:Guid}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeleteBookRequest request, CancellationToken ct)
    {
        await _booksService.DeleteAsync(request.Id);
        await SendNoContentAsync(ct);
    }
}
