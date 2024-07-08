using DHCodingChallenge.Objects;

namespace DHCodingChallenge.Tests.Objects;

[TestClass]
public class TestDiscounts
{
    private static readonly Discounts discounts = new([1, 0.5, 0.25]);

    [TestMethod]
    //(expectedDiscount, numberOfBooks)
    [DataRow(1, 1)]
    [DataRow(2, 0.5)]
    [DataRow(3, 0.25)]
    public void TestDiscountReturnsCorrectValue(int index, double expected)
    {
        double actual = discounts.Get(index);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestDiscountReturnsLastValueWhenOutOfBounds()
    {
        double expected = 0.25;
        double actual = discounts.Get(50);

        Assert.AreEqual(expected, actual);
    }
}