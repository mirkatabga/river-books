namespace Books.Application;

internal interface IBooksService
{
  Task<IEnumerable<BookDto>> FetchAsync();
}
