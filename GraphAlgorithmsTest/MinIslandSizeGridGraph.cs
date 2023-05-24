using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAlgorithmsTest
{
    [TestFixture]
    public class MinIslandSizeGridGraph
    {
        [Test]
        public void GridEmptyTest()
        {
            GridGraph<char> grid = new GridGraph<char>();
            int result = Grid.MinIslandSizeGridGraph(grid);
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
            int result = Grid.MinIslandSizeGridGraph(gridGraph);
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
            int result = Grid.MinIslandSizeGridGraph(gridGraph);
            Assert.That(result, Is.EqualTo(30));
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
            GridGraph<char> gridGraph5 = new GridGraph<char>();
            gridGraph5.AddGrid(grids[4]);

            int result1 = Grid.MinIslandSizeGridGraph(gridGraph1);
            int result2 = Grid.MinIslandSizeGridGraph(gridGraph2);
            int result3 = Grid.MinIslandSizeGridGraph(gridGraph3);
            int result4 = Grid.MinIslandSizeGridGraph(gridGraph4);
            int result5 = Grid.MinIslandSizeGridGraph(gridGraph5);
            Assert.Multiple(() =>
            {
                Assert.That(result1, Is.EqualTo(1));
                Assert.That(result2, Is.EqualTo(1));
                Assert.That(result3, Is.EqualTo(1));
                Assert.That(result4, Is.EqualTo(2));
                Assert.That(result5, Is.EqualTo(7));
            });
        }

        private static List<Node<char>[,]> NodeGrids()
        {
            List<Node<char>[,]> nodeGrids = new List<Node<char>[,]>
            {
                new Node<char>[,]
                {
                    {
                        new Node<char>('L'), new Node<char>('W'), new Node<char>('L'), new Node<char>('L'), new Node<char>('L'), new Node<char>('L'),
                    },
                    {
                        new Node<char>('L'), new Node<char>('L'), new Node<char>('W'), new Node<char>('W'), new Node<char>('W'), new Node<char>('W'),
                    },
                    {
                        new Node<char>('W'), new Node<char>('W'), new Node<char>('L'), new Node<char>('L'), new Node<char>('L'), new Node<char>('W'),
                    },
                    {
                        new Node<char>('W'), new Node<char>('L'), new Node<char>('W'), new Node<char>('W'), new Node<char>('L'), new Node<char>('W'),
                    },
                    {
                        new Node<char>('W'), new Node<char>('L'), new Node<char>('W'), new Node<char>('L'), new Node<char>('L'), new Node<char>('W'),
                    },
                    {
                        new Node<char>('L'), new Node<char>('L'), new Node<char>('W'), new Node<char>('W'), new Node<char>('W'), new Node<char>('L'),
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
                        new Node<char>('W'), new Node<char>('L'), new Node<char>('L'), new Node<char>('W'), new Node<char>('W'), new Node<char>('W'),
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
                new Node<char>[,]
                {
                    {
                        new Node<char>('W'), new Node<char>('L'), new Node<char>('L'), new Node<char>('W'), new Node<char>('W'), new Node<char>('W'),
                    },
                    {
                        new Node<char>('W'), new Node<char>('W'), new Node<char>('L'), new Node<char>('W'), new Node<char>('W'), new Node<char>('W'),
                    },
                    {
                        new Node<char>('W'), new Node<char>('W'), new Node<char>('L'), new Node<char>('L'), new Node<char>('W'), new Node<char>('W'),
                    },
                    {
                        new Node<char>('L'), new Node<char>('W'), new Node<char>('W'), new Node<char>('L'), new Node<char>('L'), new Node<char>('L'),
                    },
                    {
                        new Node<char>('L'), new Node<char>('W'), new Node<char>('W'), new Node<char>('W'), new Node<char>('W'), new Node<char>('W'),
                    },
                    {
                        new Node<char>('L'), new Node<char>('L'), new Node<char>('W'), new Node<char>('W'), new Node<char>('W'), new Node<char>('W'),
                    },
                    {
                        new Node<char>('L'), new Node<char>('L'), new Node<char>('L'), new Node<char>('W'), new Node<char>('W'), new Node<char>('W'),
                    }
                },
            };
            return nodeGrids;
        }
    }
}
