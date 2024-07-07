namespace DHCodingChallenge;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("DunnHumby Coding Challenge");
        Console.WriteLine("Bookstore:");

        do {
            Bookstore.Run();
            Console.WriteLine("Press q to quit, press any key to go again.");
        } while (!"q".Equals(Console.ReadLine()));

    }
}

/*
BRIEF:
Book costs 8€
Discounts:
 1 Book  - 0%
 2 Books - 5%
 3 Books - 10%
 4 Books - 20%
 5 Books - 25%
Minimize total cost to purchase

eg. [1, 1, 2, 2, 3, 3, 4, 5]
 could be [1, 2, 3, 4, 5]: 25% + [1, 2, 3]: 10% = (5*8*(1-0.25)) + (3*8*(1-0.10)) = 30.0 + 21.6 = 51.6€
       or [1, 2, 3, 4]: 20% + [1, 2, 3, 5]: 20% = (4*8*(1-0.20)) + (4*8*(1-0.20)) = 25.6 + 25.6 = 51.2€

NOTES:
 - If is the HP Book store we have 2 options for calculating the price of the books:
   - Needs to provide minimum price for a given book combo
   - Calculate the best place for that book to go when adding the book (we dont have to deal with removing books here so thats not an issue)
    - No need to remove books, so dont have to ever re-calculate (but removes that option for the future)
    - Calculation at the end is a simple 8 * number of books in the grouping * discount for that number of books [enum?]
   - Calculate the best price at the end once all the books have been added
    - Simple to store the books in a list
    - Calculating is more complex:
     - Store the count of the occurences and 
*/
