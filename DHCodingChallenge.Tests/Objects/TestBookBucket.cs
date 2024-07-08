using DHCodingChallenge.Objects;

namespace DHCodingChallenge.Tests.Objects;

[TestClass]
public class TestBookBucket
{
    private Discounts Discounts = new([1]);
    private BookBucket BookBucket;

    [TestInitialize]
    public void TestInit()
    {
        BookBucket = new(Discounts);
    }

    [TestMethod]
    public void TestCanAddAndRemoveBook()
    {
        Book book = new(1);
        BookBucket.Add(book);

        Assert.IsTrue(BookBucket.Contains(book));
        BookBucket.Remove(book);

        Assert.IsFalse(BookBucket.Contains(book));
    }

    [TestMethod]
    public void TestCalculatesTotal()
    {
        Book book1 = new(1);
        Book book2 = new(2);
        
        BookBucket.Add(book1);
        BookBucket.Add(book2);

        decimal expected = 16.00M;
        decimal actual = BookBucket.Total;

        Assert.AreEqual(expected, actual);
    }
}
