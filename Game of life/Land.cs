using Game_of_life.Behavior;
using Game_of_life.Models;
using System.Windows.Forms.Automation;

namespace Game_of_life
{
    public partial class Land : Form
    {
        //TODO: 
        //Create cells with index as name and color the alive ones
        //Copy the content of the alive cells HashSet, get next state, compare and change colors
        //Loop

        private const int SIZE = 20;
        private int nbCellsInRow;
        private int nbCellsInColumn;
        private Grid grid;

        public Land()
        {
            InitializeComponent();
            SetValues();
            grid = new Grid(nbCellsInRow, nbCellsInColumn);
        }

        private void SetValues()
        {
            nbCellsInColumn = pnlCellContainer.Size.Width / SIZE;
            nbCellsInRow = pnlCellContainer.Size.Height / SIZE;
        }

        private Panel[] CreateCells()
        {
            Panel cell;
            Size cellSize = new Size(SIZE, SIZE);
            Panel[] cells = new Panel[nbCellsInColumn * nbCellsInRow];
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
                    cells[row * nbCellsInColumn + column] = cell;

                    //Change position
                    x += SIZE;
                }
                x = 0;
                y += SIZE;
            }
            return cells;
        }

        private void Cell_Click(object? sender, EventArgs e)
        {
            Panel cell = (Panel)sender!;
            if (grid.currentlyAliveCells.Contains(int.Parse(cell.Name)))
            {
                Die(cell);
                grid.currentlyAliveCells.Remove(int.Parse(cell.Name));
            }
            else
            {
                Live(cell);
                grid.currentlyAliveCells.Add(int.Parse(cell.Name));
            }
        }

        private void Live(Panel cell)
        {
            cell.BackColor = Color.Black;
        }

        private void Die(Panel cell)
        {
            cell.BackColor = Color.White;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timerIteration.Start();
            btnPause.Enabled = true;
            btnPause.Visible = true;

            btnStart.Enabled = false;
            btnStart.Visible = false;
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            timerIteration.Stop();
            btnPause.Enabled = false;
            btnPause.Visible = false;

            btnStart.Enabled = true;
            btnStart.Visible = true;
        }

        //all cells die
        private void btnReset_Click(object sender, EventArgs e)
        {
            IEnumerable<Panel> aliveCells = pnlCellContainer.Controls.OfType<Panel>()
                                .Where(cell => grid.currentlyAliveCells.Contains(int.Parse(cell.Name)));

            foreach (Panel cell in aliveCells)
            {
                Die(cell);
            }

            grid.currentlyAliveCells.Clear();
        }

        //The apparition of all the panels is terribly long... Don't know how to shorten it
        private void Land_Load(object sender, EventArgs e)
        {
            Panel[] cells = CreateCells();
            pnlCellContainer.Controls.AddRange(cells);
        }

        private void timerIteration_Tick(object sender, EventArgs e)
        {
            //Preserve the previous state
            int[] previouslyAliveCells = new int[grid.currentlyAliveCells.Count];
            grid.currentlyAliveCells.CopyTo(previouslyAliveCells);

            //Get new state
            GridActions.GetNextIteration(grid);

            //Extract the cells that have to die and those who will become alive
            IEnumerable<int> newDeadCells = previouslyAliveCells.Where(cell => !grid.currentlyAliveCells.Contains(cell));
            IEnumerable<int> newAliveCells = grid.currentlyAliveCells.Where(cell => !previouslyAliveCells.Contains(cell));

            ChangeVisual(newDeadCells, newAliveCells);
        }

        private void ChangeVisual(IEnumerable<int> newDeadCells, IEnumerable<int> newAliveCells)
        {
            List<Panel> cellDeathRow = pnlCellContainer.Controls.OfType<Panel>().Where(panel => newDeadCells.Contains(int.Parse(panel.Name))).ToList();
            List<Panel> cellNursery = pnlCellContainer.Controls.OfType<Panel>().Where(panel => newAliveCells.Contains(int.Parse(panel.Name))).ToList();
            foreach (Panel cell in cellDeathRow)
            {
                Die(cell);
            }
            foreach (Panel cell in cellNursery)
            {
                Live(cell);
            }
        }
    }
}