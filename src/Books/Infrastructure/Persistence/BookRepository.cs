using Books.Domain;
using Microsoft.EntityFrameworkCore;

namespace Books.Infrastructure.Persistence;

internal class BookRepository(BooksDbContext dbContext) : IBookRepository
{
    private readonly BooksDbContext _dbContext = dbContext;

    public async Task AddAsync(Book book)
    {
        await _dbContext.Books.AddAsync(book);
    }

    public Task DeleteAsync(Book book)
    {
        _dbContext.Books.Remove(book);
        return Task.CompletedTask;
    }

    public async Task<IEnumerable<Book>> FetchAsync()
    {
        return await _dbContext.Books.ToListAsync();
    }

    public async Task<Book?> FetchByIdAsync(Guid id)
    {
        return await _dbContext.Books
            .SingleOrDefaultAsync(book => book.Id == id);
    }

    public Task UpdateAsync(Book book)
    {
        _dbContext.Books.Update(book);
        return Task.CompletedTask;
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}
