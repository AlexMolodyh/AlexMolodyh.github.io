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