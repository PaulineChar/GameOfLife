namespace Game_of_life.Models
{
    internal class Grid
    {
        public int ROWS;
        public int COLUMNS;

        public Cell[] currentGrid;
        public List<int> currentlyAliveCells = new(); //list of the index of alive cells

        public Grid(InitialState initialState)
        {
            ROWS = InitialState.ROWS;
            COLUMNS = InitialState.COLUMNS;
            FillGrid(initialState.initialGrid);
        }

        //Creates all Cells
        //Fills the currentGrid array
        //Fills the currentlyAliveCells list
        private void FillGrid(bool[] initialGrid)
        {
            currentGrid = new Cell[ROWS*COLUMNS];

            for(int i = 0; i < ROWS*COLUMNS; i++)
            {
                currentGrid[i] = new Cell(initialGrid[i]);

                if (initialGrid[i])
                    currentlyAliveCells.Add(i);
            }
        }
    }
}
