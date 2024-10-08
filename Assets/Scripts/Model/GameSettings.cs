using UnityEngine;

namespace Model
{
    [CreateAssetMenu(fileName = "Game settings", menuName = "Config/Game settings")]
    public class GameSettings : ScriptableObject
    {
        [field: SerializeField]
        public byte Rows { get; private set; }
        [field: SerializeField]
        public byte Columns { get; private set; }
        [field: SerializeField]
        public float TimeBeforeHide { get; private set; }
        [field: SerializeField]
        public DifficultyType Difficulty { get; private set; }
    }
}
