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

namespace LibariFineChallenge
{

    class Result
{

    /*
     * Complete the 'libraryFine' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER d1
     *  2. INTEGER m1
     *  3. INTEGER y1
     *  4. INTEGER d2
     *  5. INTEGER m2
     *  6. INTEGER y2
     */

    public static int libraryFine(int d1, int m1, int y1, int d2, int m2, int y2){

//Code from other source
        //  if(y1 <= y2){
            
        //     if(d1 > d2 && m1 == m2 && y1 < y2){
        //         return 0;
        //     }
            
        //     if(d1 > d2 && m1 == m2){
        //         return (d1-d2)*15;
        //     }
            
        //     if(m1 > m2 && y1 == y2){
        //         return (m1 -m2) *500;
        //     }
        //     return 0;
        // }
        // return 10000;

//My code
        int fine = 0;

        if((m1 - m2 == 0) && (y1 - y2 == 0)){

            System.Console.WriteLine("Enter 1 if.....");
            if((d1 >=  1 && d1 <= 31) && (d1 >= 1 && d1 <= 31)){
                System.Console.WriteLine("Return day....");
                 return Math.Abs(fine = 15*(d1 - d2));
            }

        }else if (y1 - y2 == 0){
            System.Console.WriteLine("Enter 2 else if....");
            if((m1 >=  1 && m1 <= 12) && (m2 >= 1 && m2 <= 12)){
                return Math.Abs(fine = 500*(m1-m2));
            }

        }else{
            
            System.Console.WriteLine("Enter 3 else....");
            if((y1 >=  1 && y1 <= 3000) && (y2 >= 1 && y2 <= 3000)){
                return 10000;
            }
            
        }
        return 0;
    }
    

}
    class Program
    {
        static void Main(string[] args)
        {

            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            //string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int d1 = Convert.ToInt32("9");

            int m1 = Convert.ToInt32(6);

            int y1 = Convert.ToInt32(2015);

           // string[] secondMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int d2 = Convert.ToInt32("6");

            int m2 = Convert.ToInt32(9);

            int y2 = Convert.ToInt32(2015);

            int result = Result.libraryFine(d1, m1, y1, d2, m2, y2);

            System.Console.WriteLine(result);

            // textWriter.WriteLine(result);

            // textWriter.Flush();
            // textWriter.Close();
        }
    }
}
