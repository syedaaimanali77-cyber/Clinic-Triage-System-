using System;
using System.Collections.Specialized;
using System.Globalization;
using System.Xml.Linq;
namespace ClinicTriageSystem
{
    class LinkedQueue<T> where T : IQueueItem 
    {
        public Node<T>? head;
        public Node<T>? tail;

        private int count = 0;

        public int Count
            {
            get { return count; }
        }
        public bool IsEmpty
        {
            get
            {
                if (head == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
            

        public void Enqueue ( T item)
        {
            Node<T> newNode = new Node<T>(item); 

            if (head == null)
            {
                
                head = newNode;
                 tail = newNode;

            }
            else
            {
                tail?.Next = newNode;
                tail = newNode;
            }
            count++;
      
        }
        public T Dequeue()
        {
            if (head is null)
            {
                throw new InvalidOperationException("No Patients the queue is empty");
            }

            T item = head.Value;
            head = head.Next;

            if (IsEmpty)
            {
                tail = null;
            }
            count--;
            return item;
        }

        public T Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("No Patient found");
            }

            else
            {
                return head.Value;
            }

        }

        public bool Remove(string id)
        {
            if (IsEmpty)
            {
                return false;
            }
          if ( head.Value.Id == id ) 
            {
                head = head.Next;
                if (IsEmpty)
                {
                    tail = null;
                }
                count--;
                return true;
            }
            Node<T> current = head; 
            while (current.Next != null)
            {
                if(current.Next.Value.Id == id) //next vallue id 
                {
                    current.Next = current.Next.Next;  //stip the value that we are going to remove.
                    //check whethee next value is null or not if null then the current value is the last node.
                    if (current.Next is null)
                    {
                        tail = current;
                    }
                    count--;
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public void Print()
        {
            if (IsEmpty)
            {
                Console.WriteLine("Empty");
            }
            else
            {
                Node<T>? current = head;

                int number = 1;
                while( current != null )
                {
                    Console.WriteLine($"{number} ({current.Value.Name} , {current.Value.Id})");  //Print the name of current Patient.
                    current = current.Next;
                    number++;
                }
            }
        }

    }
}