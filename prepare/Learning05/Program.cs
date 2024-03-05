using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello Learning05 World!");

        Shape square = new Square("Blue", 2.5);
        Shape rectangle = new Rectangle("Red", 2.5, 3.1);
        Shape circle = new Circle("Purple", 3.76);

        System.Console.WriteLine("One by One:");
        System.Console.WriteLine($"{typeof(Square).Name} is {square.GetColor().ToLower()}, and its area is {square.GetArea()}");
        System.Console.WriteLine($"{typeof(Rectangle).Name} is {rectangle.GetColor().ToLower()}, and its area is {rectangle.GetArea()}");
        System.Console.WriteLine($"{typeof(Circle).Name} is {circle.GetColor().ToLower()}, and its area is {circle.GetArea()}");
        System.Console.WriteLine();

        List<Shape> shapes = new List<Shape>{
            square, rectangle, circle
        };

        System.Console.WriteLine("All Together:");
        foreach (var shape in shapes)
        {
            var type = shape.GetType();
            System.Console.WriteLine($"{type} is {shape.GetColor().ToLower()}, and its area is {shape.GetArea()}");
        }
    }
}