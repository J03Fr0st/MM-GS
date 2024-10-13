using FastEndpoints;

namespace RiverBooks.Books;

internal class ListBooksEndpoint : EndpointWithoutRequest<ListBooksResponse>
{
    private readonly IBookService _bookService;
    public ListBooksEndpoint(IBookService bookService)
    {
        _bookService = bookService;
    }

    public override void Configure()
    {
       Get("/books");
       AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken cancellationToken = default)
    {
        var books = _bookService.ListBooks();
        
       await SendAsync(new ListBooksResponse { Books = books }, cancellation: cancellationToken);
    }
}