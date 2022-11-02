using UnityEngine;

namespace Enemy
{
    public class ChangeDifficultyLevel : MonoBehaviour
    {
        [SerializeField] private DifficultyLevelData _difficultyLevel;
        private void Awake()
        {
            _difficultyLevel.DificultyLevel = 0;
        }

        public void ChangeDifficulty()
        {
            _difficultyLevel.DificultyLevel -= 1;
        }
    }
}