using System;

namespace ArrayEater
{
    class Program
    {

        public static int maxPoss(){
            //this is default output. You can changeit.
            int result = -404;
           const int N = 5;
            //write your logic here
            int[] A = new int[N]{2,6,4,9,3};

           var rand = new Random();

           int K = 2; //rand.Next(0, N);
           int P = 1; //rand.Next(0, (N - K));
           Console.WriteLine("K = " + K);
           Console.WriteLine("P = " + P);

           Array.Sort(A);
           Array.Reverse(A);

            int i = 0;
           int totalSave = 0;

           while(i < P ){

            totalSave += A[i];
            A[i] = 0;
               i++;
           }

           while(i <= K){
               i++;
           }

           while(i<N){

               totalSave+= A[i];
               i++;
           }
           
           Console.WriteLine("Totla= " + totalSave);
          
           
            return result;
        }

        static void Main(string[] args)
        {


            //int N = 0;
            //int K = 0;
            //int P = 0;

            /*
            System.Console.WriteLine("Enter somthing.....");
            string[] tokens = Console.ReadLine().Split();
            N = Convert.ToInt32(tokens[0]);
            K = Convert.ToInt32(tokens[1]);
            P = Convert.ToInt32(tokens[2]);*/

            //int[] A = new int[];

            /*
            string[] tokens1 = Console.ReadLine().Split();

            for(int i = 0; i<N; i++){
                A[i] = Convert.ToInt32(tokens1[i]);
            }*/

            //assing values to the NKP and pass A
            Console.WriteLine(maxPoss());
            //Console.WriteLine(maxPoss(N,K,P,A));
        }
    }
}
