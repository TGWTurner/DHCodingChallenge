
using System.Configuration;
using DHCodingChallenge.Objects;

namespace DHCodingChallenge;

class Program
{

    static void Main(string[] args)
    {
        Console.WriteLine("DunnHumby Coding Challenge");
        Console.WriteLine("Bookstore:");

        (Discounts discounts, List<int> bookOptions) = GetConfig();

        Bookstore bookstore = new(discounts, bookOptions);

        do {
            bookstore.Run();
            Console.WriteLine("Press q to quit or any other key to go again.");
        } while (!"q".Equals(Console.ReadLine()));
    }

    //TODO: Get from configuration file
    static (Discounts, List<int>) GetConfig()
    {
        return (
            new Discounts([1, 0.95, 0.9, 0.80, 0.75]),
            new List<int> {1, 2, 3, 4, 5}
        );
    }
}
