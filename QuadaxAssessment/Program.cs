using System;

class Mastermind
{
    static void Main()
    {
        Random random = new Random();
        string answer = "";
        for (int i = 0; i < 4; i++)
        {
            answer += random.Next(1, 7).ToString();
        }

        int attempts = 10;

        while (attempts > 0)
        {
            Console.Write("Enter your guess (4 digits, each between 1 and 6): ");
            string guess = Console.ReadLine();

            if (guess.Length != 4 || !IsValidGuess(guess))
            {
                Console.WriteLine("Invalid guess. Please enter exactly 4 digits, each between 1 and 6.");
                continue;
            }

            if (guess == answer)
            {
                Console.WriteLine("Congratulations! You've guessed the correct number!");
                return;
            }

            string hint = GetHint(guess, answer);
            Console.WriteLine("Hint: " + hint);

            attempts--;
            Console.WriteLine($"Attempts remaining: {attempts}");
        }

        Console.WriteLine("Sorry, you've used all attempts. The correct number was: " + answer);
    }

    static bool IsValidGuess(string guess)
    {
        foreach (char c in guess)
        {
            if (c < '1' || c > '6')
            {
                return false;
            }
        }
        return true;
    }

    static string GetHint(string guess, string answer)
    {
        int plusCount = 0;
        int minusCount = 0;
        bool[] guessed = new bool[4];
        bool[] checkedAnswer = new bool[4];

        // Check for correct positions first
        for (int i = 0; i < 4; i++)
        {
            if (guess[i] == answer[i])
            {
                plusCount++;
                guessed[i] = true;
                checkedAnswer[i] = true;
            }
        }

        // Check for correct digits in wrong positions
        for (int i = 0; i < 4; i++)
        {
            if (!guessed[i])
            {
                for (int j = 0; j < 4; j++)
                {
                    if (!checkedAnswer[j] && guess[i] == answer[j])
                    {
                        minusCount++;
                        checkedAnswer[j] = true;
                        break;
                    }
                }
            }
        }

        return new string('+', plusCount) + new string('-', minusCount);
    }
}
