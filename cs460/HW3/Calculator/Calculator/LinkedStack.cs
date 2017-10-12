

using Calculator.Interface;

namespace Calculator
{
    public class LinkedStack<T> : IStackADT
    {
        private Node<T> Top;

        public LinkedStack()
        {
            Top = null;
        }

        public object Push(object newItem)
        {
            if (newItem == null)
            {
                return null;
            }

            T newT = new Node<T>(newItem, Top);
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public bool IsEmpty()
        {
            throw new System.NotImplementedException();
        }

        public object Peek()
        {
            throw new System.NotImplementedException();
        }

        public object Pop()
        {
            throw new System.NotImplementedException();
        }
    }
}