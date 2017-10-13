namespace Calculator
{
    //compile with: /doc:Calculator.xml
    
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