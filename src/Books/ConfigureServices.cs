﻿using Books.Application;
using Books.Domain;
using Books.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Books;

public static class ConfigureServices
{
    public static void AddBooksModule(
        this IServiceCollection services,
        IConfigurationManager configurationManager)
    {
        var connectrionString = configurationManager.GetConnectionString("BooksConnectionString");
        services.AddExceptionHandler<BooksExceptionHandler>();
        services.AddDbContext<BooksDbContext>(options => options.UseSqlServer(connectrionString));
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IBooksService, BooksService>();
    }
}
