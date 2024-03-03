using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
    [CreateAssetMenu(fileName = "Asset Root", menuName = "Assets/Asset Root")]
    public class AssetRoot : ScriptableObject {
        public List<LevelAsset> Levels;
    }
}