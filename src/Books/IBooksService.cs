namespace Books
{
    internal interface IBooksService
    {
        IEnumerable<BookDto> FetchBooks();
    }
}