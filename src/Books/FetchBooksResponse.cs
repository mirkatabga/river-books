namespace Books
{
    internal record FetchBooksResponse(IEnumerable<BookDto> Books);
}
