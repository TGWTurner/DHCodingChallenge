namespace DHCodingChallenge.Objects;

public class Discounts(double[] discounts)
{
    private readonly double[] DiscountStore = discounts;

    public double Get(int noOfBooks)
    {
        if (noOfBooks < DiscountStore.Length)
        {
            return DiscountStore[noOfBooks - 1];
        }
        else
        {
            return DiscountStore.Last();
        }
    }
}