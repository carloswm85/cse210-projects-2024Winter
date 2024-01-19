using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random(Guid.NewGuid().GetHashCode());
        
        Console.WriteLine("What is the magic number? ");
        Console.WriteLine("Generating random magic number...");
        int magic = randomGenerator.Next(2, 11); // Convert.ToInt32(Console.ReadLine()); // 6
        int guess = -1;

        while (magic != guess)
        {
            Console.Write("What is your guess ? ");
            guess = Convert.ToInt32(Console.ReadLine()); // 6

            if (guess == magic) Console.WriteLine("You guessed it!");
            if (guess < magic) Console.WriteLine("Higher");
            if (guess > magic) Console.WriteLine("Lower");
        }
    }
}