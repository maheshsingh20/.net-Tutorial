using System;
namespace Assignment2Part1Question10
{
  class GuessingGame
  {
    public static void PlayGuessingGame()
    {
      Random random = new Random();
      int secretNumber = random.Next(1, 101);
      int guess;
      int attempts = 0;
      
      Console.WriteLine("Welcome to the Guessing Game!");
      Console.WriteLine("I'm thinking of a number between 1 and 100.");
      
      do
      {
        Console.Write("Enter your guess: ");
        guess = Convert.ToInt32(Console.ReadLine());
        attempts++;
        
        if (guess < secretNumber)
        {
          Console.WriteLine("Too low! Try again.");
        }
        else if (guess > secretNumber)
        {
          Console.WriteLine("Too high! Try again.");
        }
        else
        {
          Console.WriteLine($"Congratulations! You guessed it in {attempts} attempts!");
        }
        
      } while (guess != secretNumber);
    }
  }
}