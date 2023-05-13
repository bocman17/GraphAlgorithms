namespace GraphAlgorithmsTest
{
    [TestFixture]
    public class BFSTraverse_Test
    {
        [Test]
        public void DirectedTraverseNoLoopTest()
        {
            DirectedGraph<char> graph = new DirectedGraph<char>();
            graph.AddEdges(new char[,] { { 'a', 'b' }, { 'a', 'c' }, { 'b', 'd' }, { 'c', 'e' }, { 'd', 'f' } });

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            graph.BFSTraverseIterative('a');

            var consoleOutput = stringWriter.ToString();

            Assert.That(consoleOutput.Trim(), Is.EqualTo("a\r\nb\r\nc\r\nd\r\ne\r\nf"));
        }

        [Test]
        public void DirectedTraverseLoopTest()
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

            graph.BFSTraverseIterative('a');

            var consoleOutput = stringWriter.ToString();

            Assert.That(consoleOutput.Trim(), Is.EqualTo("a\r\nb\r\nc\r\nd\r\ne\r\nf"));
        }

        [Test]
        public void UndirectedTraverseNoLoopTest()
        {
            UndirectedGraph<char> graph = new UndirectedGraph<char>();
            graph.AddEdges(new char[,] { { 'a', 'b' }, { 'a', 'c' }, { 'b', 'd' }, { 'c', 'e' }, { 'd', 'f' } });

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            graph.BFSTraverseIterative('a');

            var consoleOutput = stringWriter.ToString();

            Assert.That(consoleOutput.Trim(), Is.EqualTo("a\r\nb\r\nc\r\nd\r\ne\r\nf"));
        }

        [Test]
        public void UndirectedTraverseLoopTest()
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

            graph.BFSTraverseIterative('a');

            var consoleOutput = stringWriter.ToString();

            Assert.That(consoleOutput.Trim(), Is.EqualTo("a\r\nb\r\nc\r\nd\r\ne\r\nf"));
        }
    }
}
