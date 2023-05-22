using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAlgorithms
{
    public class GridGraph<T>
    {
        private Dictionary<Node<T>, List<Node<T>>> _adjacencyList;

        public Dictionary<Node<T>, List<Node<T>>> AdjacencyList
        {
            get { return _adjacencyList; }
            set { _adjacencyList = value; }
        }

        public GridGraph()
        {
            _adjacencyList = new Dictionary<Node<T>, List<Node<T>>>();
        }

        public void AddNode(Node<T> node)
        {
            if(!_adjacencyList.ContainsKey(node))
            {
                _adjacencyList[node] = new List<Node<T>>();
            }
        }

        public void AddEdge(Node<T> source, Node<T> destination)
        {
            if(!AdjacencyList.ContainsKey(source))
            {
                AddNode(source);
            }
            if (!AdjacencyList.ContainsKey(destination))
            {
                AddNode(destination);
            }
            if(!HasEdge(source, destination))
            {
                AdjacencyList[source].Add(destination);
            }
            if(!HasEdge(destination, source))
            {
                AdjacencyList[destination].Add(source);
            }
        }

        public void AddEdges(Node<T>[,] edges)
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

        public bool HasEdge(Node<T> source, Node<T> destination)
        {
            if(!AdjacencyList.ContainsKey(source))
            {
                return false;
            }
            return AdjacencyList[source].Contains(destination);
        }
        public List<Node<T>> GetOutgoingNeighbors(Node<T> node)
        {
            if(!AdjacencyList.ContainsKey(node))
            {
                return new List<Node<T>>();
            }
            Console.WriteLine(AdjacencyList[node].ToString());
            return AdjacencyList[node].ToList();
        }
        public List<Node<T>> GetIncomingNeighbors(Node<T> node)
        {
            List<Node<T>> incomingNeighbors = new List<Node<T>>();

            foreach (KeyValuePair<Node<T>, List<Node<T>>> entry in AdjacencyList)
            {
                if (entry.Value.Contains(node))
                {
                    incomingNeighbors.Add(entry.Key);
                }
            }
            return incomingNeighbors;
        }
        public void RemoveEdge(Node<T> source, Node<T> destination)
        {
            if (!AdjacencyList.ContainsKey(source) || !AdjacencyList.ContainsKey(destination))
            {
                return;
            }
            AdjacencyList[source].Remove(destination);
        }
        public void RemoveNode(Node<T> node)
        {
            if (!AdjacencyList.ContainsKey(node))
            {
                return;
            }
            foreach (KeyValuePair<Node<T>, List<Node<T>>> kvp in AdjacencyList)
            {
                if (kvp.Value.Contains(node))
                {
                    AdjacencyList[kvp.Key].Remove(node);
                }
            }
            foreach (Node<T> neighbor in AdjacencyList[node])
            {
                AdjacencyList[neighbor].Remove(node);
            }

            AdjacencyList.Remove(node);
        }
        public void AddGrid(Node<T>[,] grid)
        {
            int numRows = grid.GetLength(0);
            int numCols = grid.GetLength(1);

            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numCols; col++)
                {
                    Node<T> node = grid[row, col];
                    AddNode(node);
                }
            }
            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numCols; col++)
                {
                    Node<T> node = grid[row, col];

                    if (col < numCols - 1)
                    {
                        Node<T> rightNeighbor = grid[row, col + 1];
                        AddEdge(node, rightNeighbor);
                    }

                    if (row < numRows - 1)
                    {
                        Node<T> bottomNeighbor = grid[row + 1, col];
                        AddEdge(node, bottomNeighbor);
                    }
                }
            }
        }
        public void Print()
        {
            foreach (KeyValuePair<Node<T>, List<Node<T>>> kvp in AdjacencyList)
            {
                Console.Write("Node: {0} <-> ", kvp.Key.Value);
                foreach (Node<T> value in kvp.Value)
                {
                    Console.Write("{0} ", value.Value);
                }
                Console.WriteLine();
            }
        }
    }   
}
