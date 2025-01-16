using System;

class Program
{
    static void Main(string[] args)
    {
        bool playAgain = true;
        while (playAgain); 
        {
             Console.Write("Do you want to play again? (yes/no): ");
            string playAgainResponse = Console.ReadLine().ToLower();
            playAgain = (playAgainResponse == "yes");
        }
    }  Console.WriteLine("Thank You for Playing!");
}