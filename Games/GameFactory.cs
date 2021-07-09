using System;
using Hangman;

namespace Games
{
    public enum GameType
    {
        Hangman    
    }
    public static class GameFactory
    {
        public static Game Create(GameType gameType)
        {
            switch (gameType)
            {
                case GameType.Hangman:
                    return new HangmanGame();
                default:
                    throw new Exception($"{gameType} is not available");
            }
        }
    }
}
