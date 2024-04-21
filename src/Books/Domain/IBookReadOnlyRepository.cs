namespace Books.Domain;

internal interface IBookReadOnlyRepository
{
  Task<Book?> FetchByIdAsync(Guid id);
  Task<IEnumerable<Book>> FetchAsync();
}
