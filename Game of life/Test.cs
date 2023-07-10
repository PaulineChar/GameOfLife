using Game_of_life.Behavior;
using Game_of_life.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_of_life
{
    internal class Test
    {
        public static void RunAllTests()
        {
            Grid grid = new Grid(new InitialState());
            System.Diagnostics.Debug.WriteLine("Neighbour count:");
            TestNeighbourCount(grid);
            System.Diagnostics.Debug.WriteLine("\nGet next iteration:");
            TestGetNextIteration(grid);
        }
        private static void TestNeighbourCount(Grid grid)
        {
            List<int> testIndex = new List<int>() { 0, 44 , 5 };
            List<int> expectedResults = new List<int>() { 3 , 8, 0 };
            int result;

            for(int i = 0; i < testIndex.Count; i++)
            {
                result = GridActions.AliveNeighboursCount(grid, testIndex[i]);
                if(result == expectedResults[i])
                {
                    System.Diagnostics.Debug.WriteLine("Passed");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"Failed: expected {expectedResults[i]}, received {result}");
                }
            }
        }

        private static void TestGetNextIteration(Grid grid)
        {

            HashSet<int> expectedResult = new() { 0, 1, 9, 24, 33, 35, 42, 46, 53, 55, 64, 80, 90, 91, 99 };

            GridActions.GetNextIteration(grid);

            if(expectedResult.Count == grid.currentlyAliveCells.Count 
                && expectedResult.SetEquals(grid.currentlyAliveCells))
            {
                System.Diagnostics.Debug.WriteLine("Passed");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Failed:");
                System.Diagnostics.Debug.Write("expected: ");
                PrintHashSet(expectedResult);
                System.Diagnostics.Debug.Write("gotten: ");
                PrintHashSet(grid.currentlyAliveCells);
            }
        }

        private static void PrintHashSet(HashSet<int> currentlyAliveCells)
        {
            System.Diagnostics.Debug.Write("[ ");
            foreach(int cell in currentlyAliveCells)
            {
                System.Diagnostics.Debug.Write($"{cell} ");
            }
            System.Diagnostics.Debug.WriteLine("]");
        }
    }
}
