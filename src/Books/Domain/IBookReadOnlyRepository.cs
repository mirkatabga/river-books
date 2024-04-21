namespace Books.Domain;

internal interface IBookReadOnlyRepository
{
  Task<Book> FetchByIdAsync();
  Task<IEnumerable<Book>> FetchAsync();
}
