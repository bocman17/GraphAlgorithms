using GraphAlgorithms;

namespace GraphAlgorithmsTest
{
    [TestFixture]
    public class UndirectedGraph_Test
    {
        [Test]
        public void PrintTest()
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            UndirectedGraph<char> graph = new UndirectedGraph<char>();
            graph.AddEdges(new char[,] { { 'a', 'b' }, { 'a', 'c' }, { 'b', 'd' } });
            graph.Print();

            var consoleOutput = stringWriter.ToString();

            Assert.That(consoleOutput, Is.EqualTo("Node: a <-> b c \r\nNode: b <-> a d \r\nNode: c <-> a \r\nNode: d <-> b \r\n"));
        }

        [Test]
        public void AddNodeTest()
        {
            UndirectedGraph<char> graph = new UndirectedGraph<char>();
            graph.AddNode('a');
            graph.AddNode('b');
            graph.AddNode('c');
            List<char> result = new List<char>();
            List<char> expected = new List<char>() { 'a', 'b', 'c' };
            foreach (KeyValuePair<char, List<char>> kvp in graph.AdjacencyList)
            {
                result.Add(kvp.Key);
            }

            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void AddEdgeTest()
        {
            UndirectedGraph<char> graph1 = new UndirectedGraph<char>();
            UndirectedGraph<char> graph2 = new UndirectedGraph<char>();
            UndirectedGraph<char> graph3 = new UndirectedGraph<char>();

            graph1.AddEdge('a', 'b');

            graph2.AddEdge('a', 'b');
            graph2.AddEdge('b', 'a');

            graph3.AddEdge('a', 'b');
            graph3.AddEdge('b', 'c');
            graph3.AddEdge('c', 'd');

            Dictionary<char, List<char>>[] expected = TestDictionaries();

            CollectionAssert.AreEqual(expected[0], graph1.AdjacencyList);
            CollectionAssert.AreEqual(expected[1], graph2.AdjacencyList);
            CollectionAssert.AreEqual(expected[2], graph3.AdjacencyList);
        }

        [Test]
        public void AddEdgesTest()
        {
            UndirectedGraph<char> graph1 = new UndirectedGraph<char>();
            UndirectedGraph<char> graph2 = new UndirectedGraph<char>();
            UndirectedGraph<char> graph3 = new UndirectedGraph<char>();

            graph1.AddEdges(new char[,] { { 'a', 'b' } });
            graph2.AddEdges(new char[,] { { 'a', 'b' }, { 'b', 'a' } });
            graph3.AddEdges(new char[,] { { 'a', 'b' }, { 'b', 'c' }, { 'c', 'd' } });

            Dictionary<char, List<char>>[] expected = TestDictionaries();

            CollectionAssert.AreEqual(expected[0], graph1.AdjacencyList);
            CollectionAssert.AreEqual(expected[1], graph2.AdjacencyList);
            CollectionAssert.AreEqual(expected[2], graph3.AdjacencyList);
        }

        [Test]
        public void GetOutGoingNeighborsTest()
        {
            UndirectedGraph<char> graph1 = new UndirectedGraph<char>();
            UndirectedGraph<char> graph2 = new UndirectedGraph<char>();
            UndirectedGraph<char> graph3 = new UndirectedGraph<char>();

            graph1.AddEdges(new char[,] { { 'a', 'b' } });
            graph2.AddEdges(new char[,] { { 'a', 'b' }, { 'b', 'a' } });
            graph3.AddEdges(new char[,] { { 'a', 'b' }, { 'b', 'c' }, { 'c', 'd' } });

            List<char> result1 = graph1.GetOutGoingNeighbors('a');
            List<char> result2 = graph2.GetOutGoingNeighbors('b');
            List<char> result3 = graph3.GetOutGoingNeighbors('c');

            List<char> expected1 = new List<char>() { 'b' };
            List<char> expected2 = new List<char>() { 'a' };
            List<char> expected3 = new List<char>() { 'b', 'd' };

            CollectionAssert.AreEqual(expected1, result1);
            CollectionAssert.AreEqual(expected2, result2);
            CollectionAssert.AreEqual(expected3, result3);
        }

        [Test]
        public void GetIncomingNeighborsTest()
        {
            UndirectedGraph<char> graph1 = new UndirectedGraph<char>();
            UndirectedGraph<char> graph2 = new UndirectedGraph<char>();
            UndirectedGraph<char> graph3 = new UndirectedGraph<char>();

            graph1.AddEdges(new char[,] { { 'a', 'b' } });
            graph2.AddEdges(new char[,] { { 'a', 'b' }, { 'b', 'a' } });
            graph3.AddEdges(new char[,] { { 'a', 'b' }, { 'b', 'c' }, { 'c', 'd' } });

            List<char> result1 = graph1.GetIncomingNeighbors('b');
            List<char> result2 = graph2.GetIncomingNeighbors('a');
            List<char> result3 = graph3.GetIncomingNeighbors('c');

            List<char> expected1 = new List<char>() { 'a' };
            List<char> expected2 = new List<char>() { 'b' };
            List<char> expected3 = new List<char>() { 'b', 'd' };

            CollectionAssert.AreEqual(expected1, result1);
            CollectionAssert.AreEqual(expected2, result2);
            CollectionAssert.AreEqual(expected3, result3);
        }

        [Test]
        public void HasEdgeTrueTest()
        {
            UndirectedGraph<char> graph1 = new UndirectedGraph<char>();
            UndirectedGraph<char> graph2 = new UndirectedGraph<char>();
            UndirectedGraph<char> graph3 = new UndirectedGraph<char>();

            graph1.AddEdges(new char[,] { { 'a', 'b' } });
            graph2.AddEdges(new char[,] { { 'a', 'b' }, { 'b', 'a' } });
            graph3.AddEdges(new char[,] { { 'a', 'b' }, { 'b', 'c' }, { 'c', 'd' } });

            bool result1 = graph1.HasEdge('a', 'b');
            bool result2 = graph2.HasEdge('b', 'a');
            bool result3 = graph3.HasEdge('c', 'd');

            Assert.Multiple(() =>
            {
                Assert.That(result1, Is.True);
                Assert.That(result2, Is.True);
                Assert.That(result3, Is.True);
            });
        }

        [Test]
        public void HasEdgeFalseTest()
        {
            UndirectedGraph<char> graph1 = new UndirectedGraph<char>();
            UndirectedGraph<char> graph2 = new UndirectedGraph<char>();
            UndirectedGraph<char> graph3 = new UndirectedGraph<char>();

            graph1.AddEdges(new char[,] { { 'a', 'b' } });
            graph2.AddEdges(new char[,] { { 'a', 'b' }, { 'b', 'a' } });
            graph3.AddEdges(new char[,] { { 'a', 'b' }, { 'b', 'c' }, { 'c', 'd' } });

            bool result1 = graph1.HasEdge('a', 'a');
            bool result2 = graph2.HasEdge('b', 'b');
            bool result3 = graph3.HasEdge('a', 'd');

            Assert.Multiple(() =>
            {
                Assert.That(result1, Is.False);
                Assert.That(result2, Is.False);
                Assert.That(result3, Is.False);
            });
        }

        [Test]
        public void RemoveEdgeTest()
        {
            UndirectedGraph<char> graph = new UndirectedGraph<char>();
            graph.AddEdges(new char[,] { { 'a', 'b' }, { 'b', 'c' }, { 'c', 'd' } });
            graph.RemoveEdge('b', 'c');
            Dictionary<char, List<char>> expected = new Dictionary<char, List<char>>()
            {
                { 'a', new List<char>() { 'b' } },
                { 'b', new List<char>() { 'a' } },
                { 'c', new List<char>() { 'b', 'd' } },
                { 'd', new List<char>() { 'c' } },
            };
            CollectionAssert.AreEqual(expected, graph.AdjacencyList);
        }

        [Test]
        public void RemoveNodeTest()
        {
            UndirectedGraph<char> graph = new UndirectedGraph<char>();
            graph.AddEdges(new char[,] { { 'a', 'b' }, { 'b', 'c' }, { 'c', 'd' } });
            graph.RemoveNode('b');
            Dictionary<char, List<char>> expected = new Dictionary<char, List<char>>()
            {
                { 'a', new List<char>() { } },
                { 'c', new List<char>() { 'd' } },
                { 'd', new List<char>() { 'c' } },
            };
            CollectionAssert.AreEqual(expected, graph.AdjacencyList);
        }

        private static Dictionary<char, List<char>>[] TestDictionaries()
        {
            Dictionary<char, List<char>>[] TestDict = new Dictionary<char, List<char>>[3]
            {
                new Dictionary<char, List<char>>
                {
                    {
                        'a', new List<char> { 'b' }
                    },
                    {
                        'b', new List<char> { 'a' }
                    }
                },
                new Dictionary<char, List<char>>
                {
                    {
                        'a', new List<char> { 'b' }
                    },
                    {
                        'b', new List<char> { 'a' }
                    },
                },
                new Dictionary<char, List<char>>
                {
                    {
                        'a', new List<char> { 'b' }
                    },
                    {
                        'b', new List<char> { 'a', 'c' }
                    },
                    {
                        'c', new List<char> { 'b','d' }
                    },
                    {
                        'd', new List<char> { 'c' }
                    }
                },
            };

            return TestDict;
        }
    }
}