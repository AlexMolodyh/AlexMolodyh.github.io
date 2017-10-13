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
        T Push(T newItem);
        T Pop();
        T Peek();
        bool IsEmpty();
        void Clear();
    }
}