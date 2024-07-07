using DHCodingChallenge.Objects;

namespace DHCodingChallenge;

public class Basket
{
    private readonly List<Book> Books = [];
    public decimal Total {
        get {
            //TODO: Add more complex calculation
            return Books.Sum(x => x.Price);
        }
    }

    public void AddBook(Book book)
    {
        Books.Add(book);
    }
}