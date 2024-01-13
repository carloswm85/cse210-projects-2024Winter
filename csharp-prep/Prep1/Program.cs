using System;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello Prep1 World!");

        Console.Write("What is your first name? ");
        string name =  Console.ReadLine(); //Scott

        Console.Write("What is your last name? ");
        string surname = Console.ReadLine(); //Burton

        Console.Write($"Your name is {surname}, {name} {surname}.");
    }
}