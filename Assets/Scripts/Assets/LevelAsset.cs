using EnemySpawn;
using UnityEditor;
using UnityEngine;

namespace Assets
{
    [CreateAssetMenu(fileName = "Level Asset", menuName = "Assets/Level Asset")]
    public class LevelAsset : ScriptableObject {
        public SceneAsset SceneAsset;
        public SpawnWavesAsset SpawnWavesAsset;
        
    }
}