using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello Learning03 World!");
        var f1 = new Fraction();
        Console.WriteLine("Fraction 01:");
        // Console.WriteLine(f1.GetTop());
        // Console.WriteLine(f1.GetBot());
        System.Console.WriteLine(f1.GetFractional());
        System.Console.WriteLine(f1.GetDecimal());
        f1.SetTop(44);
        f1.SetBot(5);
        // Console.WriteLine(f1.GetTop());
        // Console.WriteLine(f1.GetBot());
        System.Console.WriteLine(f1.GetFractional());
        System.Console.WriteLine(f1.GetDecimal());
        Console.WriteLine("Fraction 02:");
        var f2 = new Fraction(6);
        // Console.WriteLine(f2.GetTop()); 
        // Console.WriteLine(f2.GetBot());
        System.Console.WriteLine(f2.GetFractional());
        System.Console.WriteLine(f2.GetDecimal());
        f2.SetTop(7);
        f2.SetBot(3);
        // Console.WriteLine(f2.GetTop());
        // Console.WriteLine(f2.GetBot());
        System.Console.WriteLine(f2.GetFractional());
        System.Console.WriteLine(f2.GetDecimal());
        var f3 = new Fraction(6,7);
        Console.WriteLine("Fraction 03:");
        // Console.WriteLine(f3.GetTop());
        // Console.WriteLine(f3.GetBot());
        System.Console.WriteLine(f3.GetFractional());
        System.Console.WriteLine(f3.GetDecimal());
        f3.SetTop(8);
        f3.SetBot(2);
        // Console.WriteLine(f3.GetTop());
        // Console.WriteLine(f3.GetBot());
        System.Console.WriteLine(f3.GetFractional());
        System.Console.WriteLine(f3.GetDecimal());
    }
}

class Fraction
{
    private int _top;
    private int _bot;

    public Fraction()
    {
        _top = 1;
        _bot = 1;
    }
    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bot = 1;
    }
    public Fraction(int top, int bot)
    {
        _top = top;
        _bot = bot;
    }

    public void SetTop(int top)
    {
        _top = top;
    }
    public int GetTop()
    {
        return _top;
    }
    public void SetBot(int bot)
    {
        _bot = bot;
    }
    public int GetBot()
    {
        return _bot;
    }

    public string GetFractional()
    {
        return _top.ToString() + "/" + _bot.ToString();
    }
    public double GetDecimal()
    {
        return (double)_top / (double)_bot;
    }
}
