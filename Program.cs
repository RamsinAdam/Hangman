using System;

class Program
{
    static void Main(string[] args)
    {
        bool playAgain = true;

        while (playAgain)
        {
            HangmanGame hangmanGame = new HangmanGame();
            hangmanGame.StartGame();

            Console.Write("Play again? (yes/no): ");
            string playAgainInput = Console.ReadLine().ToLower();

            while (playAgainInput != "yes" && playAgainInput != "no")
            {
                Console.WriteLine("Invalid input. Please enter 'yes' or 'no'.");
                Console.Write("Play again? (yes/no): ");
                playAgainInput = Console.ReadLine().ToLower();
            }

            playAgain = playAgainInput == "yes";
        }

        Console.WriteLine("Thanks for playing!");
    }
}
