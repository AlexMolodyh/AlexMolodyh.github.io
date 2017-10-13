

using Calculator.Interface;

namespace Calculator
{
    // compile with: /doc:LinkedStack.xml

    /// <summary>
    /// A data structure that acts like a stack. It uses C# Generics so it can 
    /// be used with many types.
    /// </summary>
    /// <typeparam name="T">A Generic type</typeparam>
    public class LinkedStack<T> : IStackADT<T>
    {
        private Node top;

        public LinkedStack() => top = null;

        /// <summary>
        /// Pushes an element on to the top of thr stack.
        /// </summary>
        /// <param name="newItem">The new item to push on to the stack</param>
        /// <returns>if successful, it returns the same item.</returns>
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

        /// <summary>
        /// Removes the top item off of the stack.
        /// </summary>
        /// <returns>Returns the item from the top of the stack.</returns>
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

        /// <summary>
        /// Clears the stack of all items.
        /// </summary>
        public void Clear() => top = null;

        /// <summary>
        /// Checks to see if the stack is empty.
        /// </summary>
        /// <returns>If the stack is empty it returns true. 
        /// Otherwise it returns false</returns>
        public bool IsEmpty() =>  (top == null);

        /// <summary>
        /// Checks to see what item lays at the top of the stack.
        /// </summary>
        /// <returns>returns the top item on the stack but doesn't remove it.</returns>
        public T Peek()
        {
            if (IsEmpty())
                return default(T);
            return (T) top.Data;
        }
    }
}