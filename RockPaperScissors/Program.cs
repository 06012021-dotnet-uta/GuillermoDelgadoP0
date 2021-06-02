
/*
1. START GAME - INTRO
2. PROMPT FOR CHOICES X3
3. PRESS ENTER
4. PRINT RESULT OF EACH ROUND 
5. PRINT THE WINNER
6.ASK YOU WANT TO PLAY AGAIN? (LOOP) OR QUIT.

NOTES: 2,3 & 4 INSIDE THE LOOP
*/
//TO-DO
/*Coding challenge
            1. implement a loop to play again if the player chooses to.
            2. get the players name to print out the winners
            3. implement the code to play 3 rounds.
*/

using System;

namespace RockPaperScissors{

    public enum RpsChoice
        {
            //without specifying the number equivalent of the enum type, the numbers default to start at 0.
            Rock = 1,//equivalent to 1
            Paper = 2,//equivalent to 2
            Scissors = 3//equivalent to 3
        }
        
    partial class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("\n\tWelcome to Rock-Paper-Scissors!\n");
            Console.WriteLine("Hi, please enter player name: ");
            string playerName = Console.ReadLine();

            bool successfulConversion = false;
            int playerChoiceInt;

            int counter = 0;
            int playerPoints = 0;
            int computerPoints = 0;
            string repeatGame = "y";

            while(repeatGame.Equals("y")){

                while(counter < 3){

                    do
                    {
                        Console.WriteLine("\n======MENU======");
                        Console.WriteLine("1. Rock\n2. Paper\n3.Scissors\n");

                        Console.Write("Ready to play lets start!!\nEnter you choice: ");
                        string playerChoice = Console.ReadLine();
                        Console.WriteLine("\n");

                        //create a int variable to catch the converted choice.
                        successfulConversion = Int32.TryParse(playerChoice, out playerChoiceInt);

                        //check if the user inputted a number but the numebr is out of bounds.
                        if (playerChoiceInt > 3 || playerChoiceInt < 1)
                        {
                            Console.WriteLine($"You inputted {playerChoiceInt}. That is not a valid choice.");
                        }
                        else if (!successfulConversion)
                        {
                            Console.WriteLine($"You inputted {playerChoice}. That is not a valid choice.");
                        }

                    } //while (!successfulConversion || (playerChoiceInt < 1 || playerChoiceInt > 3));
                    while (!successfulConversion || !(playerChoiceInt > 0 && playerChoiceInt < 4));//both of hte above are valid.

                    //you can omit the {} if the body of hte statement is only 1 line
                    if (successfulConversion == true) {
                        
                        Console.WriteLine($"the conversion returned {successfulConversion} and the player chose {playerChoiceInt}\n");

                    }
                    else{

                        Console.WriteLine($"the conversion returned {successfulConversion} and the player chose {playerChoiceInt}\n");
                    }

                    //get a random number generator object
                    Random rand = new Random();

                    //get a random number 1,2, or 3.
                    int computerChoice = rand.Next(1, Enum.GetNames(typeof(RpsChoice)).Length + 1);

                    //print the choices.
                    Console.WriteLine($"{playerName} choice is {playerChoiceInt} " + (RpsChoice)playerChoiceInt);
                    Console.WriteLine($"The computer choice is {computerChoice} " + (RpsChoice)computerChoice);

                    //check who won.
                    if ((playerChoiceInt == 1 && computerChoice == 2)
                        || (playerChoiceInt == 2 && computerChoice == 3)
                        || (playerChoiceInt == 3 && computerChoice == 1)){

                            Console.WriteLine("Computer Wins this round");
                            computerPoints ++;

                        } else if (playerChoiceInt == computerChoice){

                            Console.WriteLine("Tie Game!!");
                            computerPoints ++;
                            playerPoints++;

                        }else{
                    
                            Console.WriteLine("Player Wins this round!!!");
                            playerPoints++;
                        }


                    //you can get typeDef the number to the equivalent RpsChoice Enum.
                        // Console.WriteLine((RpsChoice)playerChoiceInt);
                        // Console.WriteLine((RpsChoice)computerChoice);
                        counter++;
                        Console.WriteLine($"\nYou got {3 - counter} round left!!!");
                }//end of while loop

                Console.WriteLine("\n==========Total Score========");
                Console.WriteLine($"Player: {playerName} = {playerPoints}\nComputer = {computerPoints}\n");

                if(computerPoints > playerPoints){

                    Console.WriteLine("Computer Wins!!!!");

                }else if (playerPoints > computerPoints){

                    Console.WriteLine($"{playerName} Wins!!!");
                }else{
                    Console.WriteLine("Game is a tie...\n");
                }

                Console.WriteLine("You want to play again y/n?....");
                repeatGame = Console.ReadLine();

                if(repeatGame.Equals("n")){
                    Console.WriteLine("Goobye....");
                    break;
                }
                //counter back to cero for start the game againg
                counter = 0;
            }//end of the while loop   
        }//end of main
    }//end of class
}//end of namespace
