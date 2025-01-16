using System;

class Program
{
    static void Main(string[] args)
    {
        bool playAgain = true;

        while (playAgain)
        {
            PlayGuessMyNumber();

            Console.Write("Do you want to play again? (yes/no): ");
            string playAgainResponse = Console.ReadLine().ToLower();
            playAgain = (playAgainResponse == "yes");
        }

        Console.WriteLine("Thanks for playing!");
    }

    static void PlayGuessMyNumber()
    {
        Random random = new Random();
        int magicNumber = random.Next(1, 101);
        int guess;
        int numberOfGuesses = 0;

        Console.WriteLine("I'm thinking of a number between 1 and 100.");

        do
        {
            Console.Write("What is your guess? ");
            while (!int.TryParse(Console.ReadLine(), out guess))
            {
                Console.Write("Invalid input. Please enter a number: ");
            }

            numberOfGuesses++;

            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
                Console.WriteLine($"It took you {numberOfGuesses} guesses.");
            }
        } while (guess != magicNumber);
    }
}

