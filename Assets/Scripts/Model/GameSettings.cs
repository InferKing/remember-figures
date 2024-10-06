using UnityEngine;

namespace Model
{
    [CreateAssetMenu(fileName = "Game settings", menuName = "Config/Game settings")]
    public class GameSettings : ScriptableObject
    {
        [field: SerializeField]
        public DifficultyType Difficulty { get; private set; }
        [field: SerializeField]
        public int Rows { get; private set; }
        [field: SerializeField]
        public int Columns { get; private set; }
    }
}
