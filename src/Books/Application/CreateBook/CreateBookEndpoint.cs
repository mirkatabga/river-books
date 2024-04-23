using FastEndpoints;

namespace Books.Application.FetchBookById;

internal class CreateBookEndpoint(IBooksService booksService) : Endpoint<CreateBookRequest, BookDto>
{
    private readonly IBooksService _booksService = booksService;

    public override void Configure()
    {
        Post("/books");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateBookRequest request, CancellationToken ct)
    {
        var book = new CreateBookDto(request.Title, request.Author, request.Price);
        var createdBook = await _booksService.CreateAsync(book);
        await SendCreatedAtAsync<FetchBookByIdEndpoint>(new { createdBook.Id }, createdBook, cancellation: ct);
    }
}
