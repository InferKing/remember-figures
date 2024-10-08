
namespace Model
{
    [System.Serializable]
    public class Session
    {
        public Session(DifficultyType difficulty)
        {
            Difficulty = difficulty;
        }

        public DifficultyType Difficulty { get; }
    }
}
