
namespace Model
{
    [System.Serializable]
    public class Session
    {
        public DifficultyType difficulty;

        public Session(DifficultyType difficulty)
        {
            this.difficulty = difficulty;
        }
    }
}
