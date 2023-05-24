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

        public static Node<T>[,] MakeNodeGrid(T[,] grid)
        {
            Node<T>[,] nodeGrid = new Node<T>[grid.GetLength(0),grid.GetLength(1)];
            for (int r = 0; r < grid.GetLength(0); r++)
            {
                for (int c = 0; c < grid.GetLength(1); c++)
                {
                    nodeGrid[r,c] = new Node<T>(grid[r,c]);
                }
            }
            return nodeGrid;
        }
    }
}
