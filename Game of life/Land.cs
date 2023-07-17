using Game_of_life.Models;

namespace Game_of_life
{
    public partial class Land : Form
    {
        //TODO: 
        //Create cells with index as name and color the alive ones
        //Copy the content of the alive cells HashSet, get next state, compare and change colors
        //Loop

        private const int SIZE = 15;
        private int nbCellsInRow;
        private int nbCellsInColumn;
        private Grid grid;

        public Land()
        {
            InitializeComponent();
            grid = new Grid(nbCellsInRow, nbCellsInColumn);
            SetValues();
        }

        private void SetValues()
        {
            nbCellsInColumn = pnlCellContainer.Size.Width / SIZE;
            nbCellsInRow = pnlCellContainer.Size.Height / SIZE;
        }

        private void CreateCells()
        {
            Panel cell;
            Size cellSize = new Size(SIZE, SIZE);
            //determine the coordinates of each panel
            int x = 0;
            int y = 0;
            for (int row = 0; row < nbCellsInRow; row++)
            {
                for (int column = 0; column < nbCellsInColumn; column++)
                {
                    //Its name is its index in the grid
                    cell = new Panel()
                    {
                        Name = (row * nbCellsInColumn + column).ToString(),
                        BorderStyle = BorderStyle.FixedSingle,
                        Location = new Point(x, y),
                        Size = cellSize
                    };
                    cell.Click += Cell_Click;
                    pnlCellContainer.Controls.Add(cell);

                    //Change position
                    x += SIZE;
                }
                x = 0;
                y += SIZE;
            }
        }

        private void Cell_Click(object? sender, EventArgs e)
        {
            Panel cell = (Panel)sender!;
            if (grid.currentlyAliveCells.Contains(int.Parse(cell.Name)))
            {
                cell.BackColor = Color.White;
                grid.currentlyAliveCells.Remove(int.Parse(cell.Name));
            }
            else
            {
                cell.BackColor = Color.Black;
                grid.currentlyAliveCells.Add(int.Parse(cell.Name));
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

        }

        private void btnPause_Click(object sender, EventArgs e)
        {

        }

        //all cells die
        private void btnReset_Click(object sender, EventArgs e)
        {
            
        }

        private void Land_Load(object sender, EventArgs e)
        {
            CreateCells();
        }
    }
}