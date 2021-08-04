using System;

namespace BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] arr ={10,23,1,46,44,89,2,13,8};


            for (int i = 0; i < arr.Length - 1; i++){
                for (int j = 0; j < arr.Length - i - 1; j++)
                    if (arr[j] > arr[j + 1])
                    {
                        // swap temp and arr[i]
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
            }

            foreach(int x in arr){
                System.Console.WriteLine(x);
            }

        
        }
    }

}
