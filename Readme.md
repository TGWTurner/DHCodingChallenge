# DHCodingChallenge

### Brief

Once upon a time there was a series of 5 books about a very English hero called Harry. (At
least when this Kata was invented, there were only 5. Since then they have multiplied).
Children all over the world thought he was fantastic, and, of course, so did the publisher. So
in a gesture of immense generosity to mankind, (and to increase sales) they set up the
following pricing model to take advantage of Harry's magical powers.

One copy of any of the five books costs 8 EUR. If, however, you buy two different books
from the series, you get a 5% discount on those two books. If you buy 3 different books, you
get a 10% discount. With 4 different books, you get a 20% discount. If you go the whole hog,
and buy all 5, you get a huge 25% discount.

Note that if you buy, say, four books, of which 3 are different titles, you get a 10% discount
on the 3 that form part of a set, but the fourth book still costs 8 EUR.
Potter mania is sweeping the country and parents of teenagers everywhere are queueing up
with shopping baskets overflowing with Potter books. Your mission is to write a piece of
code to calculate the price of any conceivable shopping basket, giving as big a discount as
possible.

### My implementation

1. Loop through book options to create basket
2. Compute optimal "buckets" for each book in the basket, minimising total cost
3. Loop through buckets to calculate total cost and display

### Decisions

* Decimal type for storing currency values
* Optimal basket calculation after the basket has been fully filled
  * Leaves solution more open for the potential of removing books
  * Calculates the optimal by testing possible buckets (ie. those that dont already have this book) and calculates the total of the possible buckets
* Discounts object to allow for possibility of more books than provided discounts

### Possible Changes/Improvements

* Configuration File
  * Store the discounts and number of books for easy updating later
* Add removing from basket
* Extract Console.WriteLine/Console.Readline calls to object for flexability and testing within Bookstore.cs
