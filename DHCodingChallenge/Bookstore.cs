using System.Numerics;
using DHCodingChallenge.Objects;

namespace DHCodingChallenge;

public class Bookstore(Discounts discounts, List<int> bookOptions)
{
    private readonly Discounts Discounts = discounts;
    private readonly List<int> BookOptions = bookOptions;

    public void Run()
    {
        Basket basket = new(Discounts);

        Console.WriteLine("Bookstore started:");

        foreach(int bookOption in BookOptions)
        {
            bool accepted;
            do {
                accepted = true;
                Console.WriteLine($"Enter the number of book {bookOption} to add to the basket [0+]");
                string? input = Console.ReadLine();

                if (input == null || !IsValidInput(input))
                {
                    Console.WriteLine("Error in your input, please enter a positive integer");
                    accepted = false;
                    continue;
                }

                int noOfBooks = int.Parse(input);

                for(int i = 0; i < noOfBooks; i++)
                {
                    Book book = new(bookOption);

                    basket.AddBook(book);
                }
            } while (!accepted);
        }

        Console.WriteLine($"The cheapest total of your basket is: {basket.Total:0.00}");
    }

    private static bool IsValidInput(string? input) {
        if (!int.TryParse(input, out int integer) ||
            integer < 0
        ) {
            return false;
        }

        return true;
    }
}