using System;
using System.Collections.Generic;
using System.Threading;

//I will try to creat Base Class: Activity
public class Activity
{
    protected string name;
    protected string description;
    protected int duration; //in minutes

    public Activity(string name, string description, int duration)
    {
        this.name = name;
        this.description = description;
        this.duration = duration;
    }

    public void StartActivity()
    {
        Console.WriteLine($"\n{name}");
        Console.WriteLine(description);
        Console.WriteLine("Enter duration (in seconds)");
        duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
}

    public void EndActivity()
    {
        C
    }