using System;

namespace Calculator.Interface
{
    public interface IStackADT<T>
    {
        T Push(T newItem);
        T Pop();
        T Peek();
        bool IsEmpty();
        void Clear();
    }
}