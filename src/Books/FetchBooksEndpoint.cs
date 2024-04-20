using FastEndpoints;

namespace Books
{
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
            var books = _booksService.FetchBooks();
            await SendAsync(new FetchBooksResponse(books), cancellation: ct);
        }
    }
}
