using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAlgorithms
{
    public static class Grid
    {
        const char Land = 'L';
        public static int IslandCountGridGraph(GridGraph<char> grid)
        {
            HashSet<Node<char>> visited = new HashSet<Node<char>>();
            int result = 0;
            foreach (var node in grid.AdjacencyList.Keys)
            {
                if (node.Value == Land && !visited.Contains(node))
                {
                    visited.Add(node);
                    result += DFSTraverseRecursive(node, grid, visited, result);
                };
            }
            return result;
        }

        private static int DFSTraverseRecursive(Node<char> source, GridGraph<char> grid, HashSet<Node<char>> visited, int count)
        {
            foreach (var neighbor in grid.AdjacencyList[source])
            {
                if (!visited.Contains(neighbor) && neighbor.Value == Land)
                {
                    visited.Add(neighbor);
                    DFSTraverseRecursive(neighbor, grid, visited, count);
                };
            }
            return 1;
        }

        public static int IslandCountGrid(char[,] grid)
        {
            HashSet<(int, int)> visited = new HashSet<(int, int)>();
            int result = 0;
            for (int r = 0; r < grid.GetLength(0); r++)
            {
                for (int c = 0; c < grid.GetLength(1); c++)
                {
                    if (Explore(grid, r, c, visited))
                    {
                        result += 1;
                    }
                }
            }
            return result;
        }

        private static bool Explore(char[,] grid, int r, int c, HashSet<(int, int)> visited)
        {
            if (!(r >= 0 && r < grid.GetLength(0)) || !(c >= 0 && c < grid.GetLength(1)))
            {
                return false;
            }
            if (grid[r, c] != Land)
            {
                return false;
            }
            (int, int) position = (r, c);
            if (visited.Contains(position))
            {
                return false;
            }
            visited.Add(position);

            Explore(grid, r - 1, c, visited);
            Explore(grid, r + 1, c, visited);
            Explore(grid, r, c - 1, visited);
            Explore(grid, r, c + 1, visited);

            return true;
        }

        public static int MinIslandSizeGrid(char[,] grid)
        {
            HashSet<(int, int)> visited = new HashSet<(int, int)>();
            int size = 0;
            int currentSize = 0;

            for (int r = 0; r < grid.GetLength(0); r++)
            {
                for (int c = 0; c < grid.GetLength(1); c++)
                {
                    int returnedSize = ExploreMinIsland(grid, r, c, visited, currentSize);
                    if(returnedSize > 0 && size == 0)
                    {
                        size = returnedSize;
                    }
                    else if(returnedSize > 0 && size != 0)
                    {
                        size = Math.Min(size, returnedSize);
                    }
                }
            }
            return size;
        }

        private static int ExploreMinIsland(char[,] grid, int r, int c, HashSet<(int, int)> visited, int currentSize)
        {
            if (!(r >= 0 && r < grid.GetLength(0)) || !(c >= 0 && c < grid.GetLength(1)))
            {
                return 0;
            }
            if (grid[r, c] != Land)
            {
                return 0;
            }
            (int, int) position = (r, c);
            if (visited.Contains(position))
            {
                return 0;
            }
            visited.Add(position);

            currentSize = 1;

            currentSize += ExploreMinIsland(grid, r - 1, c, visited, currentSize);
            currentSize += ExploreMinIsland(grid, r + 1, c, visited, currentSize);
            currentSize += ExploreMinIsland(grid, r, c - 1, visited, currentSize);
            currentSize += ExploreMinIsland(grid, r, c + 1, visited, currentSize);

            return currentSize;
        }
    }
}
