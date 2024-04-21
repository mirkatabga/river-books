using FastEndpoints;

namespace Books.Application.FetchBooks;

internal class FetchBooksEndpoint(IBooksService booksService) : EndpointWithoutRequest<FetchBooksResponse>
{
    private readonly IBooksService _booksService = booksService;

    public override void Configure()
    {
        Get("/books");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var books = await _booksService.FetchAsync();
        await SendAsync(new FetchBooksResponse(books), cancellation: ct);
    }
}
