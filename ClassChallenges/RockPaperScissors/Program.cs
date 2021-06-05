using System;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {

            bool playAgain = false;

            do{

                Game game = new Game();
                game.Welcome();
                game.rockPaperScissors();
                game.gameScore();
                playAgain = game.playAgain();

            }while(playAgain);
                

        }
    }
}
