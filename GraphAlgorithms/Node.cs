namespace GraphAlgorithms
{
    public class Node<T>
    {
        private T value;

        public Node(T value)
        {
            this.value = value;
        }

        public T Value
        {
            get { return value; }
            set { this.value = value; }
        }
    }
}
