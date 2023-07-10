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
        public static void TestNeighbourCount()
        {
            Grid grid = new Grid(new InitialState());

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
    }
}
