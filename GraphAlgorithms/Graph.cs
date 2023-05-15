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
            if (!_adjacencyList.ContainsKey(node))
            {
                _adjacencyList[node] = new List<T>();
            }
        }

        public void AddEdge(T source, T destination)
        {
            if(EqualityComparer<T>.Default.Equals(source, destination))
            {
                throw new ArgumentException("Source and destination cannot be the same!");
            }
            if (!_adjacencyList.ContainsKey(source))
            {
                AddNode(source);
            }
            if (!_adjacencyList[source].Contains(destination))
            {
                AddNode(destination);
            }
            if (!HasEdge(source, destination))
            {
                _adjacencyList[source].Add(destination);
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
            if (!_adjacencyList.ContainsKey(node))
            {
                return new List<T>();
            }
            Console.WriteLine(_adjacencyList[node]);
            return _adjacencyList[node].ToList();
        }
        public List<T> GetIncomingNeighbors(T node)
        {
            List<T> incomingNeighbors = new List<T>();

            foreach (KeyValuePair<T, List<T>> entry in _adjacencyList)
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
            if (!_adjacencyList.ContainsKey(source))
            {
                return false;
            }
            return _adjacencyList[source].Contains(destination);
        }
        public void RemoveEdge(T source, T destination)
        {
            if (!_adjacencyList.ContainsKey(source) || !_adjacencyList.ContainsKey(destination))
            {
                return;
            }
            _adjacencyList[source].Remove(destination);
        }

        public void RemoveNode(T node)
        {
            if (!_adjacencyList.ContainsKey(node))
            {
                return;
            }
            foreach (KeyValuePair<T, List<T>> kvp in _adjacencyList)
            {
                if (kvp.Value.Contains(node))
                {
                    _adjacencyList[kvp.Key].Remove(node);
                }
            }
            foreach (T neighbor in _adjacencyList[node])
            {
                _adjacencyList[neighbor].Remove(node);
            }

            _adjacencyList.Remove(node);
        }
    }
}
