using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAlgorithmsTest
{
    [TestFixture]
    public class ShortestPath_Test
    {
        [Test]
        public void DirectedGraphIsEmpty()
        {
            DirectedGraph<char> graph = new DirectedGraph<char>() { };
            int result = BFS.ShortestPathBFS(graph, 'a', 'b');
            Assert.That(result, Is.EqualTo(-1));
        }
        [Test]
        public void DirectedGraphSourceIsNotInGraph()
        {
            DirectedGraph<char> graph = new DirectedGraph<char>();
            graph.AddEdges(new char[,]
            {
                { 'a', 'b' },
                { 'a', 'c' },
                { 'c', 'd' },
                { 'd', 'e' },

            });
            int result = BFS.ShortestPathBFS(graph, 'f', 'b');
            Assert.That(result, Is.EqualTo(-1));
        }
        [Test]
        public void DirectedGraphDestinationIsNotInGraph()
        {
            DirectedGraph<char> graph = new DirectedGraph<char>();
            graph.AddEdges(new char[,]
            {
                { 'a', 'b' },
                { 'a', 'c' },
                { 'c', 'd' },
                { 'd', 'e' },

            });
            int result = BFS.ShortestPathBFS(graph, 'a', 'f');
            Assert.That(result, Is.EqualTo(-1));
        }
        [Test]
        public void DirectedGraphSourceAndDestinationAreTheSame()
        {
            DirectedGraph<char> graph = new DirectedGraph<char>();
            graph.AddEdges(new char[,]
            {
                { 'a', 'b' },
                { 'a', 'c' },
                { 'c', 'd' },
                { 'd', 'e' },

            });
            int result = BFS.ShortestPathBFS(graph, 'b', 'b');
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void DirectedGraphSourceAndDestinationAreNotConnected()
        {
            DirectedGraph<char> graph = new DirectedGraph<char>();
            graph.AddEdges(new char[,]
            {
                { 'a', 'b' },
                { 'b', 'c' },
                { 'c', 'd' },
                { 'e', 'f' },
            });
            int result = BFS.ShortestPathBFS(graph, 'a', 'f');
            Assert.That(result, Is.EqualTo(-1));
        }

        [Test]
        public void DirectedGraphMultiTest()
        {
            List<char[,]> edges = DirectedEdges();
            DirectedGraph<char> graph1 = new DirectedGraph<char>();
            graph1.AddEdges(edges[0]);
            DirectedGraph<char> graph2 = new DirectedGraph<char>();
            graph2.AddEdges(edges[1]);
            DirectedGraph<char> graph3 = new DirectedGraph<char>();
            graph3.AddEdges(edges[2]);

            int result1 = BFS.ShortestPathBFS(graph1, 'a', 'g');
            int result2 = BFS.ShortestPathBFS(graph2, 'a', 'f');
            int result3 = BFS.ShortestPathBFS(graph3, 'd', 'f');

            Assert.Multiple(() =>
            {
                Assert.That(result1, Is.EqualTo(6));
                Assert.That(result2, Is.EqualTo(2));
                Assert.That(result3, Is.EqualTo(3));
            });
        }

        [Test]
        public void UndirectedGraphIsEmpty()
        {
            UndirectedGraph<char> graph = new UndirectedGraph<char>() { };
            int result = BFS.ShortestPathBFS(graph, 'a', 'b');
            Assert.That(result, Is.EqualTo(-1));
        }
        [Test]
        public void UndirectedGraphSourceIsNotInGraph()
        {
            UndirectedGraph<char> graph = new UndirectedGraph<char>();
            graph.AddEdges(new char[,]
            {
                { 'a', 'b' },
                { 'a', 'c' },
                { 'c', 'd' },
                { 'd', 'e' },

            });
            int result = BFS.ShortestPathBFS(graph, 'f', 'b');
            Assert.That(result, Is.EqualTo(-1));
        }
        [Test]
        public void UndirectedGraphDestinationIsNotInGraph()
        {
            UndirectedGraph<char> graph = new UndirectedGraph<char>();
            graph.AddEdges(new char[,]
            {
                { 'a', 'b' },
                { 'a', 'c' },
                { 'c', 'd' },
                { 'd', 'e' },

            });
            int result = BFS.ShortestPathBFS(graph, 'a', 'f');
            Assert.That(result, Is.EqualTo(-1));
        }
        [Test]
        public void UndirectedGraphSourceAndDestinationAreTheSame()
        {
            UndirectedGraph<char> graph = new UndirectedGraph<char>();
            graph.AddEdges(new char[,]
            {
                { 'a', 'b' },
                { 'a', 'c' },
                { 'c', 'd' },
                { 'd', 'e' },

            });
            int result = BFS.ShortestPathBFS(graph, 'b', 'b');
            Assert.That(result, Is.EqualTo(0));
        }
        [Test]
        public void UndirectedGraphSourceAndDestinationAreNotConnected()
        {
            DirectedGraph<char> graph = new DirectedGraph<char>();
            graph.AddEdges(new char[,]
            {
                { 'a', 'b' },
                { 'b', 'c' },
                { 'c', 'd' },
                { 'e', 'f' },
            });
            int result = BFS.ShortestPathBFS(graph, 'a', 'f');
            Assert.That(result, Is.EqualTo(-1));
        }

        [Test]
        public void UndirectedGraphMultiTest()
        {
            List<char[,]> edges = UndirectedEdges();
            UndirectedGraph<char> graph1 = new UndirectedGraph<char>();
            graph1.AddEdges(edges[0]);
            UndirectedGraph<char> graph2 = new UndirectedGraph<char>();
            graph2.AddEdges(edges[1]);
            UndirectedGraph<char> graph3 = new UndirectedGraph<char>();
            graph3.AddEdges(edges[2]);

            int result1 = BFS.ShortestPathBFS(graph1, 'a', 'g');
            int result2 = BFS.ShortestPathBFS(graph2, 'a', 'f');
            int result3 = BFS.ShortestPathBFS(graph3, 'd', 'f');

            Assert.Multiple(() =>
            {
                Assert.That(result1, Is.EqualTo(6));
                Assert.That(result2, Is.EqualTo(2));
                Assert.That(result3, Is.EqualTo(3));
            });
        }

        private static List<char[,]> UndirectedEdges()
        {
            List<char[,]> edges = new List<char[,]>
            {
                new char[,]
                {
                    { 'a', 'b' },
                    { 'c', 'b' },
                    { 'd', 'c' },
                    { 'd', 'e' },
                    { 'e', 'f' },
                    { 'g', 'f' },
                },
                new char[,]
                {
                    { 'a', 'b' },
                    { 'c', 'b' },
                    { 'd', 'c' },
                    { 'd', 'e' },
                    { 'f', 'g' },
                    { 'f', 'b' },
                },
                new char[,]
                {
                    { 'a', 'b' },
                    { 'c', 'b' },
                    { 'a', 'c' },
                    { 'd', 'c' },
                    { 'd', 'e' },
                    { 'f', 'g' },
                    { 'f', 'b' },
                }
            };
            return edges;
        }

        private static List<char[,]> DirectedEdges()
        {
            List<char[,]> edges = new List<char[,]>
            {
                new char[,]
                {
                    { 'a', 'b' },
                    { 'b', 'c' },
                    { 'c', 'd' },
                    { 'd', 'e' },
                    { 'e', 'f' },
                    { 'f', 'g' },
                },
                new char[,]
                {
                    { 'a', 'b' },
                    { 'b', 'c' },
                    { 'c', 'd' },
                    { 'd', 'e' },
                    { 'f', 'g' },
                    { 'f', 'b' },
                    { 'b', 'f' },
                },
                new char[,]
                {
                    { 'a', 'b' },
                    { 'c', 'b' },
                    { 'a', 'c' },
                    { 'c', 'a' },
                    { 'd', 'c' },
                    { 'd', 'e' },
                    { 'f', 'g' },
                    { 'b', 'f' },
                }
            };
            return edges;
        }
    }
}
