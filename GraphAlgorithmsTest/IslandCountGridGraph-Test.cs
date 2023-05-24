namespace GraphAlgorithmsTest
{
    [TestFixture]
    public class IslandCountGridGraph_Test
    {
        [Test]
        public void GridEmptyTest()
        {
            GridGraph<char> grid = new GridGraph<char>();
            int result = Grid.IslandCountGridGraph(grid);
            Assert.That(result, Is.EqualTo(0));
        }
        [Test]
        public void AllWaterTest()
        {
            GridGraph<char> gridGraph = new GridGraph<char>();
            char[,] grid = new char[,]
            {
                {'W', 'W', 'W', 'W', 'W' },
                {'W', 'W', 'W', 'W', 'W' },
                {'W', 'W', 'W', 'W', 'W' },
                {'W', 'W', 'W', 'W', 'W' },
                {'W', 'W', 'W', 'W', 'W' },
                {'W', 'W', 'W', 'W', 'W' },
            };
            gridGraph.AddGrid(Node<char>.MakeNodeGrid(grid));
            int result = Grid.IslandCountGridGraph(gridGraph);
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void AllLandTest()
        {
            GridGraph<char> gridGraph = new GridGraph<char>();
            char[,] grid = new char[,]
            {
                {'L', 'L', 'L', 'L', 'L' },
                {'L', 'L', 'L', 'L', 'L' },
                {'L', 'L', 'L', 'L', 'L' },
                {'L', 'L', 'L', 'L', 'L' },
                {'L', 'L', 'L', 'L', 'L' },
                {'L', 'L', 'L', 'L', 'L' },
            };
            gridGraph.AddGrid(Node<char>.MakeNodeGrid(grid));
            int result = Grid.IslandCountGridGraph(gridGraph);
            Assert.That(result, Is.EqualTo(1));
        }
        [Test]
        public void MultiIslandsTest()
        {
            List<Node<char>[,]> grids = NodeGrids();
            GridGraph<char> gridGraph1 = new GridGraph<char>();
            gridGraph1.AddGrid(grids[0]);
            GridGraph<char> gridGraph2 = new GridGraph<char>();
            gridGraph2.AddGrid(grids[1]);
            GridGraph<char> gridGraph3 = new GridGraph<char>();
            gridGraph3.AddGrid(grids[2]);
            GridGraph<char> gridGraph4 = new GridGraph<char>();
            gridGraph4.AddGrid(grids[3]);

            int result1 = Grid.IslandCountGridGraph(gridGraph1);
            int result2 = Grid.IslandCountGridGraph(gridGraph2);
            int result3 = Grid.IslandCountGridGraph(gridGraph3);
            int result4 = Grid.IslandCountGridGraph(gridGraph4);
            Assert.Multiple(() =>
            {
                Assert.That(result1, Is.EqualTo(1));
                Assert.That(result2, Is.EqualTo(4));
                Assert.That(result3, Is.EqualTo(7));
                Assert.That(result4, Is.EqualTo(3));
            });
        }

        private static List<Node<char>[,]> NodeGrids()
        {
            List<Node<char>[,]> nodeGrids = new List<Node<char>[,]>
            {
                new Node<char>[,]
                {
                    {
                        new Node<char>('W'), new Node<char>('W'), new Node<char>('W'), new Node<char>('W'), new Node<char>('W'), new Node<char>('W'),
                    },
                    {
                        new Node<char>('W'), new Node<char>('W'), new Node<char>('W'), new Node<char>('W'), new Node<char>('W'), new Node<char>('W'),
                    },
                    {
                        new Node<char>('W'), new Node<char>('L'), new Node<char>('L'), new Node<char>('L'), new Node<char>('L'), new Node<char>('W'),
                    },
                    {
                        new Node<char>('W'), new Node<char>('L'), new Node<char>('W'), new Node<char>('W'), new Node<char>('L'), new Node<char>('W'),
                    },
                    {
                        new Node<char>('W'), new Node<char>('L'), new Node<char>('W'), new Node<char>('W'), new Node<char>('L'), new Node<char>('W'),
                    },
                    {
                        new Node<char>('W'), new Node<char>('L'), new Node<char>('W'), new Node<char>('W'), new Node<char>('L'), new Node<char>('W'),
                    }
                },
               new Node<char>[,]
                {
                    {
                        new Node<char>('L'), new Node<char>('W'), new Node<char>('W'), new Node<char>('L'),
                    },
                    {
                        new Node<char>('W'), new Node<char>('W'), new Node<char>('W'), new Node<char>('W'),
                    },
                    {
                        new Node<char>('W'), new Node<char>('W'), new Node<char>('W'), new Node<char>('W'),
                    },
                    {
                        new Node<char>('L'), new Node<char>('W'), new Node<char>('W'), new Node<char>('L'),
                    },
                },
               new Node<char>[,]
                {
                    {
                        new Node<char>('L'), new Node<char>('W'), new Node<char>('W'), new Node<char>('L'),
                    },
                    {
                        new Node<char>('W'), new Node<char>('W'), new Node<char>('L'), new Node<char>('W'),
                    },
                    {
                        new Node<char>('W'), new Node<char>('L'), new Node<char>('W'), new Node<char>('W'),
                    },
                    {
                        new Node<char>('W'), new Node<char>('W'), new Node<char>('L'), new Node<char>('W'),
                    },
                    {
                        new Node<char>('L'), new Node<char>('W'), new Node<char>('W'), new Node<char>('L'),
                    },
                },
                new Node<char>[,]
                {
                    {
                        new Node<char>('W'), new Node<char>('L'), new Node<char>('L'), new Node<char>('L'), new Node<char>('W'), new Node<char>('W'),
                    },
                    {
                        new Node<char>('W'), new Node<char>('W'), new Node<char>('W'), new Node<char>('W'), new Node<char>('W'), new Node<char>('W'),
                    },
                    {
                        new Node<char>('W'), new Node<char>('W'), new Node<char>('L'), new Node<char>('L'), new Node<char>('W'), new Node<char>('W'),
                    },
                    {
                        new Node<char>('W'), new Node<char>('W'), new Node<char>('W'), new Node<char>('L'), new Node<char>('L'), new Node<char>('W'),
                    },
                    {
                        new Node<char>('L'), new Node<char>('W'), new Node<char>('W'), new Node<char>('W'), new Node<char>('W'), new Node<char>('W'),
                    },
                    {
                        new Node<char>('L'), new Node<char>('L'), new Node<char>('W'), new Node<char>('W'), new Node<char>('W'), new Node<char>('W'),
                    }
                },
            };
            return nodeGrids;
        }
    }
}
