using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAlgorithms
{
    public class UndirectedGraph<T> : Graph<T> where T : notnull
    {
        public new void AddEdge(T source, T destination)
        {
            if (!AdjacencyList.ContainsKey(source))
            {
                AddNode(source);
            }
            if (!AdjacencyList.ContainsKey(destination))
            {
                AddNode(destination);
            }
            if (!HasEdge(source, destination))
            {
                AdjacencyList[source].Add(destination);
            }
            if (!HasEdge(destination, source))
            {
                AdjacencyList[destination].Add(source);
            }
        }
        public new void AddEdges(T[,] edges)
        {
            for (int i = 0; i < edges.GetLength(0); i++)
            {
                AddEdge(edges[i, 0], edges[i, 1]);
            }
        }
        public new List<T> GetIncomingNeighbors(T node)
        {
            if (AdjacencyList.ContainsKey(node))
            {
                return AdjacencyList[node];
            }
            return new List<T>();
        }
        public void BFSTraverseIterative(T source)
        {
            Queue<T> queue = new Queue<T>();
            queue.Enqueue(source);
            List<T> visited = new List<T>();

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
            List<T> visited = new List<T>();

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
            List<T> visited = new List<T>();

            void DFSHelper(T source, List<T> visited)
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
        public void Print()
        {
            foreach (KeyValuePair<T, List<T>> kvp in AdjacencyList)
            {
                Console.Write("Node: {0} <-> ", kvp.Key);
                foreach (T value in kvp.Value)
                {
                    Console.Write("{0} ", value);
                }
                Console.WriteLine();
            }
        }
    }
}
