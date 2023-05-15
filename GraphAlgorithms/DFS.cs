namespace GraphAlgorithms
{
    public class DFS
    {
        public static bool HasPathDFS<T1, T2>(T1 graph, T2 source, T2 destination) where T1 : IGraph<T2>
        {
            HashSet<T2> visited = new HashSet<T2>();

            static bool HelperDFS(T1 graph, T2 source, T2 destination, HashSet<T2> visited)
            {
                if (EqualityComparer<T2>.Default.Equals(source, destination))
                {
                    return true;
                }
                visited.Add(source);

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

        public static int ConnectedComponentsCount<T1, T2>(T1 graph) where T1 : Graph<T2> where T2 : notnull
        {
            HashSet<T2> visited = new HashSet<T2>();
            int count = 0;

            foreach (KeyValuePair<T2, List<T2>> kvp in graph.AdjacencyList)
            {
                if(!visited.Contains(kvp.Key))
                {
                    DFSTraverseRecursive(graph.AdjacencyList, kvp.Key, visited);
                    count++;
                }
            }
            return count;
        }

        private static void DFSTraverseRecursive<T>(Dictionary<T, List<T>> adjacencyList, T source, HashSet<T> visited) where T : notnull
        {
            visited.Add(source);
            foreach (var neighbor in adjacencyList[source])
            {
                if(!visited.Contains(neighbor))
                {
                    DFSTraverseRecursive(adjacencyList, neighbor, visited);
                }
            }
        }
    }
}
