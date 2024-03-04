using UnityEngine;

namespace EnemySpawn
{
    [CreateAssetMenu(fileName = "Spawn Waves Asset", menuName = "Assets/Spawn Waves Asset")]
    public class SpawnWavesAsset : ScriptableObject {
        public SpawnWave[] SpawnWaves;
    }
}