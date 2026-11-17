using System;
using System.Runtime.Intrinsics.X86;
namespace ClinicTriageSystem
{
    class StackHistory<T> 
    {
        private Node<T> top;
        private int count = 0;

        public int Count
        {
            get { return count; }
        }
        public bool IsEmpty
        {
            get { 
            
                if( top == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public void Push( T item )
        {
            Node<T> newNode = new Node<T> (item);
                if (top == null)
            {
                 newNode.Next = top;
            }
            else
            {
                newNode.Next = top;
            }
            count++;
        }
        public T Pop()
        {
            if (top == null )
            {
                throw new InvalidOperationException(" Stack is Empty");
            }
            T item = top.Value;
            top = top.Next;

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
                return top.Value ;
            }
        }

    }

}
