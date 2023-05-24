using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAlgorithmsTest
{
    [TestFixture]
    public class IslandCountGrid_Test
    {
        [Test]
        public void GridEmptyTest()
        {
            int result = Grid.IslandCountGrid(new char[,] { });
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
            int result = Grid.IslandCountGrid(grid);
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
            int result = Grid.IslandCountGrid(grid);
            Assert.That(result, Is.EqualTo(1));
        }
        [Test]
        public void MultiIslandsTest()
        {
            List<char[,]> grids = Grids();
            int result1 = Grid.IslandCountGrid(grids[0]);
            int result2 = Grid.IslandCountGrid(grids[1]);
            int result3 = Grid.IslandCountGrid(grids[2]);
            int result4 = Grid.IslandCountGrid(grids[3]);
            Assert.Multiple(() =>
            {
                Assert.That(result1, Is.EqualTo(1));
                Assert.That(result2, Is.EqualTo(4));
                Assert.That(result3, Is.EqualTo(7));
                Assert.That(result4, Is.EqualTo(3));
            });
        }

        private static List<char[,]> Grids()
        {
            List<char[,]> grids = new List<char[,]>
            {
                new char[,]
                {
                    { 'W', 'W', 'W', 'W', 'W', 'W' },
                    { 'W', 'W', 'W', 'W', 'W', 'W' },
                    { 'W', 'L', 'L', 'L', 'L', 'W' },
                    { 'W', 'L', 'W', 'W', 'L', 'W' },
                    { 'W', 'L', 'W', 'W', 'L', 'W' },
                    { 'W', 'L', 'W', 'W', 'L', 'W' },
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
            };
            return grids;
        }
    }
}
