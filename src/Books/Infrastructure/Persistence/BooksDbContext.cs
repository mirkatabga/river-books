using System.Reflection;
using Books.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Books.Infrastructure.Persistence;

internal class BooksDbContext(DbContextOptions options) : DbContext(options)
{
    private const string BOOKS_SCHEMA = "books";

    public DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(BOOKS_SCHEMA);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .Properties<decimal>()
            .HavePrecision(18, 6);

        base.ConfigureConventions(configurationBuilder);
    }
}

internal class BooksConfiguration : IEntityTypeConfiguration<Book>
{
    private const int TITLE_MAX_LENGHT = 100;
    private const int FULL_NAME_MAX_LENGHT = 100;
    private readonly Guid[] _bookIds =
    [
        Guid.Parse("F8FD6990-6E43-420B-8808-060F0632B684"),
        Guid.Parse("EE8C61BF-BABF-46D1-9A63-C640CDF9B52D"),
        Guid.Parse("7083A0F1-57D0-465B-9B3A-FD942BAD5D55")
    ];

    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(book => book.Id);

        builder.Property(book => book.Title)
            .HasMaxLength(TITLE_MAX_LENGHT)
            .IsRequired();

        builder.Property(book => book.Author)
            .HasMaxLength(FULL_NAME_MAX_LENGHT)
            .IsRequired();

        builder.Property(book => book.Price).IsRequired();
        builder.HasData(GetSampleBookData());
    }

    private IEnumerable<Book> GetSampleBookData() => [
            new Book(_bookIds[0], "The Fellowship of the Ring", "Tolkien", 10.99m),
            new Book(_bookIds[1], "Red Rising", "Pierce Brown", 15.99m),
            new Book(_bookIds[2], "Dune", "Frank Herbert", 20.99m)
        ];
}
