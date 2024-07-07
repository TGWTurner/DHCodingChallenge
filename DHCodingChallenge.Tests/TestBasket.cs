using DHCodingChallenge.Objects;

namespace DHCodingChallenge.Tests;

[TestClass]
public class TestBasket
{
    [TestMethod]
    //(Expected Total Cost, Books In The Basket)
    [DataRow(0 , new int[] {})]
    [DataRow(8, new int[] {1})]
    [DataRow(8, new int[] {2})]
    [DataRow(8, new int[] {3})]
    [DataRow(8, new int[] {4})]
    [DataRow(8, new int[] {5})]
    [DataRow(8*2*0.95, new int[] {1,2})]
    [DataRow(8*3*0.90, new int[] {1,2,3})]
    [DataRow(8*4*0.80, new int[] {1,2,3,4})]
    [DataRow(8*5*0.75, new int[] {1,2,3,4,5})]
    [DataRow(4*8*0.80+4*8*0.80, new int[] {1,1,2,2,3,3,4,5})]
    public void TestBasketTotalMatchesExpected(double expected, int[] bookIdentifiers)
    {
        Basket basket = new();

        PopulateBasket(basket, bookIdentifiers);

        Assert.AreEqual((decimal) expected, basket.Total);
    }

    private static void PopulateBasket(Basket basket, int[] bookIdentifiers)
    {
        foreach(int bookIdentifier in bookIdentifiers)
        {
            basket.AddBook(new(bookIdentifier));
        }
    }
}