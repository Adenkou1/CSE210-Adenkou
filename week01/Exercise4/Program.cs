using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<double> numbers = new List<double>();

        
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        while (true)
        {
            Console.Write("Enter number: ");
            double number = Convert.ToDouble(Console.ReadLine());
            if (number == 0)
                break;
            numbers.Add(number);
        }

        
        
        double sum = numbers.Sum();
        Console.WriteLine($"The sum is: {sum}");

        
        double average = numbers.Average();
        Console.WriteLine($"The average is: {average}");

        
        double max = numbers.Max();
        Console.WriteLine($"The largest number is: {max}");

        
        
        double smallestPositive = numbers.Where(n => n > 0).DefaultIfEmpty(0).Min();
        Console.WriteLine($"The smallest positive number is: {smallestPositive}");

        
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (double num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}

