using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace RiverBooks.Books;

internal interface IBookService
{
    IEnumerable<BookDto> ListBooks();
}

public record BookDto(Guid Id, string Title, string Author, int Year);

internal class BookService : IBookService
{
    public IEnumerable<BookDto> ListBooks()
    {
        return new[]
        {
            new BookDto(Guid.NewGuid(), "The Hobbit", "J.R.R. Tolkien", 1937),
            new BookDto(Guid.NewGuid(), "The Fellowship of the Ring", "J.R.R. Tolkien", 1954),
            new BookDto(Guid.NewGuid(), "The Two Towers", "J.R.R. Tolkien", 1954),
            new BookDto(Guid.NewGuid(), "The Return of the King", "J.R.R. Tolkien", 1955),
            new BookDto(Guid.NewGuid(), "The Silmarillion", "J.R.R. Tolkien", 1977),
            new BookDto(Guid.NewGuid(), "The Children of Húrin", "J.R.R. Tolkien", 2007),
            new BookDto(Guid.NewGuid(), "Unfinished Tales", "J.R.R. Tolkien", 1980),
            new BookDto(Guid.NewGuid(), "The History of Middle-earth", "J.R.R. Tolkien", 1983),
            new BookDto(Guid.NewGuid(), "The Fall of Gondolin", "J.R.R. Tolkien", 2018),
            new BookDto(Guid.NewGuid(), "Beren and Lúthien", "J.R.R. Tolkien", 2017),
            new BookDto(Guid.NewGuid(), "The Adventures of Tom Bombadil", "J.R.R. Tolkien", 1962),
            new BookDto(Guid.NewGuid(), "The Road Goes Ever On", "J.R.R. Tolkien", 1967),
            new BookDto(Guid.NewGuid(), "The Father Christmas Letters", "J.R.R. Tolkien", 1976),
            new BookDto(Guid.NewGuid(), "The Letters of J.R.R. Tolkien", "J.R.R. Tolkien", 1981),
            new BookDto(Guid.NewGuid(), "The Monsters and the Critics", "J.R.R. Tolkien", 1983),
            new BookDto(Guid.NewGuid(), "Beowulf: A Translation and Commentary", "J.R.R. Tolkien", 2014),
            new BookDto(Guid.NewGuid(), "The Story of Kullervo", "J.R.R. Tolkien", 2015),
            new BookDto(Guid.NewGuid(), "The Lay of Aotrou and Itroun", "J.R.R. Tolkien", 2016),
            new BookDto(Guid.NewGuid(), "The Fall of Arthur", "J.R.R. Tolkien", 2013)
        };
    }
}

public static class BookEndpoints
{
    public static void MapBooksEndpoint(this WebApplication app)
    {
        app.MapGet("/books", (IBookService bookService) => { return bookService.ListBooks(); });
    }
}

public static class BookServiceExtensions
{
    public static IServiceCollection AddBookServices(this IServiceCollection services)
    {
        services.AddScoped<IBookService, BookService>();
        return services;
    }
}
