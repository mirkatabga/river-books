using Books.Application;
using Microsoft.Extensions.DependencyInjection;

namespace Books;

public static class ConfigureServices
{
  public static void AddBooksModule(this IServiceCollection services)
  {
    services.AddScoped<IBooksService, BooksService>();
  }
}
