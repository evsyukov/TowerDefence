using Enemy;
using UnityEngine;

namespace Assets
{
    [CreateAssetMenu(fileName = "Enemy Asset", menuName = "Assets/Enemy Asset")]
    public class EnemyAsset : ScriptableObject {

        public int StartHealth;
        public EnemyView ViewPrefab;
    }
}