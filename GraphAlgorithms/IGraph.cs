using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAlgorithms
{
    public interface IGraph<T>
    {
        void AddNode(T node);
        void AddEdge(T source, T destination);
        public void AddEdges(T[,] edges);
        bool HasEdge(T source, T destination);
        List<T> GetOutGoingNeighbors(T node);
        List<T> GetIncomingNeighbors(T node);
        void RemoveNode(T node);
        void RemoveEdge(T source, T destination);
    }
}
