namespace GraphAlgorithms
{
    public class BFS
    {
        public static bool HasPathBFS<T1,T2>(T1 graph, T2 source, T2 destination) where T1 : IGraph<T2>
        {
            Queue<T2> queue = new Queue<T2>();
            queue.Enqueue(source);
            HashSet<T2> visited = new HashSet<T2>();
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                visited.Add(current);
                if (EqualityComparer<T2>.Default.Equals(current, destination))
                {
                    return true;
                }
                foreach (var neighbor in graph.GetOutGoingNeighbors(current))
                {
                    if (!visited.Contains(neighbor))
                    {
                        queue.Enqueue(neighbor);
                    }
                    visited.Add(neighbor);
                }
            }
            return false;
        }
    }
}
