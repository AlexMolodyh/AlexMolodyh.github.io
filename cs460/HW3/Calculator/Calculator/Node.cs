namespace Calculator
{
    public class Node
    {
        public object Data;
        public Node Next;

        public Node()
        {
            Data = null;
            Next = null;
        }

        public Node(object data, Node next)
        {
            this.Data = data;
            this.Next = next;
        }
    }
}