using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class QueenChallenge
{

    /*
     * Complete the 'queensAttack' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER k
     *  3. INTEGER r_q
     *  4. INTEGER c_q
     *  5. 2D_INTEGER_ARRAY obstacles
     */

    public static int queensAttack(int n, int k, int r_q, int c_q, List<List<int>> obstacles)
    {
        
    int u = n - r_q;
    int d = r_q - 1;
    int r = n - c_q;
    int l = c_q-1;
    
    int ru = Math.Min(u, r);
    int rd = Math.Min(r,d);
    int lu = Math.Min(l,u);
    int ld = Math.Min(l,d);
    
    foreach(List<int> o in obstacles){
        if (o[1] == c_q){
            
            if (o[0] < r_q){
                d = Math.Min(d, r_q-1-o[0]);
            }
            else{
                u =Math.Min(u, o[0]-r_q-1);
            }
        }        
        else if(o[0] == r_q){
            
            if (o[1] < c_q){ 
                l = Math.Min(l, c_q-1-o[1]);
            }
            else{ 
                r = Math.Min(r, o[1]-c_q-1);
            }
        }
        else if(Math.Abs(o[0]-r_q) == Math.Abs(o[1]-c_q)){
            if (o[1]>c_q){
                if (o[0]>r_q){ 
                    ru = Math.Min(ru, o[1]-c_q-1);
                }
                else{
                     rd = Math.Min(rd, o[1]-c_q-1);
                }
            }
            else{
                if (o[0]>r_q){ 
                    lu = Math.Min(lu, c_q-1-o[1]);
                }
                else{ 
                    ld = Math.Min(ld, c_q-1-o[1]);
                }
            }   
        }
    }           
    return u + d + r + l + ru + rd + lu + ld;
            
    }

}

class Program
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int k = Convert.ToInt32(firstMultipleInput[1]);

        string[] secondMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int r_q = Convert.ToInt32(secondMultipleInput[0]);

        int c_q = Convert.ToInt32(secondMultipleInput[1]);

        List<List<int>> obstacles = new List<List<int>>();

        for (int i = 0; i < k; i++)
        {
            obstacles.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(obstaclesTemp => Convert.ToInt32(obstaclesTemp)).ToList());
        }

        int result = Result.queensAttack(n, k, r_q, c_q, obstacles);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
