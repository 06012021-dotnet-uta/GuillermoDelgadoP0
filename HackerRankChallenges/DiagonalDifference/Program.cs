using System;

namespace DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
             int [,]array = {{1,2,3},{4,5,6},
                            {9,8,9}};

            // System.Console.WriteLine(array[0,0]);//l
            // System.Console.WriteLine(array[0,1]);
            // System.Console.WriteLine(array[0,2]);//r
            // System.Console.WriteLine(array[1,0]);
            // System.Console.WriteLine(array[1,1]);//c
            // System.Console.WriteLine(array[1,2]);
            // System.Console.WriteLine(array[2,0]);//r
            // System.Console.WriteLine(array[2,1]);
            // System.Console.WriteLine(array[2,2]);//l

            int leftDiagonalSum = 0;
            int rightDiagonalSum = 0;

            for(int i = 0; i < array.GetLength(0); i++){

                for(int j = 0; j < array.GetLength(1); j++){

                    if(i == j){
                        leftDiagonalSum+= array[i,j];
                    }

                    if((i+j) == array.GetLength(1) - 1){
                        rightDiagonalSum += array[i,j];
                    }

                }
            }


            System.Console.WriteLine($"\nLeft Diagonal Sum: {leftDiagonalSum}");
            System.Console.WriteLine($"Right Diagonal Sum: {rightDiagonalSum}\n");
            

           int total =  Math.Abs(leftDiagonalSum - rightDiagonalSum);
           System.Console.WriteLine($"Sums of the diagonals: {total}");

        }
    }
}
