using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello Learning02 World!");

        var job1 = new Job();
        var job2 = new Job();

        job1._company = "Apple";
        job1._jobTitle = "Software Engineer";
        job1._yearStart = 1998;
        job1._yearEnd = 2003;

        job2._company = "Microsoft";
        job2._jobTitle = "Web Developer";
        job2._yearStart = 2004;
        job2._yearEnd = 2019;

        var resume = new Resume();
        resume._namePerson = "Carlos Mercado";
        resume._jobs.Add(job1);
        resume._jobs.Add(job2);

        resume.Display();
    }
}