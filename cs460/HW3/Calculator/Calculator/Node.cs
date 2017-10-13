namespace Calculator
{
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

        public object Data { get; set; }

        public Node Next
        {
            get; set;
        }
    }
}