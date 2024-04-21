namespace Books.Domain;
internal interface IBookRepository : IBookReadOnlyRepository
{
  Task AddAsync(Book book);
  Task UpdateAsync(Book book);
  Task DeleteAsync(Book book);
  Task SaveChangesAsync();
}
