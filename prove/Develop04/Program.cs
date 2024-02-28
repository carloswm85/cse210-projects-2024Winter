using System;

class Program
{
    // https://byui-cse.github.io/cse210-course-2023/unit04/develop.html
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello Develop04 World!");
        var activities = new List<Activity>() {
            new ActivityBreathing(10),
            new ActivityListing(10),
            new ActivityReflection(10),
        };
        var menu = new Menu(activities);

        while (menu.IsRunning())
        {
            menu.ShowMenu();
            menu.SelectActivity();

            
        }

    }
}