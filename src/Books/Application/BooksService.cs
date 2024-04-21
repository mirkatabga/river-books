using Books.Domain;

namespace Books.Application;

internal class BooksService(IBookRepository bookRepository) : IBooksService
{
  private readonly IBookRepository _bookRepository = bookRepository;

  public async Task<BookDto> FetchByIdAsync(Guid id)
  {
    var book = await _bookRepository.FetchByIdAsync(id);
    return new BookDto(book.Id, book.Title, book.Author, book.Price);
  }

  public async Task<IEnumerable<BookDto>> FetchAsync()
  {
    var books = await _bookRepository.FetchAsync();

    return books.Select(book =>
      new BookDto(book.Id, book.Title, book.Author, book.Price));
  }

  public async Task CreateAsync(BookDto book)
  {
    await _bookRepository.AddAsync(
      new Book(Guid.NewGuid(), book.Title, book.Author, book.Price));

    await _bookRepository.SaveChangesAsync();
  }

  public async Task UpdatePriceAsync(Guid id, decimal price)
  {
    var book = await _bookRepository.FetchByIdAsync(id);
    book.UpdatePrice(price);

    await _bookRepository.UpdateAsync(book);
    await _bookRepository.SaveChangesAsync();
  }

  public async Task DeleteAsync(Guid id)
  {
    var book = await _bookRepository.FetchByIdAsync(id);
    await _bookRepository.DeleteAsync(book);
  }
}
