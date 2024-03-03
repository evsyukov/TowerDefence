using UnityEngine;

namespace Assets
{
    [CreateAssetMenu(fileName = "Spawn Waves Asset", menuName = "Assets/Spawn Waves Asset")]
    public class SpawnWavesAsset : ScriptableObject {
        public EnemyAsset EnemyAsset;
        public int Count;
        public float TimeBetweenSpawns;
    }
}