namespace Books.Application;

internal interface IBooksService
{
  Task<BookDto> FetchByIdAsync(Guid id);
  Task<IEnumerable<BookDto>> FetchAsync();
  Task<BookDto> CreateAsync(CreateBookDto book);
  Task UpdatePriceAsync(Guid id, decimal price);
  Task DeleteAsync(Guid id);
}
