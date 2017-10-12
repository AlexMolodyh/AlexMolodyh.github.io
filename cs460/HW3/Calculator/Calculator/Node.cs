namespace Calculator
{
    public class Node<T>
    {
        public object Data;
        public T Next;

        public Node()
        {
            Data = null;
            Next = default(T);
        }

        public Node(object data, T next)
        {
            this.Data = data;
            this.Next = next;
        }
    }
}