using Game_of_life.Behavior;
using Game_of_life.Models;
using System.ComponentModel;

namespace MaybeIAmTheProblem
{
    [TestFixture]
    public class Tests
    {
        private Grid grid;
        [SetUp]
        public void Setup()
        {
            grid = new Grid(new InitialState());
        }

        [Test]
        public void NeighbourCount()
        {
            List<int> testIndex = new List<int>() { 0, 44, 5 };
            List<int> expectedResults = new List<int>() { 3, 8, 0 };
            int result;

            for (int i = 0; i < testIndex.Count; i++)
            {
                result = GridActions.AliveNeighboursCount(grid, testIndex[i]);
                Assert.That(result, Is.EqualTo(expectedResults[i]));
            }
        }

        [Test]
        public void GetNextIteration()
        {
            HashSet<int> expectedResult = new() { 0, 1, 9, 24, 33, 35, 42, 46, 53, 55, 64, 80, 90, 91, 99 };

            GridActions.GetNextIteration(grid);

            Assert.That(grid.currentlyAliveCells, Is.EquivalentTo(expectedResult));

        }
    }
}