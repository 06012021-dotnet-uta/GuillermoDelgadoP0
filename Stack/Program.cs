using System;

namespace Stack
{
    internal class StackClass{
        // variables
        private string[] myStack;
        private int top = -1;
        private stack_size = 5

        // constructor
        public StackClass(){
            this.myStack = new string[stack_size]];
        }

        // methods 

        /// <summary>
        /// check is the stack is full
        /// next if is full pass the values to a new array with bigger size
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        internal string Push(string name){


            top++; // incement were the top is.
            myStack[top] = name; // assign the name

            return "";
        }


/// <summary>
/// check if the array is empty if is empty alert the user
/// </summary>
/// <returns></returns>
        internal string Pop(){


            if(top == -1){

                System.Console.WriteLine("stack empty");
            }else{

                top--;
            }
            
            return myStack[top + 1];
        }

        internal string Peek(){
            

            return myStack[top];
        }

        internal string[] PrintStack(){

            return myStack;
        }

        private void Realocate(){

            throw new NotImplementedMethod{};
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            StackClass myStack = new StackClass();

            // push some names
            System.Console.WriteLine($"Adding Mark");
            myStack.Push("Mark");

            System.Console.WriteLine($"Adding Patty");
            myStack.Push("Patty");

            System.Console.WriteLine($"Adding Gd");
            myStack.Push("Gd");

            // peek
             System.Console.WriteLine($"popping {myStack.Peek()}");
            // pop
            System.Console.WriteLine($"popping {myStack.Pop()}");
            System.Console.WriteLine($"");


            // print

            // peek


        }
    }
}
