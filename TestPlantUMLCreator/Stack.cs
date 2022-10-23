namespace TestPlantUMLCreator
{
    public class Stack
    {
        internal class Element
        {
            public Element(int data, Element? next)
            {
                Data = data;
                Next = next;
            }
            public int Data { get; set; }
            public Element? Next { get; set; }
        }
        private Element? head;

        public bool IsEmpty => head == null;
        public void Push(int data)
        {
            head = new Element(data, head);
        }
        public int Pop()
        {
            if (head == null) 
                throw new InvalidOperationException("Stack is empty");

            Element temp = head;

            head = head.Next;
            return temp.Data;
        }
    }
}
