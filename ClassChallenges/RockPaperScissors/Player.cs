namespace RockPaperScissors
{
    public partial class Player
    {
        //Varibles
        public string name;
        public int score;
        public int rounds;

       //Argumented Constructor
        public Player(string name, int rounds){

            this.name = name;
            this.rounds = rounds;
            this.score = 0;
        }
    }
}