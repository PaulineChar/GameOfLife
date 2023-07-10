namespace Game_of_life.Models
{
    public class Cell
    {
        public bool isAlive { get; set; }

        public Cell(bool isAlive) 
        {
            this.isAlive = isAlive;
        }


    }
}
