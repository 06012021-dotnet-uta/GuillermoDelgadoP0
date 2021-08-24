using System;

namespace PairSock
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine(PairFinder("AA"));
            System.Console.WriteLine(PairFinder("ABABC"));
            System.Console.WriteLine(PairFinder("CABBACCC"));
            
        }

        public static int PairFinder(string letters){


            // Display the input
            System.Console.WriteLine("Actual order: " + letters);


            char[] sorted = letters.ToCharArray(); // pass the input string to a char array
            Array.Sort(sorted); // sort the char array letters
            string newString = new string(sorted); // convert the char array back to a string

            System.Console.WriteLine(newString); // display the new organize string

            int count = 0;
            int i = 0;

            while(i < newString.Length -1){ // loop thrue the string 

                if(newString[i] == newString[i + 1]){ // check if the actual element and the next element are the same

                    count++; // count the same element
                    i+=2; // move the two element ahead

                }else{

                    i++; 
                }
            }

            return count; 
        }
    }
}
