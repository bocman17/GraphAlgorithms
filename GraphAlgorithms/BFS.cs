namespace GraphAlgorithms
{
    public class BFS
    {
        public static bool HasPathBFS<T1,T2>(T1 graph, T2 source, T2 destination) where T1 : IGraph<T2>
        {
            Queue<T2> queue = new Queue<T2>();
            queue.Enqueue(source);
            List<T2> visited = new List<T2>();
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

        //public static bool HasPathBFS<T>(DirectedGraph<T> graph, T source, T destination) where T : notnull
        //{
        //    Queue<T> queue = new Queue<T>();
        //    queue.Enqueue(source);
        //    List<T> visited = new List<T>();
        //    while (queue.Count > 0)
        //    {
        //        var current = queue.Dequeue();
        //        visited.Add(current);
        //        if (EqualityComparer<T>.Default.Equals(current, destination))
        //        {
        //            return true;
        //        }
        //        foreach (var neighbor in graph.GetNeighbors(current))
        //        {
        //            if (!visited.Contains(neighbor))
        //            {
        //                queue.Enqueue(neighbor);
        //            }
        //            visited.Add(neighbor);
        //        }
        //    }
        //    return false;
        //}
    }
}
