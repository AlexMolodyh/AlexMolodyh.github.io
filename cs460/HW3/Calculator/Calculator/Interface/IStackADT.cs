using System;

namespace Calculator.Interface
{
    public interface IStackADT
    {
        object Push(Object newItem);
        object Pop();
        object Peek();
        bool IsEmpty();
        void Clear();
    }
}