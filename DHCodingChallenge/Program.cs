namespace DHCodingChallenge;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("DunnHumby Coding Challenge");
        Console.WriteLine("Bookstore:");

        do {
            Bookstore.Run();
            Console.WriteLine("Press q to quit or any other key to go again.");
        } while (!"q".Equals(Console.ReadLine()));

    }
}
