namespace Books.Application;

internal record FetchBooksResponse(IEnumerable<BookDto> Books);
