using Microsoft.AspNetCore.Builder;

namespace RiverBooks.Books;

public static class BookEndpoints
{
    public static void MapBooksEndpoint(this WebApplication app)
    {
        app.MapGet("/books", (IBookService bookService) => { return bookService.ListBooks(); });
    }
}