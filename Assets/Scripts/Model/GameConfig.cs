using UnityEngine;

namespace Model
{
    [CreateAssetMenu(fileName = "Game settings", menuName = "Config/Game settings")]
    public class GameConfig : ScriptableObject
    {
        [field: SerializeField]
        public int Rows { get; private set; }
        [field: SerializeField]
        public int Columns { get; private set; }
        [field: SerializeField]
        public float TimeBeforeHide { get; private set; }
        [field: SerializeField]
        public DifficultyType Difficulty { get; private set; }
    }
}
