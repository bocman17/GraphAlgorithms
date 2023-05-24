using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAlgorithmsTest
{
    [TestFixture]
    public class MinIslandSizeGrid_Test
    {

        [Test]
        public void GridEmptyTest()
        {
            int result = Grid.MinIslandSizeGrid(new char[,] { });
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void AllWaterTest()
        {
            char[,] grid = new char[,]
            {
                {'W', 'W', 'W', 'W', 'W' },
                {'W', 'W', 'W', 'W', 'W' },
                {'W', 'W', 'W', 'W', 'W' },
                {'W', 'W', 'W', 'W', 'W' },
                {'W', 'W', 'W', 'W', 'W' },
                {'W', 'W', 'W', 'W', 'W' },
            };
            int result = Grid.MinIslandSizeGrid(grid);
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void AllLandTest()
        {
            char[,] grid = new char[,]
            {
                {'L', 'L', 'L', 'L', 'L' },
                {'L', 'L', 'L', 'L', 'L' },
                {'L', 'L', 'L', 'L', 'L' },
                {'L', 'L', 'L', 'L', 'L' },
                {'L', 'L', 'L', 'L', 'L' },
                {'L', 'L', 'L', 'L', 'L' },
            };
            int result = Grid.MinIslandSizeGrid(grid);
            Assert.That(result, Is.EqualTo(30));
        }

        [Test]
        public void MultiIslandsTest()
        {
            List<char[,]> grids = Grids();
            int result1 = Grid.MinIslandSizeGrid(grids[0]);
            int result2 = Grid.MinIslandSizeGrid(grids[1]);
            int result3 = Grid.MinIslandSizeGrid(grids[2]);
            int result4 = Grid.MinIslandSizeGrid(grids[3]);
            int result5 = Grid.MinIslandSizeGrid(grids[4]);

            Assert.Multiple(() =>
            {
                Assert.That(result1, Is.EqualTo(1));
                Assert.That(result2, Is.EqualTo(1));
                Assert.That(result3, Is.EqualTo(1));
                Assert.That(result4, Is.EqualTo(2));
                Assert.That(result5, Is.EqualTo(7));
            });
        }

        private static List<char[,]> Grids()
        {
            List<char[,]> grids = new List<char[,]>()
            {
                new char[,]
                {
                    { 'L', 'W', 'L', 'L', 'L', 'L' },
                    { 'L', 'L', 'W', 'W', 'W', 'W' },
                    { 'W', 'W', 'L', 'L', 'L', 'W' },
                    { 'W', 'L', 'W', 'W', 'L', 'W' },
                    { 'W', 'L', 'W', 'L', 'L', 'W' },
                    { 'L', 'L', 'W', 'W', 'W', 'L' },
                },
                new char[,]
                {
                    { 'L', 'W', 'W', 'L' },
                    { 'W', 'W', 'W', 'W' },
                    { 'W', 'W', 'W', 'W' },
                    { 'L', 'W', 'W', 'L' },
                },
                new char[,]
                {
                    { 'L', 'W', 'W', 'L' },
                    { 'W', 'W', 'L', 'W' },
                    { 'W', 'L', 'W', 'W' },
                    { 'W', 'W', 'L', 'W' },
                    { 'L', 'W', 'W', 'L' },
                },
                new char[,]
                {
                    { 'W', 'L', 'L', 'W', 'W', 'W' },
                    { 'W', 'W', 'W', 'W', 'W', 'W' },
                    { 'W', 'W', 'L', 'L', 'W', 'W' },
                    { 'W', 'W', 'W', 'L', 'L', 'W' },
                    { 'L', 'W', 'W', 'W', 'W', 'W' },
                    { 'L', 'L', 'W', 'W', 'W', 'W' },
                },
                new char[,]
                {
                    { 'W', 'L', 'L', 'W', 'W', 'W' },
                    { 'W', 'W', 'L', 'W', 'W', 'W' },
                    { 'W', 'W', 'L', 'L', 'W', 'W' },
                    { 'L', 'W', 'W', 'L', 'L', 'L' },
                    { 'L', 'W', 'W', 'W', 'W', 'W' },
                    { 'L', 'L', 'W', 'W', 'W', 'W' },
                    { 'L', 'L', 'L', 'W', 'W', 'W' },
                },
            };
            return grids;
        }
    }
}
