
namespace Books;

  internal class BooksService : IBooksService
  {
      public IEnumerable<BookDto> FetchBooks()
      {
          return [
              new BookDto(
                  Id: Guid.NewGuid(),
                  Title: "The fellowship of the ring",
                  Author: "Tolkin"),

              new BookDto(
                  Id: Guid.NewGuid(),
                  Title: "Red Rising",
                  Author: "Pierce Brown"),

              new BookDto(
                  Id: Guid.NewGuid(),
                  Title: "Dune",
                  Author: "Frank Herbert"),
              ];
      }
  }
