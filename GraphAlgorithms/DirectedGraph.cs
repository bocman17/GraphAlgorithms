using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            List<T> visited = new List<T>();
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
    }   
}
