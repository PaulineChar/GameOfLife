namespace Game_of_life.Models
{
    [Obsolete]
    public class Cell
    {
        public bool isAlive { get; set; }

        public Cell(bool isAlive) 
        {
            this.isAlive = isAlive;
        }


    }
}
