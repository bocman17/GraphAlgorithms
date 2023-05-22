using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GraphAlgorithms
{
    public abstract class Graph<T> : IGraph<T> where T : notnull
    {
        private Dictionary<T, List<T>> _adjacencyList;

        public Dictionary<T, List<T>> AdjacencyList
        {
            get { return _adjacencyList; }
            set { _adjacencyList = value; }
        }

        public Graph()
        {
            _adjacencyList = new Dictionary<T, List<T>>();
        }
        public void AddNode(T node)
        {
            if (!AdjacencyList.ContainsKey(node))
            {
                AdjacencyList[node] = new List<T>();
            }
        }

        public void AddEdge(T source, T destination)
        {
            if(EqualityComparer<T>.Default.Equals(source, destination))
            {
                throw new ArgumentException("Source and destination cannot be the same!");
            }
            if (!AdjacencyList.ContainsKey(source))
            {
                AddNode(source);
            }
            if (!AdjacencyList[source].Contains(destination))
            {
                AddNode(destination);
            }
            if (!HasEdge(source, destination))
            {
                AdjacencyList[source].Add(destination);
            }
        }

        public void AddEdges(T[,] edges)
        {
            if (edges.GetLength(1) != 2)
            {
                throw new ArgumentException("Input must have exactly 2 nodes!");
            }
            for (int i = 0; i < edges.GetLength(0); i++)
            {
                AddEdge(edges[i, 0], edges[i, 1]);
            }
        }
        public List<T> GetOutGoingNeighbors(T node)
        {
            if (!AdjacencyList.ContainsKey(node))
            {
                return new List<T>();
            }
            Console.WriteLine(AdjacencyList[node]);
            return AdjacencyList[node].ToList();
        }
        public List<T> GetIncomingNeighbors(T node)
        {
            List<T> incomingNeighbors = new List<T>();

            foreach (KeyValuePair<T, List<T>> entry in AdjacencyList)
            {
                if (entry.Value.Contains(node))
                {
                    incomingNeighbors.Add(entry.Key);
                }
            }
            return incomingNeighbors;
        }

        public bool HasEdge(T source, T destination)
        {
            if (!AdjacencyList.ContainsKey(source))
            {
                return false;
            }
            return AdjacencyList[source].Contains(destination);
        }
        public void RemoveEdge(T source, T destination)
        {
            if (!AdjacencyList.ContainsKey(source) || !AdjacencyList.ContainsKey(destination))
            {
                return;
            }
            AdjacencyList[source].Remove(destination);
        }

        public void RemoveNode(T node)
        {
            if (!AdjacencyList.ContainsKey(node))
            {
                return;
            }
            foreach (KeyValuePair<T, List<T>> kvp in AdjacencyList)
            {
                if (kvp.Value.Contains(node))
                {
                    AdjacencyList[kvp.Key].Remove(node);
                }
            }
            foreach (T neighbor in AdjacencyList[node])
            {
                AdjacencyList[neighbor].Remove(node);
            }

            AdjacencyList.Remove(node);
        }
    }
}
