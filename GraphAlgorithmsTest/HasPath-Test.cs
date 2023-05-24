using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAlgorithmsTest
{
    [TestFixture]
    public class HasPath_Test
    {
        [Test]
        public void DirectedDFSHasPathNoCycleTrueTest()
        {
            DirectedGraph<char> graph = new DirectedGraph<char>();
            graph.AddEdges(new char[,] {
                { 'f', 'g' },
                { 'f', 'i'},
                { 'g', 'h' },
                { 'i', 'g' },
                { 'i', 'k' },
                { 'j', 'i' },
            });

            var result = DFS.HasPathDFS(graph, 'f', 'k');

            Assert.That(result, Is.True);
        }

        [Test]
        public void DirectedDFSHasPathNoCycleFalseTest()
        {
            DirectedGraph<char> graph = new DirectedGraph<char>();
            graph.AddEdges(new char[,] {
                { 'f', 'g' },
                { 'f', 'i'},
                { 'g', 'h' },
                { 'i', 'g' },
                { 'i', 'k' },
                { 'j', 'i' },
            });

            var result = DFS.HasPathDFS(graph, 'f', 'j');

            Assert.That(result, Is.False);
        }

        [Test]
        public void DirectedDFSHasPathCycleTrueTest()
        {
            DirectedGraph<char> graph = new DirectedGraph<char>();
            graph.AddEdges(new char[,] {
                { 'f', 'g' },
                { 'f', 'i'},
                { 'g', 'f'},
                { 'g', 'h' },
                { 'i', 'g' },
                { 'i', 'k' },
                { 'j', 'i' },
            });

            var result = DFS.HasPathDFS(graph, 'f', 'k');

            Assert.That(result, Is.True);
        }

        [Test]
        public void DirectedDFSHasPathCycleFalseTest()
        {
            DirectedGraph<char> graph = new DirectedGraph<char>();
            graph.AddEdges(new char[,] {
                { 'f', 'g' },
                { 'f', 'i'},
                { 'g', 'f'},
                { 'g', 'h' },
                { 'i', 'g' },
                { 'i', 'k' },
                { 'j', 'i' },
            });

            var result = DFS.HasPathDFS(graph, 'f', 'j');

            Assert.That(result, Is.False);
        }

        [Test]
        public void UndirectedDFSHasPathNoCycleTrueTest()
        {
            UndirectedGraph<char> graph = new UndirectedGraph<char>();
            graph.AddEdges(new char[,] {
                { 'f', 'g' },
                { 'f', 'i'},
                { 'g', 'h' },
                { 'i', 'k' },
                { 'j', 'i' },
            });

            var result = DFS.HasPathDFS(graph, 'f', 'k');

            Assert.That(result, Is.True);
        }

        [Test]
        public void UndirectedDFSHasPathNoCycleFalseTest()
        {
            UndirectedGraph<char> graph = new UndirectedGraph<char>();
            graph.AddEdges(new char[,] {
                { 'f', 'g' },
                { 'f', 'i'},
                { 'g', 'h' },
                { 'i', 'k' },
                { 'j', 'i' },
                { 'l', 'm' }
            });

            var result = DFS.HasPathDFS(graph, 'f', 'l');

            Assert.That(result, Is.False);
        }

        [Test]
        public void UndirectedDFSHasPathCycleTrueTest()
        {
            UndirectedGraph<char> graph = new UndirectedGraph<char>();
            graph.AddEdges(new char[,] {
                { 'f', 'g' },
                { 'f', 'i'},
                { 'g', 'f'},
                { 'g', 'h' },
                { 'i', 'g' },
                { 'i', 'k' },
                { 'j', 'i' },
            });

            var result = DFS.HasPathDFS(graph, 'f', 'k');

            Assert.That(result, Is.True);
        }

        [Test]
        public void UndirectedDFSHasPathCycleFalseTest()
        {
            UndirectedGraph<char> graph = new UndirectedGraph<char>();
            graph.AddEdges(new char[,] {
                { 'f', 'g' },
                { 'f', 'i'},
                { 'g', 'f'},
                { 'g', 'h' },
                { 'i', 'g' },
                { 'i', 'k' },
                { 'j', 'i' },
                { 'l', 'm' }
            });

            var result = DFS.HasPathDFS(graph, 'f', 'l');

            Assert.That(result, Is.False);
        }

        [Test]
        public void DirectedBFSHasPathNoCycleTrueTest()
        {
            DirectedGraph<char> graph = new DirectedGraph<char>();
            graph.AddEdges(new char[,] {
                { 'f', 'g' },
                { 'f', 'i'},
                { 'g', 'h' },
                { 'i', 'g' },
                { 'i', 'k' },
                { 'j', 'i' },
            });

            var result = BFS.HasPathBFS(graph, 'f', 'k');

            Assert.That(result, Is.True);
        }

        [Test]
        public void DirectedBFSHasPathNoCycleFalseTest()
        {
            DirectedGraph<char> graph = new DirectedGraph<char>();
            graph.AddEdges(new char[,] {
                { 'f', 'g' },
                { 'f', 'i'},
                { 'g', 'h' },
                { 'i', 'g' },
                { 'i', 'k' },
                { 'j', 'i' },
            });

            var result = BFS.HasPathBFS(graph, 'f', 'j');

            Assert.That(result, Is.False);
        }

        [Test]
        public void DirectedBFSHasPathCycleTrueTest()
        {
            DirectedGraph<char> graph = new DirectedGraph<char>();
            graph.AddEdges(new char[,] {
                { 'f', 'g' },
                { 'f', 'i'},
                { 'g', 'f'},
                { 'g', 'h' },
                { 'i', 'g' },
                { 'i', 'k' },
                { 'j', 'i' },
            });

            var result = BFS.HasPathBFS(graph, 'f', 'k');

            Assert.That(result, Is.True);
        }

        [Test]
        public void DirectedBFSHasPathCycleFalseTest()
        {
            DirectedGraph<char> graph = new DirectedGraph<char>();
            graph.AddEdges(new char[,] {
                { 'f', 'g' },
                { 'f', 'i'},
                { 'g', 'f'},
                { 'g', 'h' },
                { 'i', 'g' },
                { 'i', 'k' },
                { 'j', 'i' },
            });

            var result = BFS.HasPathBFS(graph, 'f', 'j');

            Assert.That(result, Is.False);
        }

        [Test]
        public void UndirectedBFSHasPathNoCycleTrueTest()
        {
            UndirectedGraph<char> graph = new UndirectedGraph<char>();
            graph.AddEdges(new char[,] {
                { 'f', 'g' },
                { 'f', 'i'},
                { 'g', 'h' },
                { 'i', 'k' },
                { 'j', 'i' },
            });

            var result = BFS.HasPathBFS(graph, 'f', 'k');

            Assert.That(result, Is.True);
        }

        [Test]
        public void UndirectedBFSHasPathNoCycleFalseTest()
        {
            UndirectedGraph<char> graph = new UndirectedGraph<char>();
            graph.AddEdges(new char[,] {
                { 'f', 'g' },
                { 'f', 'i'},
                { 'g', 'h' },
                { 'i', 'k' },
                { 'j', 'i' },
                { 'l', 'm' }
            });

            var result = BFS.HasPathBFS(graph, 'f', 'l');

            Assert.That(result, Is.False);
        }

        [Test]
        public void UndirectedBFSHasPathCycleTrueTest()
        {
            UndirectedGraph<char> graph = new UndirectedGraph<char>();
            graph.AddEdges(new char[,] {
                { 'f', 'g' },
                { 'f', 'i'},
                { 'g', 'f'},
                { 'g', 'h' },
                { 'i', 'g' },
                { 'i', 'k' },
                { 'j', 'i' },
            });

            var result = BFS.HasPathBFS(graph, 'f', 'k');

            Assert.That(result, Is.True);
        }

        [Test]
        public void UndirectedBFSHasPathCycleFalseTest()
        {
            UndirectedGraph<char> graph = new UndirectedGraph<char>();
            graph.AddEdges(new char[,] {
                { 'f', 'g' },
                { 'f', 'i'},
                { 'g', 'f'},
                { 'g', 'h' },
                { 'i', 'g' },
                { 'i', 'k' },
                { 'j', 'i' },
                { 'l', 'm' }
            });

            var result = BFS.HasPathBFS(graph, 'f', 'l');

            Assert.That(result, Is.False);
        }
    }
}
