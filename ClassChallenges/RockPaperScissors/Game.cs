using System;

namespace RockPaperScissors
{

    enum RPS{

        Rock = 1,
        Paper = 2,
        Scissors = 3
    }

    public class Game
    {
        //Variables
        public Player player;
        public Computer computer;


        //Default Constructor
        public Game(){
            this.computer = new Computer();
            
        }


        /// <summary>
        /// Welcom method add a new player and att the same time check for validation....
        /// The creation of the player is in the if statement were create and validate att the same time
        /// using the addPlayer method..
        /// </summary>
        public void Welcome(){

            System.Console.WriteLine("\n\tWelcome to Rock-Paper-Scissors!\n");
            System.Console.WriteLine("Hi, please enter player name: ");
            string name = System.Console.ReadLine().Trim();

            System.Console.WriteLine("Enter number of round: ");
            int rounds = Convert.ToInt32(Console.ReadLine());


            if(addPlayer(name, rounds)){
                System.Console.WriteLine($"Player {player.name} is in the game...");
            }else{
                System.Console.WriteLine("Somthing went wrong in addplayer method....");
            }

        }

/// <summary>
/// Private method use to add player receving two parameters and
/// validating them..
/// </summary>
/// <param name="name"></param>
/// <param name="round"></param>
/// <returns></returns>
        private bool addPlayer(string name,int round){

            if((name.Length > 20 || name.Length < 1) && (round < 1 || round > 6) ){

                System.Console.WriteLine("Not valid name & rounds....");
                return false;

            }else{

                this.player = new Player(name, round);
                return true;
            }
        }

/// <summary>
/// Method were user input the choices and 
/// the scores added
/// </summary>
        public void rockPaperScissors(){

            for(int i = 0; i <= player.rounds-1; i++){

                System.Console.WriteLine("\n======MENU======");
                System.Console.WriteLine("1. Rock\n2. Paper\n3.Scissors\n");
                System.Console.Write("Ready to play lets start!!\nEnter you choice: ");
                int playerChoice = Convert.ToInt32(System.Console.ReadLine());

               while(!validationInput(playerChoice)){

                   System.Console.WriteLine("Please entre a valid input...");
                   playerChoice = Convert.ToInt32(System.Console.ReadLine());
               }

                int computerChoice = computer.randomNumberGen();

                Console.WriteLine($"{player.name} choice is " + (RPS)playerChoice);
                Console.WriteLine($"{computer.name} choice is " + (RPS)computerChoice);

                if ((playerChoice == 1 && computerChoice == 2)
                    || (playerChoice == 2 && computerChoice == 3)
                    || (playerChoice == 3 && computerChoice == 1)){

                    Console.WriteLine("Computer Wins this round");
                    computer.score++;

                } else if (playerChoice == computerChoice){

                    Console.WriteLine("Tie Game!!");
                    computer.score++;
                    player.score++;

                }else{
                    
                    Console.WriteLine("Player Wins this round!!!");
                    player.score++;
                }
           
              }
        }
/// <summary>
/// Private method that recive a argument type int of playerChoise and validate the user input
/// and return a bool...
/// </summary>
/// <param name="playerChoice"></param>
/// <returns></returns>
        private bool validationInput(int playerChoice){

            if(playerChoice > 3 || playerChoice < 1 ){
                Console.WriteLine($"You inputted {playerChoice}. That is not a valid choice.");
                return false;
            }else{

                System.Console.WriteLine("Good Luck!!!");
                return true;
            }
        }

/// <summary>
/// Method to display the user and computer total points
/// </summary>
        public void gameScore(){
            Console.WriteLine("\n==========Total Score========");
            Console.WriteLine($"Player: {player.name} = {player.score}\nComputer = {computer.score}\n");

                if(computer.score > player.score){

                    Console.WriteLine("Computer Wins!!!!");

                }else if (player.score > computer.score){

                    Console.WriteLine($"{player.name} Wins!!!");
                }else{

                    Console.WriteLine("Game is a tie...\n");
                }
        }

/// <summary>
/// Ask for play again retrun bool
/// </summary>
/// <returns></returns>
        public bool playAgain(){

            Console.WriteLine("You want to play again y/n?....");
                string repeatGame = Console.ReadLine();
                      
                if(repeatGame.ToLower().Equals("n")){
                    Console.WriteLine("Goobye....");
                    return false;  

                } else if(repeatGame.ToLower().Equals("y")){
                    System.Console.WriteLine("Lets go againg!!!!");

                    return true;
                }else{

                    System.Console.WriteLine("Not valid input......");

                    return playAgain();
                }
        }

        

    }
}