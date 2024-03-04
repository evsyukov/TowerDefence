using System;
using Assets;

namespace EnemySpawn
{
    [Serializable]
    public class SpawnWave {
        public EnemyAsset EnemyAsset;
        public int Count;
        public float TimeBetweenSpawns;
        public float TimeBeforeStartWave;
    }
}