using System;
using System.Collections.Generic;
using System.IO;

// I'm creating Base Class: Goal
abstract class Goal
{
    protected string name;
    protected string description;
    protected int points;
    protected bool isComplete;

    public Goal(string name, string description, int points)
    {
        this.name = name;
        this.description = description;
        this.points = points;
        this.isComplete = false;
    }

    public abstract void RecordEvent(ref int totalScore);
    public virtual string GetDetailsString() => $"{name} - {description} ({points} points)";
    public virtual string SaveFormat() => $"{GetType().Name}:{name},{description},{points},{isComplete}";
}

// I'm creating Simple Goal Class
class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points) : base(name, description, points) {}
    
    public override void RecordEvent(ref int totalScore)
    {
        if (!isComplete)
        {
            totalScore += points;
            isComplete = true;
            Console.WriteLine($"Completed {name}! You earned {points} points.");
        }
        else
        {
            Console.WriteLine($"{name} is already completed.");
        }
    }
}

// Im creating Eternal Goal Class
class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points) {}
    
    public override void RecordEvent(ref int totalScore)
    {
        totalScore += points;
        Console.WriteLine($"Recorded {name}. You earned {points} points.");
    }
}

// I will create Checklist Goal Class
class ChecklistGoal : Goal
{
    private int timesRequired;
    private int timesCompleted;
    private int bonus;
    
    public ChecklistGoal(string name, string description, int points, int timesRequired, int bonus) : base(name, description, points)
    {
        this.timesRequired = timesRequired;
        this.timesCompleted = 0;
        this.bonus = bonus;
    }

    public override void RecordEvent(ref int totalScore)
    {
        timesCompleted++;
        totalScore += points;

        if (timesCompleted >= timesRequired)
        {
            totalScore += bonus;
            isComplete = true;
            Console.WriteLine($"{name} completed! You earned {points + bonus} points.");
        }
        else
        {
            Console.WriteLine($"Progress: {timesCompleted}/{timesRequired} for {name}. {points} points earned.");
        }
    }
    
    public override string GetDetailsString() => base.GetDetailsString() + $" (Completed {timesCompleted}/{timesRequired})";
}

// It is important to have Goal Manager Class
class GoalManager
{
    private List<Goal> goals = new List<Goal>();
    private int totalScore = 0;
    
    public void AddGoal(Goal goal) => goals.Add(goal);

    public void DisplayGoals()
    {
        Console.WriteLine("Your Goals:");
        foreach (var goal in goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
        Console.WriteLine($"Total Score: {totalScore}");
    }
    
    public void RecordEvent(int goalIndex)
    {
        if (goalIndex >= 0 && goalIndex < goals.Count)
        {
            goals[goalIndex].RecordEvent(ref totalScore);
        }
    }
    
    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(totalScore);
            foreach (var goal in goals)
            {
                writer.WriteLine(goal.SaveFormat());
            }
        }
        Console.WriteLine("Goals saved!");
    }
    
    public void LoadGoals(string filename)
    {
        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            totalScore = int.Parse(lines[0]);
            goals.Clear();

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(':');
                string type = parts[0];
                string[] details = parts[1].Split(',');

                if (type == "SimpleGoal")
                    goals.Add(new SimpleGoal(details[0], details[1], int.Parse(details[2])));
                else if (type == "EternalGoal")
                    goals.Add(new EternalGoal(details[0], details[1], int.Parse(details[2])));
                else if (type == "ChecklistGoal")
                    goals.Add(new ChecklistGoal(details[0], details[1], int.Parse(details[2]), int.Parse(details[3]), int.Parse(details[4])));
            }
            Console.WriteLine("Goals loaded!");
        }
    }
}

//So after having all neccesary Classes I will have the  Main Program
class Program
{
    static void Main()
    {
        GoalManager manager = new GoalManager();

        while (true)
        {
            Console.WriteLine("\n1. Add Simple Goal");
            Console.WriteLine("2. Add Eternal Goal");
            Console.WriteLine("3. Add Checklist Goal");
            Console.WriteLine("4. Record Event");
            Console.WriteLine("5. Show Goals");
            Console.WriteLine("6. Save Goals");
            Console.WriteLine("7. Load Goals");
            Console.WriteLine("8. Exit");
            Console.Write("Choose an option: ");
            
            int choice = int.Parse(Console.ReadLine());
            if (choice == 8) break;

            switch (choice)
            {
                case 1:
                    Console.Write("Name: ");
                    string sName = Console.ReadLine();
                    Console.Write("Description: ");
                    string sDesc = Console.ReadLine();
                    Console.Write("Points: ");
                    int sPoints = int.Parse(Console.ReadLine());
                    manager.AddGoal(new SimpleGoal(sName, sDesc, sPoints));
                    break;
                case 2:
                    Console.Write("Name: ");
                    string eName = Console.ReadLine();
                    Console.Write("Description: ");
                    string eDesc = Console.ReadLine();
                    Console.Write("Points per event: ");
                    int ePoints = int.Parse(Console.ReadLine());
                    manager.AddGoal(new EternalGoal(eName, eDesc, ePoints));
                    break;
                case 3:
                    Console.Write("Name: ");
                    string cName = Console.ReadLine();
                    Console.Write("Description: ");
                    string cDesc = Console.ReadLine();
                    Console.Write("Points: ");
                    int cPoints = int.Parse(Console.ReadLine());
                    Console.Write("Times Required: ");
                    int cRequired = int.Parse(Console.ReadLine());
                    Console.Write("Bonus: ");
                    int cBonus = int.Parse(Console.ReadLine());
                    manager.AddGoal(new ChecklistGoal(cName, cDesc, cPoints, cRequired, cBonus));
                    break;
                case 4:
                    manager.DisplayGoals();
                    Console.Write("Enter goal number: ");
                    manager.RecordEvent(int.Parse(Console.ReadLine()) - 1);
                    break;
                case 5:
                    manager.DisplayGoals();
                    break;
                case 6:
                    manager.SaveGoals("goals.txt");
                    break;
                case 7:
                    manager.LoadGoals("goals.txt");
                    break;
            }
        }
    }
}
