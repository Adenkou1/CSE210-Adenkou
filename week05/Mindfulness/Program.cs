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
        Console.WriteLine("Starting " + name + "...");
        Thread.Sleep(duration * 1000);
        Console.WriteLine(name + " is done!");
    }

}