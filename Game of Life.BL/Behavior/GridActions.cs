using Game_of_life.Models;
using System.Data.Common;

namespace Game_of_life.Behavior
{
    public class GridActions
    {
        //TODO
        public static int AliveNeighboursCount(Grid grid, int targetCellIndex)
        {
            int targetRow = targetCellIndex / grid.COLUMNS;
            int targetColumn = targetCellIndex % grid.COLUMNS;

            int aliveNeighbours = 0;

            /*//I don't know how to do it otherwise
            //The grid is warped
            //Next to it
            aliveNeighbours += AddNeighbourValue(grid, 
                DeterminePosition(grid.COLUMNS, targetCellIndex, targetRow,
                1) + grid.COLUMNS * targetRow);
            aliveNeighbours += AddNeighbourValue(grid, 
                DeterminePosition(grid.COLUMNS, targetCellIndex, targetRow,
                -1) + grid.COLUMNS * targetRow);

            //The line above
            for(int horizontalOffset = -1; horizontalOffset <= 1; horizontalOffset++)
            {
                aliveNeighbours += AddNeighbourValue(grid,
                DetermineAndCombinePositions(grid.COLUMNS, grid.ROWS,
                    targetCellIndex, targetRow, targetColumn, -1,
                    horizontalOffset));
            }

            //The line under
            for (int horizontalOffset = -1; horizontalOffset <= 1; horizontalOffset++)
            {
                aliveNeighbours += AddNeighbourValue(grid,
                DetermineAndCombinePositions(grid.COLUMNS, grid.ROWS,
                    targetCellIndex, targetRow, targetColumn, 1,
                    horizontalOffset));
            }*/

            for (int verticalOffset = -1; verticalOffset <= 1; verticalOffset++)
            {
                for (int horizontalOffset = -1; horizontalOffset <= 1; horizontalOffset++)
                {
                    //current cell
                    if (verticalOffset == 0 && horizontalOffset == 0)
                        continue;

                    aliveNeighbours += AddNeighbourValue(grid, 
                        DetermineAndCombinePositions(grid.COLUMNS, grid.ROWS, targetCellIndex,
                        targetRow, targetColumn, verticalOffset, horizontalOffset));
                }
            }

            return aliveNeighbours;
        }

        /*
         * When looking at the row above or under the target cell, we must
         * look at the vertical and horizontal position to work out the index
         * of the cell we want to find
         */
        private static int DetermineAndCombinePositions(int columns, int rows,
            int targetCellIndex, int targetRow, int targetColumn,
            int verticalOffset, int horitontalOffset)
        {
            int row = DeterminePosition(rows, targetCellIndex,
                targetRow, verticalOffset);
            int column = DeterminePosition(columns, targetCellIndex,
                targetColumn, horitontalOffset);

            //index
            return row * columns + column;
        }

        /// <summary>
        /// Returns the position of a cell with a certain offset, either its 
        /// column or row
        /// </summary>
        /// <param name="maxValue">total number of rows of columns</param>
        /// <param name="targetCellIndex"> the position of the cell from
        /// which the position is calculated
        /// <param name="targetRowCol">row or column of the cell from which
        /// the position is calculated></param>
        /// <param name="offset">can be -1 (left or above),
        /// 0 or 1 (right or under)</param>
        /// <returns></returns>
        private static int DeterminePosition(int maxValue, int targetCellIndex,
            int targetRowCol, int offset)
        {
            return (targetRowCol + offset + maxValue)
                % maxValue;
        }

        private static int AddNeighbourValue(Grid grid, int index)
        {
            return grid.currentlyAliveCells.Contains(index) ? 1 : 0;
        }

        /// <summary>
        /// Updates the currently alive cells and the current grid
        /// </summary>
        /// <param name="grid"></param>
        public static void GetNextIteration(Grid grid)
        {
            //cells alive in the next iteration
            HashSet<int> nextAliveCells = new();

            //Go through the alive list and get the number of neighbours of each
            AddNextAliveCells(grid, grid.currentlyAliveCells, nextAliveCells, true);

            //Go through the dead cells around the currently alive ones to find those who will become alive
            HashSet<int> deadCells = FindInterstingDeadCells(grid);
            AddNextAliveCells(grid, deadCells, nextAliveCells, false);

            //Remplace the old HashSet
            grid.currentlyAliveCells = nextAliveCells;
        }

        
        private static void AddNextAliveCells(Grid grid, HashSet<int> targetSet, HashSet<int> nextAliveCells, bool isAlive)
        {
            int neighbours;
            foreach (int aliveCellIndex in targetSet)
            {
                neighbours = AliveNeighboursCount(grid, aliveCellIndex);
                if (neighbours == 3 || (isAlive && neighbours == 2))
                    nextAliveCells.Add(aliveCellIndex);
            }
        }



        /// <summary>
        /// Returns a hashSet of the indexes of dead cells around the alive ones
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        private static HashSet<int> FindInterstingDeadCells(Grid grid)
        {
            HashSet<int> deadCells = new();

            foreach(int cellIndex in grid.currentlyAliveCells)
            {
                int targetRow = cellIndex / grid.COLUMNS;
                int targetColumn = cellIndex % grid.COLUMNS;

                for(int verticalOffset = -1; verticalOffset <= 1; verticalOffset++)
                {
                    for(int horizontalOffset = -1; horizontalOffset <= 1; horizontalOffset++)
                    {
                        //current cell
                        if (verticalOffset == 0 && horizontalOffset == 0)
                            continue;

                        deadCells.Add(DetermineAndCombinePositions(grid.COLUMNS, grid.ROWS, cellIndex,
                            targetRow, targetColumn, verticalOffset, horizontalOffset));
                    }
                }
            }

            return deadCells;
        }
    }
}
