using DHCodingChallenge.Objects;

namespace DHCodingChallenge;

class Bookstore(Discounts discounts, List<int> bookOptions)
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
                }

                if (int.TryParse(input, out int bookIdentifier))
                {
                    Book book = new(bookIdentifier);

                    basket.AddBook(book);
                }
            } while (!accepted);
        }

        Console.WriteLine($"The cheapest total of your basket is: {basket.Total}");
    }

    private static bool IsValidInput(string input) {
        if (!int.TryParse(input, out int integer))
        {
            return false;
        }

        if (integer < 0) {
            return false;
        }

        return true;
    }
}