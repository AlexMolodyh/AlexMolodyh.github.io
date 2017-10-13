

using Calculator.Interface;

namespace Calculator
{
    public class LinkedStack<T> : IStackADT<T>
    {
        private Node Top;

        public LinkedStack()
        {
            Top = null;
        }

        public T Push(T newItem)
        {
            if (newItem == null)
            {
                return default(T);
            }

            Node NewNode = new Node(newItem, Top);
            Top = NewNode;
            return newItem;

        }

        public T Pop()
        {
            if(IsEmpty())
            {
                return default(T);
            }
            object TopItem = Top.Data;
            Top = Top.Next;
            return (T) TopItem;
        }

        public void Clear()
        {
            Top = null;
        }

        public bool IsEmpty()
        {
            return Top == null;
        }

        public T Peek()
        {
            if (IsEmpty())
                return default(T);
            return (T) Top.Data;
        }
    }
}