namespace DHCodingChallenge.Objects;

public class Discounts(double[] discounts)
{
    private readonly double[] DiscountStore = discounts;

    public double Get(int index)
    {
        if (index < DiscountStore.Length)
        {
            return DiscountStore[index];
        }
        else
        {
            //If have more books than there are discounts, return the last discount value
            return DiscountStore.Last();
        }
    }
}