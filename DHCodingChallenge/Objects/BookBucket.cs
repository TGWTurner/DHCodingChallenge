namespace DHCodingChallenge.Objects;

public class BookBucket
{
    private readonly List<Book> Books;

    public decimal Total{
        get {
            return Books.Sum(x => x.Price); //* discount
        }
    }

    public int Count{
        get {
            return Books.Count;
        }
    }

    public BookBucket(Book book)
    {
        Books = [book];
    }

    public BookBucket()
    {
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
        return Books.Contains(book);
    }

    public decimal TotalWithBook(Book book)
    {
        Books.Add(book);
        decimal total = Total;
        Books.Remove(book);

        return total;
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