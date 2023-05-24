namespace GraphAlgorithms
{
    public class BFS
    {
        public static bool HasPathBFS<T1, T2>(T1 graph, T2 source, T2 destination) where T1 : Graph<T2> where T2 : notnull
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

        public static int ShortestPathBFS<T1, T2>(T1 graph, T2 source, T2 destination) where T1 : Graph<T2> where T2 : notnull
        {
            Queue<(T2, int)> queue = new Queue<(T2, int)>();
            queue.Enqueue((source, 0));
            HashSet<T2> visited = new HashSet<T2>();

            while (queue.Count > 0)
            {
                var (current, distance) = queue.Dequeue();
                visited.Add(current);
                if (EqualityComparer<T2>.Default.Equals(current, destination))
                {
                    return distance;
                }
                if (!graph.AdjacencyList.ContainsKey(current))
                {
                    return -1;
                }
                foreach (var neighbor in graph.AdjacencyList[current])
                {
                    if (!visited.Contains(neighbor))
                    {
                        queue.Enqueue((neighbor, distance + 1));
                    }
                    visited.Add(neighbor);
                }
            }
            return -1;
        }
    }
}
