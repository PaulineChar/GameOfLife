namespace Game_of_life.Models
{
    public class InitialState
    {
        public const int ROWS = 10;
        public const int COLUMNS = 10;

        public bool[] initialGrid = new bool[ROWS * COLUMNS]
        {
            true , false, false, false, false, false, false, false, false, false, 
            false, false, false, false, false, false, false, false, false, false, 
            false, false, false, false, false, false, false, false, false, false, 
            false, false, false, true , true , true , false, false, false, false, 
            false, false, false, true , true , true , false, false, false, false, 
            false, false, false, true , true , true , false, false, false, false, 
            false, false, false, false, false, false, false, false, false, false, 
            false, false, false, false, false, false, false, false, false, false, 
            false, false, false, false, false, false, false, false, false, false, 
            true , true , false, false, false, false, false, false, false, true
        };

        public InitialState()
        {

        }
    }
}
