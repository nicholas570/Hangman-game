using System;
using System.Collections.Generic;
using Games;
namespace Hangman
{
    class HangmanGame : Game
    {
        public override void Play()
        {
            string word = GetRandomWord();
            GuessWord(word);
        }
        private string GetRandomWord()
        {
            int randomIndex = new Random().Next(144);
            return Words.WordsArray[randomIndex];
        }
        private void DisplayWord(string word, List<char> letters)
        {
            for (int i = 0; i < word.Length; i++)
            {
                char letter = word[i];
                if (letters.Contains(letter))
                {
                    Console.Write($"{letter} ");
                }
                else
                {
                    Console.Write("_ ");
                }
            }
        }
        private char AskLetter()
        {
            while (true)
            {
                Console.WriteLine();
                Console.Write("Enter a single letter: ");
                string res = Console.ReadLine();
                if (res.Length == 1)
                {
                    res = res.ToUpper();
                    return res[0];
                }
            }
        }
        private void GuessWord(string word)
        {
            var letters = new List<char>();
            var excludedLetters = new List<char>();
            const int lifes = 6;
            int lifesLeft = lifes;
            while (lifesLeft != 0)
            {
                Console.WriteLine(Ascii.HUNG[lifes - lifesLeft]);
                DisplayWord(word, letters );
                Console.WriteLine();
                char letter = AskLetter();
                Console.Clear();
                if (word.Contains(letter))
                {
                    letters.Add(letter);
                    if(HasWon(word, letters)){
                        Console.WriteLine("YOU WIN");
                        DisplayWord(word, letters);
                        return;
                    };
                }
                else
                {
                    if (!excludedLetters.Contains(letter))
                    {
                        lifesLeft--;
                        excludedLetters.Add(letter);
                    }
                    Console.WriteLine($"Lifes left: {lifesLeft}");
                }
                Console.WriteLine();
                if (excludedLetters.Count > 0)
                {
                    Console.WriteLine($"The word does not contain {String.Join(", ", excludedLetters)}");
                }
            }
            Console.WriteLine(Ascii.HUNG[lifes - lifesLeft]);
            if (lifesLeft == 0)
            {
                Console.WriteLine("YOU LOOSE");
                Console.WriteLine($"The word was {word}");
            }
            PlayAgain();
        }
        private bool HasWon(string word, List<char> letters)
        {
            foreach (var letter in letters)
            {
                word = word.Replace(letter.ToString(), "");
            }
            return word.Length == 0;
        }
    }
}