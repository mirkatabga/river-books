namespace Books.Application;

internal record BookDto(Guid Id, string Title, string Author, decimal Price);

internal record CreateBookDto(string Title, string Author, decimal Price);
