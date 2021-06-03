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

namespace SimpleArraySum
{

    class Result{
            /*
        * Complete the 'simpleArraySum' function below.
        *
        * The function is expected to return an INTEGER.
        * The function accepts INTEGER_ARRAY ar as parameter.
        */

        public static int simpleArraySum(List<int> ar){

            var number = ar;
            int sum= 0;
            foreach(var x in number){

                Console.Write(" " + x);
                sum +=x;
            }

            return sum;

        }
    }

    class Program{

        static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            //int arCount = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> ar = new List<int>(){1,2,3,4,10,11};
            //List<int> ar = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arTemp => Convert.ToInt32(arTemp)).ToList();

            int result = Result.simpleArraySum(ar);

            // textWriter.WriteLine(result);

            // textWriter.Flush();
            // textWriter.Close();

            Console.WriteLine($"\n Total Sum is: {result}");
        
        }

    }
}
