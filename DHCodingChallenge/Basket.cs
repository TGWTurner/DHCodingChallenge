using System.Security.Cryptography.X509Certificates;
using DHCodingChallenge.Objects;

namespace DHCodingChallenge;

public class Basket
{
    private readonly List<Book> Books = [];
    public decimal Total {
        get {
            List<BookBucket> bookBuckets = GetBestBuckets();

            decimal total = 0;

            foreach(BookBucket bb in bookBuckets)
            {
                total += bb.Total;
                Console.WriteLine(bb);
            }

            Console.WriteLine($"total: {total}");
            return Books.Sum(x => x.Price);
        }
    }

    public void AddBook(Book book)
    {
        Books.Add(book);
    }

    private List<BookBucket> GetBestBuckets()
    {
        /*
            Sorting Process
            1. Loop through books
            2. If no buckets
              i. Create a new bucket
              ii. Put current book in bucket
              iii. Continue;
            3. If are buckets
              i. Filter buckets to only ones without this book
              ii. Test each remaining bucket
              iii. Track cost of given bucket and store the one which has minimum cost
            4. Return
        */

        List<BookBucket> bookBuckets = [new(Books.First())];

        foreach(Book book in Books.Except([Books.First()]))
        {
            if (bookBuckets.Count == 0)
            {
                BookBucket newBucket = new(book);
                bookBuckets.Add(newBucket);
                continue;
            }

            var possibleBuckets = bookBuckets.Where(x => !x.Contains(book));
            GetBestBookBucket(possibleBuckets, book).Add(book);
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