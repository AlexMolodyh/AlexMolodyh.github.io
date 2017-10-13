

using Calculator.Interface;

namespace Calculator
{
    public class LinkedStack<T> : IStackADT<T>
    {
        private Node top;

        public LinkedStack() => top = null;

        public T Push(T newItem)
        {
            if (newItem == null)
            {
                return default(T);
            }

            Node NewNode = new Node(newItem, top);
            top = NewNode;
            return newItem;

        }

        public T Pop()
        {
            if(IsEmpty())
            {
                return default(T);
            }
            object TopItem = top.Data;
            top = top.Next;
            return (T) TopItem;
        }

        public void Clear() => top = null;

        public bool IsEmpty() =>  (top == null);

        public T Peek()
        {
            if (IsEmpty())
                return default(T);
            return (T) top.Data;
        }
    }
}