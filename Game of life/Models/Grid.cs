namespace Game_of_life.Models
{
    public class Grid
    {
        public int ROWS;
        public int COLUMNS;

        public HashSet<int> currentlyAliveCells = new(); //list of the index of alive cells

        public Grid(InitialState initialState)
        {
            ROWS = InitialState.ROWS;
            COLUMNS = InitialState.COLUMNS;
            FillGrid(initialState.initialGrid);
        }

        //Creates all Cells
        //Fills the currentlyAliveCells list
        private void FillGrid(bool[] initialGrid)
        {
            for(int i = 0; i < ROWS*COLUMNS; i++)
            {
                if (initialGrid[i])
                    currentlyAliveCells.Add(i);
            }
        }
    }
}
