using Books.Domain;

namespace Books.Application;

internal class BooksService(IBookRepository bookRepository) : IBooksService
{
  private readonly IBookRepository _bookRepository = bookRepository;

  public async Task<IEnumerable<BookDto>> FetchAsync()
  {
    var books = await _bookRepository.FetchAsync();

    return books.Select(book =>
      new BookDto(book.Id, book.Title, book.Author));
  }
}
