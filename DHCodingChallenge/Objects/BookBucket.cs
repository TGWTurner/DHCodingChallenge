namespace DHCodingChallenge.Objects;

public class BookBucket
{
    private readonly List<Book> Books;
    private readonly Discounts Discounts;

    public decimal Total{
        get {
            return Books.Sum(x => x.Price) * (decimal) Discounts.Get(Books.Count);
        }
    }

    public int Count{
        get {
            return Books.Count;
        }
    }

    public BookBucket(Discounts discounts, Book book)
    {
        Discounts = discounts;
        Books = [book];
    }

    public BookBucket(Discounts discounts)
    {
        Discounts = discounts;
        Books = [];
    }

    public void Add(Book book)
    {
        Books.Add(book);
    }

    public void Remove(Book book)
    {
        Books.Remove(book);
    }

    public bool Contains(Book book)
    {
        return Books.Exists(b => b.Identifier == book.Identifier);
    }

    public override string ToString()
    {
        string str = "[";

        for(int i = 0; i < Books.Count; i++)
        {
            str += Books[i].Identifier;
            if (i < Books.Count - 1) {
                str += ",";
            }
        }

        str += "]";

        return str;
    }
}