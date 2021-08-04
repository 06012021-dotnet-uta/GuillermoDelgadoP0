using System;

namespace Stair
{
    class Program
    {
        static void Main(string[] args)
        {
             int n = 6;
    
         for(int i = n-1; i >= 0; i--){  
             System.Console.WriteLine("");
            for(int j = 0; j < n ; j++){

                if(i == j || j > i){

                    Console.Write("#");                    
                }else{
                    System.Console.Write(" ");
                }
            }

            
         }
        
        }
    }    
}
