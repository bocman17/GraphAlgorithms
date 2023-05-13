namespace GraphAlgorithmsTest
{
    [TestFixture]
    public class DFSTraverse
    {
        [Test]
        public void DirectedTraverseIterativeNoLoopTest()
        {
            DirectedGraph<char> graph = new DirectedGraph<char>();
            graph.AddEdges(new char[,] { { 'a', 'b' }, { 'a', 'c' }, { 'b', 'd' }, { 'c', 'e' }, { 'd', 'f' } });

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            graph.DFSTraverseIterative('a');

            var consoleOutput = stringWriter.ToString();

            Assert.That(consoleOutput.Trim(), Is.EqualTo("a\r\nc\r\ne\r\nb\r\nd\r\nf"));
        }
        [Test]
        public void DirectedTraverseIterativeLoopTest()
        {
            DirectedGraph<char> graph = new DirectedGraph<char>();
            graph.AddEdges(new char[,] { 
                { 'a', 'b' }, 
                { 'a', 'c' }, 
                { 'b', 'd' },
                { 'b', 'a' },
                { 'c', 'b' },
                { 'c', 'e' }, 
                { 'd', 'f' } });

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            graph.DFSTraverseIterative('a');

            var consoleOutput = stringWriter.ToString();

            Assert.That(consoleOutput.Trim(), Is.EqualTo("a\r\nc\r\ne\r\nb\r\nd\r\nf"));
        }

        [Test]
        public void DirectedTraverseRecursiveNoLoopTest()
        {
            DirectedGraph<char> graph = new DirectedGraph<char>();
            graph.AddEdges(new char[,] { { 'a', 'b' }, { 'a', 'c' }, { 'b', 'd' }, { 'c', 'e' }, { 'd', 'f' } });

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            graph.DFSTraverseRecursive('a');

            var consoleOutput = stringWriter.ToString();

            Assert.That(consoleOutput.Trim(), Is.EqualTo("a\r\nb\r\nd\r\nf\r\nc\r\ne"));
        }

        [Test]
        public void DirectedTraverseRecursiveLoopTest()
        {
            DirectedGraph<char> graph = new DirectedGraph<char>();
            graph.AddEdges(new char[,] {
                { 'a', 'b' },
                { 'a', 'c' },
                { 'b', 'd' },
                { 'b', 'a' },
                { 'c', 'b' },
                { 'c', 'e' },
                { 'd', 'f' } });

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            graph.DFSTraverseRecursive('a');

            var consoleOutput = stringWriter.ToString();

            Assert.That(consoleOutput.Trim(), Is.EqualTo("a\r\nb\r\nd\r\nf\r\nc\r\ne"));
        }

        [Test]
        public void UndirectedTraverseIterativeNoLoopTest()
        {
            UndirectedGraph<char> graph = new UndirectedGraph<char>();
            graph.AddEdges(new char[,] { { 'a', 'b' }, { 'a', 'c' }, { 'b', 'd' }, { 'c', 'e' }, { 'd', 'f' } });

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            graph.DFSTraverseIterative('a');

            var consoleOutput = stringWriter.ToString();

            Assert.That(consoleOutput.Trim(), Is.EqualTo("a\r\nc\r\ne\r\nb\r\nd\r\nf"));
        }
        [Test]
        public void UndirectedTraverseIterativeLoopTest()
        {
            UndirectedGraph<char> graph = new UndirectedGraph<char>();
            graph.AddEdges(new char[,] {
                { 'a', 'b' },
                { 'a', 'c' },
                { 'b', 'd' },
                { 'c', 'b' },
                { 'c', 'e' },
                { 'd', 'f' } });

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            graph.DFSTraverseIterative('a');

            var consoleOutput = stringWriter.ToString();

            Assert.That(consoleOutput.Trim(), Is.EqualTo("a\r\nc\r\ne\r\nb\r\nd\r\nf"));
        }

        [Test]
        public void UndirectedTraverseRecursiveNoLoopTest()
        {
            UndirectedGraph<char> graph = new UndirectedGraph<char>();
            graph.AddEdges(new char[,] { { 'a', 'b' }, { 'a', 'c' }, { 'b', 'd' }, { 'c', 'e' }, { 'd', 'f' } });

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            graph.DFSTraverseRecursive('a');

            var consoleOutput = stringWriter.ToString();

            Assert.That(consoleOutput.Trim(), Is.EqualTo("a\r\nb\r\nd\r\nf\r\nc\r\ne"));
        }

        [Test]
        public void UndirectedTraverseRecursiveLoopTest()
        {
            UndirectedGraph<char> graph = new UndirectedGraph<char>();
            graph.AddEdges(new char[,] {
                { 'a', 'b' },
                { 'a', 'c' },
                { 'b', 'd' },
                { 'c', 'b' },
                { 'c', 'e' },
                { 'd', 'f' } });

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            graph.DFSTraverseRecursive('a');

            var consoleOutput = stringWriter.ToString();

            Assert.That(consoleOutput.Trim(), Is.EqualTo("a\r\nb\r\nd\r\nf\r\nc\r\ne"));
        }
    }
}
