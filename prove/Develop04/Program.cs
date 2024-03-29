using System;

/// <summary>
/// Additional requirements:
/// - If needed, I can add as many activities as I want. No limit for that. That logic is in the Menu class.
/// - Activity contains two important methods shareable among Activity child classes: ShowTimer and DisplayText
/// - ShowTimer has 2 different modes, one for showing seconds and the other one for showing a spinner.
/// </summary>
class Program
{
    // https://byui-cse.github.io/cse210-course-2023/unit04/develop.html
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello Develop04 World!");
        var activities = new List<Activity>() {
            new ActivityBreathing(),
            new ActivityReflection(),
            new ActivityListing(),
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