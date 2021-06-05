using System;

namespace RockPaperScissors
{

    public class Computer
    {
         //Variables
         public int score;
         public string name;

         //Constructor Default
         public Computer(){
              this.name = "A.I";
              this.score = 0;
         }

         //Generates anwsers for the A.I
         public int randomNumberGen(){

              var rand = new Random();
              int number = rand.Next(1,4);
              return number;
         }

        
    }
}