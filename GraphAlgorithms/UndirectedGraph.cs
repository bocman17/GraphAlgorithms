using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAlgorithms
{
    public class UndirectedGraph<T> : DirectedGraph<T> where T : notnull
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
        public new void Print()
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
