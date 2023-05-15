namespace GraphAlgorithms
{
    public class DirectedGraph<T> : Graph<T> where T : notnull
    {
        public void Print()
        {
            foreach (KeyValuePair<T, List<T>> kvp in AdjacencyList)
            {
                Console.Write("Node: {0} -> ", kvp.Key);
                foreach (T value in kvp.Value)
                {
                    Console.Write("{0} ", value);
                }
                Console.WriteLine();
            }
        }
        public void BFSTraverseIterative(T source)
        {
            Queue<T> queue = new Queue<T>();
            HashSet<T> visited = new HashSet<T>();
            queue.Enqueue(source);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (!visited.Contains(current))
                {
                    Console.WriteLine(current);
                }
                visited.Add(current);
                foreach (var neighbor in AdjacencyList[current])
                {
                    if (!visited.Contains(neighbor))
                    {
                        queue.Enqueue(neighbor);
                    }
                }
            }
        }
        public void DFSTraverseIterative(T source)
        {
            Stack<T> stack = new Stack<T>();
            stack.Push(source);
            HashSet<T> visited = new HashSet<T>();

            while (stack.Count > 0)
            {
                var current = stack.Pop();
                visited.Add(current);
                Console.WriteLine(current);
                foreach (var neighbor in AdjacencyList[current])
                {
                    if (!visited.Contains(neighbor))
                    {
                        stack.Push(neighbor);
                        visited.Add(neighbor);
                    }
                }
            }
        }
        public void DFSTraverseRecursive(T source)
        {
            HashSet<T> visited = new HashSet<T>();

            void DFSHelper(T source, HashSet<T> visited)
            {
                if (!visited.Contains(source))
                {
                    Console.WriteLine(source);
                }
                visited.Add(source);
                foreach (var neighbor in AdjacencyList[source])
                {
                    if (!visited.Contains(neighbor))
                    {
                        DFSHelper(neighbor, visited);
                    }
                }
            }
            DFSHelper(source, visited);
        }
    }   
}
