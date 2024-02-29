using System;

class Program
{
    // https://byui-cse.github.io/cse210-course-2023/unit04/develop.html
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello Develop04 World!");
        var activities = new List<Activity>() {
            new ActivityBreathing(),
            new ActivityListing(),
            new ActivityReflection(),
        };

        Activity activity;
        var menu = new Menu(activities);
        Console.Clear();

        while (menu.IsRunning())
        {
            menu.ShowMenu();
            activity = menu.SelectActivity();

            if (activity != null) {
                activity.Describe();
                activity.SetDuration();
                
                while(activity.IsRunning()) {
                    activity.Start();
                }
            }
        }
    }
}