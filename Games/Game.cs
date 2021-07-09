using System;

namespace Games
{
    public abstract class Game
    {
        public abstract void Play();
        public void PlayAgain()
        {
            bool play = true;
            while (play)
            {
                Console.Write("Want to play again? y/n ");
                string res = Console.ReadLine();
                if(res == "y" || res == "Y")
                {
                    Console.Clear();
                    Play();
                }
                play = false;
            }
        }
    }
}