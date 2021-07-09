using System;

namespace Games
{
    class Program
    {
        static void Main(string[] args)
        {
            var hangman = GameFactory.Create(GameType.Hangman);
            hangman.Play();
        }
    }
}
