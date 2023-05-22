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
            if (EqualityComparer<T>.Default.Equals(source, destination))
            {
                throw new ArgumentException("Source and destination cannot be the same!");
            }
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
            if (edges.GetLength(1) != 2)
            {
                throw new ArgumentException("Input must have exactly 2 nodes!");
            }
            for (int i = 0; i < edges.GetLength(0); i++)
            {
                AddEdge(edges[i, 0], edges[i, 1]);
            }
        }

        public void AddGrid(T[,] grid)
        {
            int numRows = grid.GetLength(0);
            int numCols = grid.GetLength(1);

            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numCols; col++)
                {
                    T node = grid[row, col];
                    AddNode(node);
                }
            }
            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numCols; col++)
                {
                    T node = grid[row, col];

                    if (col < numCols - 1)
                    {
                        T rightNeighbor = grid[row, col + 1];
                        AddEdge(node, rightNeighbor);
                    }

                    if (row < numRows - 1)
                    {
                        T bottomNeighbor = grid[row + 1, col];
                        AddEdge(node, bottomNeighbor);
                    }
                }
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
