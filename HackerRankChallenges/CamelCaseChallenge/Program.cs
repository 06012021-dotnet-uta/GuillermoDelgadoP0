using System;
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

namespace CamelCaseChallenge
{

    class Result
{

    /*
     * Complete the 'camelcase' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts STRING s as parameter.
     */


    public static int camelcase(string s)
    {
        // this firts count even is this chart is lowercase
        int upperCamelFound = 1;

        for(int i = 0; i < s.Length; i++){

            if(Char.IsUpper(s[i])){
                upperCamelFound++;
            }
        }
        return upperCamelFound;

    }

}

    class Program
    {
        static void Main(string[] args)
        {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        //string s = Console.ReadLine();

        string s = "upperCamelCase";

        int result = Result.camelcase(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
        }
    }
}
