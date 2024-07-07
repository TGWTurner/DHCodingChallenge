using DHCodingChallenge.Objects;

namespace DHCodingChallenge;

public class Basket(Discounts discounts)
{
    private readonly List<Book> Books = [];
    private readonly Discounts Discounts = discounts;

    public decimal Total {
        get {
            List<BookBucket> bookBuckets = GetBestBuckets();
            return bookBuckets.Sum(bb => bb.Total);
        }
    }

    public void AddBook(Book book)
    {
        Books.Add(book);
    }

    private List<BookBucket> GetBestBuckets()
    {
        List<BookBucket> bookBuckets = [];

        foreach(Book book in Books)
        {
            if (bookBuckets.Count == 0)
            {
                BookBucket newBucket = new(Discounts, book);
                bookBuckets.Add(newBucket);
                continue;
            }

            IEnumerable<BookBucket> possibleBuckets = bookBuckets.Where(bb => !bb.Contains(book));
            if (possibleBuckets.Any())
            {
                GetBestBookBucket(possibleBuckets, book).Add(book);
            }
            else
            {
                BookBucket newBucket = new(Discounts, book);
                bookBuckets.Add(newBucket);
            }
        }

        return bookBuckets;
    }

    private BookBucket GetBestBookBucket(IEnumerable<BookBucket> possibleBuckets, Book book)
    {
        BookBucket currBestBucket = possibleBuckets.First();
        decimal currBestPrice = currBestBucket.TotalWithBook(book);

        foreach(BookBucket bookBucket in possibleBuckets.Except([currBestBucket]))
        {
            decimal bookBucketTotal = bookBucket.TotalWithBook(book);

            if (currBestPrice > bookBucketTotal)
            {
                currBestBucket = bookBucket;
                currBestPrice = bookBucketTotal;
            }
        }

        return currBestBucket;
    }
}