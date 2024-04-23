using Books.Domain.Exceptions;
using FastEndpoints;

namespace Books.Application.FetchBookById;

internal class FetchBookByIdEndpoint(IBooksService booksService) : Endpoint<FetchBookByIdRequest, BookDto>
{
    private readonly IBooksService _booksService = booksService;

    public override void Configure()
    {
        Get("/books/{id:Guid}/book");
        AllowAnonymous();
    }

    public override async Task HandleAsync(FetchBookByIdRequest request, CancellationToken ct)
    {
        var book = await _booksService.FetchByIdAsync(request.Id);
        await SendAsync(book, cancellation: ct);
    }
}
