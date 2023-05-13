namespace GraphAlgorithms
{
    public class DFS
    {
        public static bool HasPathDFS<T1, T2>(T1 graph, T2 source, T2 destination) where T1 : IGraph<T2>
        {
            List<T2> visited = new List<T2>();

            static bool HelperDFS(T1 graph, T2 source, T2 destination, List<T2> visited)
            {
                visited.Add(source);

                if (EqualityComparer<T2>.Default.Equals(source, destination))
                {
                    return true;
                }

                foreach (var neighbor in graph.GetOutGoingNeighbors(source))
                {
                    if (visited.Contains(neighbor))
                    {
                        continue;
                    }
                    if (HelperDFS(graph, neighbor, destination, visited))
                    {
                        return true;
                    }
                }
                return false;
            }
            return HelperDFS(graph, source, destination, visited);
        }
    }
}
