
using System.Data;
using System.Collections.Generic;
// Examples
// bucketize("she sells sea shells by the sea", 10)pass
// ➞ ["she sells", "sea shells", "by the sea"]

// bucketize("the mouse jumped over the cheese", 7)
// ➞ ["the", "mouse", "jumped", "over", "the", "cheese"]

// bucketize("fairy dust coated the air", 20)
// ➞ ["fairy dust coated", "the air"]

// bucketize("a b c d e", 2)pass
// ➞ ["a", "b", "c", "d", "e"]


using System;
using System.Text.RegularExpressions;

namespace WordBucket
{
    public class Program
    {


        public static void display(List<String> list)
        {
            foreach (string item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(" ");

        }

        public static List<String> bucketsize(string word, int bucksize){

            int i = 0;
            int counter = 0;
            int spaces = 0;
            string temp = "";
            string temp2 = "";
            word += " ";
            
            List<String> list = new List<String>();

           
            while(i < word.Length) {

                // if the first index encounter is a white space return the counter back one
                if (counter + 1 == 1 && word[i] == ' ')
                {
                    counter -= 1;

                }
                else
                {
                    // store eache letter in temp every iteration until reach the count
                    temp += word[i];

                }

                


                //find the index of last white space encounter and save it
                if(word[i] == ' ')
                {
                    spaces = i; // save the last spaces that iterates
                    temp2 = temp; // save the pass the word everytime cross a white space 

                }


                // check if the bucksize is equals to the counter to add to the list
                if(bucksize == counter + 1)
                {

                    // check if the index stop on white space or in a letter that have a
                    // white space next to it
                    if (word[i] == ' '|| word[i + 1] == ' ')
                    {

                        list.Add(temp.Trim());
                        counter = -1;
                        temp = "";
                        
                    }
                    // if the index is in a letter and the next index is a letter to, that means you are in the middle
                    // of a word back to the last space save and add to the list the last interpolated word
                    else if(Regex.IsMatch(word[i].ToString(), @"^[a-zA-Z]+$") && Regex.IsMatch(word[i + 1].ToString(), @"^[a-zA-Z]+$"))
                    {
                        i = spaces;

                        list.Add(temp2.Trim());
                        counter = -1;
                        temp = "";
                        temp2 = "";
                        
                    }
    
                }
                
                counter++;
                i++;

                // for get the last word of the array
                if (i == word.Length)
                {
                    list.Add(temp.Trim());

                    temp = "";

                }


            }

            return list;
            
        }

        static void Main(string[] args)
        {

            List<String> x = new List<String>();

            string shells = "she sells sea shells by the sea"; // 10
            string letters = "a b c d e"; // 2
            string mouse = "the mouse jumped over the cheese"; // 7
            string fairy = "fairy dust coated the air"; // 20

            display(bucketsize(mouse, 7));

            display(bucketsize(shells, 10));

            display(bucketsize(fairy, 20));

            display(bucketsize(letters, 2));

        }
    }
}
