using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int number = -1;
        List<int> numbers = new List<int>();

        while (number != 0) {
            Console.Write("Enter number: ");
            number = Convert.ToInt32(Console.ReadLine());
            if(number != 0) numbers.Add(number);
        }

        int sum = 0;
        foreach (int item in numbers)
        {
            sum += item;
        }
        Console.WriteLine($"The sum is: {sum}");
        
        double average = numbers.Average();
        float averageTwo = ((float)sum) / numbers.Count;

        Console.WriteLine($"The average is: {average} and {averageTwo}");
        
        int largest = numbers.Max();
        Console.WriteLine($"The largest number is: {largest}");

    }
}