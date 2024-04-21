namespace Books.Application.FetchBooks;

internal record FetchBooksResponse(IEnumerable<BookDto> Books);
