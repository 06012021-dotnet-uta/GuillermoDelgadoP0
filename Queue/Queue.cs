using System;

namespace Queue
{
    

    class Queue
    {
        static int SIZE = 10;

        int[] array = new int[SIZE];
        int rear;   //same as tail
        int front;  //same as head

        public Queue(){
            
            rear = front = -1;
        }

        public void Enqueue(int number){

            if(front == -1) {
                front++;
            }

            if( rear == SIZE-1)
            {
                System.Console.WriteLine("The Queue is full");
            }
            else
            {
                array[++rear] = number;
            }
        }

        // function dequeue - to remove data from queue
        public int Dequeue()
        {
             int tail = this.rear;
            
             for (int i = 0; i < tail-1; i++)    //shifting all other elements
            {
                array[i] = array[i+1];
                tail--;
            }
            return array[0];

            //return array[++front];  // following approach [B], explained above
        }

        public int Peek(){
            return array[front];
        }

        //function to display the queue elements
        public void Display()
        {
            int i;
            for(i = front; i <= rear; i++)
            {

                System.Console.WriteLine(array[i]);
                
            }
        }


        static void Main(string[] args)
        {
            Queue q = new Queue();
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            q.Enqueue(4);
            q.Enqueue(5);
            q.Dequeue();
            q.Enqueue(6);
            q.Dequeue();
            q.Dequeue();
            q.Enqueue(7);
    
            q.Display();
        }
    }
}
