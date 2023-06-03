using MyFirstEFCoreApp.Data;

namespace MyFirstEFCoreApp.Services;

public class BookServices
{
    private IWriter _writer;

    public BookServices(IWriter writer)
    {
        _writer = writer;
    }

    public void ListAll()
    {
        using (var context = new AppDbContext())
        {
            foreach (var book in context.Books
                            .AsNoTracking()
                            .Include(b => b.Author))
            {
                var webUrl = book.Author.WebUrl == null
                    ? "- no web URL given -"
                    : book.Author.WebUrl;
                _writer.Write(
                    $"{book.Title} by {book.Author.Name}");
                _writer.Write(" " +
                    "Published on " +
                    $"{book.PublishedOn:dd-MMM-yyyy}" +
                    $". {webUrl}");
            }
        }
    }
}