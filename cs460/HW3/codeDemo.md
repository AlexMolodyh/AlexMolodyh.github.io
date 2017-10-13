# C# Calculator Translated Code from Java

### I will try to describe the differences that I have implemented in to the c# version of the app. 

### The node class
#### I have converted the prviously pubic fields into private fields and am utilizing the propertie feature in C# to access those private data types.
[Node class](https://goo.gl/q9N2Gz)

```c#
namespace Calculator
{
    //compile with: /doc:Node.xml
    
    /// <summary>
    /// A node to hold a piece of data and a referrence to the next node.
    /// It is made to act like a slot in a stack.
    /// </summary>
    public class Node
    {
        private object data;
        private Node next;

        public Node()
        {
            data = null;
            next = null;
        }

        public Node(object data, Node next)
        {
            Data = data;
            Next = next;
        }

        /// <summary>
        /// The data a node contains inside.
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// The node next in line(like in a stack).
        /// </summary>
        public Node Next
        {
            get; set;
        }
    }
}
```

### The IStackADT interface
#### I have implemented the IStackADT interface using C# Generics.
[IStackADT class](https://goo.gl/noeHQ4)

```c#
using System;

namespace Calculator.Interface
{
    // compile with: /doc:IStackADT.xml

    /// <summary>
    /// IStackADT is meant to resemble a stack.
    /// </summary>
    /// <typeparam name="T">A Generic item place-holder</typeparam>
    public interface IStackADT<T>
    {
        /// <summary>
        /// Pushes an element on to the top of thr stack.
        /// </summary>
        /// <param name="newItem">The new item to push on to the stack</param>
        /// <returns>if successful, it returns the same item.</returns>
        T Push(T newItem);

        /// <summary>
        /// Removes the top item off of the stack.
        /// </summary>
        /// <returns>Returns the item from the top of the stack.</returns>
        T Pop();

        /// <summary>
        /// Checks to see what item lays at the top of the stack.
        /// </summary>
        /// <returns>returns the top item on the stack but doesn't remove it.</returns>
        T Peek();

        /// <summary>
        /// Checks to see if the stack is empty.
        /// </summary>
        /// <returns>If the stack is empty it returns true. 
        /// Otherwise it returns false</returns>
        bool IsEmpty();

        /// <summary>
        /// Clears the stack of all items.
        /// </summary>
        void Clear();
    }
}
```

### The LinkedStack
#### The LinkedStack ADT implements the IStackADT interface and uses C# Generics to implement the overriden methods.
[LinkedStack class](https://goo.gl/gQqeay)

```c#


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
```