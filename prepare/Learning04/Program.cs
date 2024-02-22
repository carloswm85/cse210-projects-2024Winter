using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello Learning04 World!");

        System.Console.WriteLine();
        var assignment = new Assignment("Samuel Bennett", "Multiplication");
        System.Console.WriteLine(assignment.GetSummary());
        
        System.Console.WriteLine();
        var math = new MathAssignment("7.3", "8-19", "Roberto Rodriguez", "Fractions");
        System.Console.WriteLine(math.GetSummary());
        System.Console.WriteLine(math.GetHomeworklist());
        
        System.Console.WriteLine();
        var writing = new WritingAssignment("The Causes of World War II", "Mary Waters", "European History");
        System.Console.WriteLine(writing.GetSummary());
        System.Console.WriteLine(writing.GetWritingInformation());
    }
}