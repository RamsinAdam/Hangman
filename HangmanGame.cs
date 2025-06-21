using System;
using System.Collections.Generic;

public class HangmanGame
{
    private string secretWord;
    private char[] hiddenWord;
    private HashSet<char> guessedLetters;
    private int maxStrikes = 6;
    private int strikes;

    private string[] wordBank = { "computer", "hangman", "programming", "developer", "keyboard", "console", "internet" };

    public void StartGame()
    {
        Console.Clear();
        secretWord = ChooseWord().ToLower();
        hiddenWord = new string('_', secretWord.Length).ToCharArray();
        guessedLetters = new HashSet<char>();
        strikes = 0;

        Console.WriteLine("Welcome to Hangman!");
        Console.WriteLine($"The word has {secretWord.Length} letters.");

        while (strikes < maxStrikes && new string(hiddenWord) != secretWord)
        {
            DisplayHangman();
            Console.WriteLine($"\nWord: {string.Join(" ", hiddenWord)}");
            Console.WriteLine($"Guessed letters: {string.Join(", ", guessedLetters)}");
            Console.Write("Enter a letter: ");
            string input = Console.ReadLine().ToLower();

            if (string.IsNullOrWhiteSpace(input) || input.Length != 1 || !char.IsLetter(input[0]))
            {
                Console.WriteLine("Invalid input. Please enter a single letter.");
                continue;
            }

            char guess = input[0];

            if (guessedLetters.Contains(guess))
            {
                Console.WriteLine("You already guessed that letter.");
                continue;
            }

            guessedLetters.Add(guess);

            if (secretWord.Contains(guess))
            {
                for (int i = 0; i < secretWord.Length; i++)
                {
                    if (secretWord[i] == guess)
                    {
                        hiddenWord[i] = guess;
                    }
                }
                Console.WriteLine("Correct!");
            }
            else
            {
                strikes++;
                Console.WriteLine("Incorrect.");
            }
        }

        Console.WriteLine();
        DisplayHangman();
        if (new string(hiddenWord) == secretWord)
        {
            Console.WriteLine($"You won! The word was: {secretWord}");
        }
        else
        {
            Console.WriteLine($"You lost. The word was: {secretWord}");
        }
    }

    private string ChooseWord()
    {
        Random rand = new Random();
        return wordBank[rand.Next(wordBank.Length)];
    }

    private void DisplayHangman()
    {
        string[] hangmanStates = new string[]
        {
            """
              +---+
              |   |
                  |
                  |
                  |
                  |
            =========
            """,
            """
              +---+
              |   |
              O   |
                  |
                  |
                  |
            =========
            """,
            """
              +---+
              |   |
              O   |
              |   |
                  |
                  |
            =========
            """,
            """
              +---+
              |   |
              O   |
             /|   |
                  |
                  |
            =========
            """,
            """
              +---+
              |   |
              O   |
             /|\\  |
                  |
                  |
            =========
            """,
            """
              +---+
              |   |
              O   |
             /|\\  |
             /    |
                  |
            =========
            """,
            """
              +---+
              |   |
              O   |
             /|\\  |
             / \\  |
                  |
            =========
            """
        };

        Console.WriteLine(hangmanStates[strikes]);
    }
}
