using DHCodingChallenge.Objects;

namespace DHCodingChallenge;

public class Basket(Discounts discounts)
{
    private readonly List<Book> Books = [];
    private readonly Discounts Discounts = discounts;

    public decimal Total {
        get {
            List<BookBucket> bookBuckets = GetBestBuckets();

            foreach(BookBucket bb in bookBuckets)
            {
                Console.WriteLine(bb);
            }

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

            List<BookBucket> possibleBuckets = bookBuckets.Where(bb => !bb.Contains(book)).ToList();
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

    private BookBucket GetBestBookBucket(List<BookBucket> possibleBuckets, Book book)
    {
        BookBucket currBestBucket = possibleBuckets.First();
        currBestBucket.Add(book);
        decimal currBestPrice = possibleBuckets.Sum(pb => pb.Total);
        currBestBucket.Remove(book);

        foreach(BookBucket bookBucket in possibleBuckets.Except([currBestBucket]))
        {
            bookBucket.Add(book);
            decimal bookBucketTotal = possibleBuckets.Sum(pb => pb.Total);
            bookBucket.Remove(book);

            if (currBestPrice > bookBucketTotal)
            {
                currBestBucket = bookBucket;
                currBestPrice = bookBucketTotal;
            }
        }

        return currBestBucket;
    }
}