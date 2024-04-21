using Ardalis.GuardClauses;

namespace Books.Domain;

internal class Book(Guid id, string title, string author, decimal price)
{
  public Guid Id { get; } = Guard.Against.Default(id);
  public string Title { get; } = Guard.Against.NullOrEmpty(title);
  public string Author { get; } = Guard.Against.NullOrEmpty(author);
  public decimal Price { get; private set; } = Guard.Against.Negative(price);

  public void UpdatePrice(decimal price)
  {
    Price = Guard.Against.Negative(price);
  }
}
