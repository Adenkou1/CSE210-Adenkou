using System;
using System.Collections.Generic;
using System.IO;

// I'm about to create a new class: Base Goal
abstract class Goal
{
    protected string name;
    protected string description;
    protected int points;
    protected bool isCompleted;

    public Goal(string name, string description, int points)
    {
        this.name = name;
        this.description = description;
        this.points = points;
        isCompleted = false;
    }

    public abstract void RecordEvent(ref int totalScore);
   public virtual string GetDetailsString() => $"{name}" - {description} ({points} points);
}