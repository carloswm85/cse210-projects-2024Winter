using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello Prep2 World!");

        Console.Write("Enter your grade percentage: ");
        var input = Console.ReadLine();
        var grade = int.Parse(input);
        string letter;

        Console.Write("Your letter grade has been: ");

        if (grade >= 90)
        {
            Console.WriteLine("A");
            letter = "A";
        }
        else if (grade >= 80)
        {
            Console.WriteLine("B");
            letter = "B";
        }
        else if (grade >= 70)
        {
            Console.WriteLine("C");
            letter = "C";
        }
        else if (grade >= 60)
        {
            Console.WriteLine("D");
            letter = "D";
        }
        else
        {
            // grade < 60
            Console.WriteLine("F");
            letter = "F";
        }

        if (grade >= 70)
        {
            Console.WriteLine("Congratulations, you've passed.");
        }
        else
        {
            Console.WriteLine("You have not passed. Try again.");
        }

        Console.WriteLine($"\nLetter grade was: {letter}");
    }
}