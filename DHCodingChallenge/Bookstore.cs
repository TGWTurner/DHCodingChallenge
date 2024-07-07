using DHCodingChallenge.Objects;

namespace DHCodingChallenge;

class Bookstore
{
    public static void Run()
    {
        Basket basket = new();

        //TODO: convert to configuration file
        List<int> bookOptions = [1, 2, 3, 4, 5];

        Console.WriteLine("Bookstore started:");

        foreach(int bookOption in bookOptions)
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