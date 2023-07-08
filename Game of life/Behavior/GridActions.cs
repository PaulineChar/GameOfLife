using Game_of_life.Models;

namespace Game_of_life.Behavior
{
    internal class GridActions
    {
        //TODO
        public static int AliveNeighboursCount(Grid grid, int targetCellIndex)
        {
            int targetRow = targetCellIndex / grid.COLUMNS;
            int targetColumn = targetCellIndex % grid.COLUMNS;

            int aliveNeighbours = 0;

            //I don't know how to do it otherwise
            //The grid is warped
            //Next to it
            aliveNeighbours += AddNeighbourValue(grid, DeterminePosition(
                grid.COLUMNS, targetCellIndex, targetRow, 1));
            aliveNeighbours += AddNeighbourValue(grid, DeterminePosition(
                grid.COLUMNS, targetCellIndex, targetRow, -1));

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
            int row = DeterminePosition(columns, targetCellIndex,
                targetRow, verticalOffset);
            int column = DeterminePosition(rows, targetCellIndex,
                targetColumn, horitontalOffset);

            //index
            return row * columns + column;
        }

        /*
            Returns the position of a cell with a certain offset, either its
            column or row
            @param:
            maxValue: total number of rows of columns
            targetCellIndex: the position of the cell from which the position 
                    is calculated
            targetRow: row or column of the cell from which the position is
                    calculated
            offset: can be -1 (left or above), 0 or 1 (right or under)
         */
        private static int DeterminePosition(int maxValue, int targetCellIndex,
            int targetRowCol, int offset)
        {
            return (targetCellIndex % maxValue + offset + maxValue)
                % maxValue + targetRowCol * maxValue;
        }

        private static int AddNeighbourValue(Grid grid, int index)
        {
            return grid.currentGrid[index].isAlive ? 1 : 0;
        }

        //TODO
        public static void GetNextState(Grid grid)
        {
            
        }
    }
}
