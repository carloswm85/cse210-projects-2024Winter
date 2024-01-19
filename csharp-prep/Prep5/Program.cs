using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        var name = PromptUserName();
        var num = PromptUserNumber();
        var sq = SquareNumber(num);
        DisplayResult(name, sq);
    }

    // DisplayWelcome - Displays the message, "Welcome to the Program!"
    static void DisplayWelcome() {
        Console.WriteLine("Welcome to the Program!");
    }

    // PromptUserName - Asks for and returns the user's name (as a string)
    static string PromptUserName() {
        System.Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    // PromptUserNumber - Asks for and returns the user's favorite number (as an integer)
    static int PromptUserNumber() {
        System.Console.Write("Please enter your favorite number: ");
        return Convert.ToInt32(Console.ReadLine());
    }

    // SquareNumber - Accepts an integer as a parameter and returns that number squared(as an integer)
    static double SquareNumber(int number) {
        return number * number;
    }

    // DisplayResult - Accepts the user's name and the squared number and displays them.
    static void DisplayResult(string name, double squared) {
        Console.WriteLine($"{name}, the square of your number is {squared}");
    }

}