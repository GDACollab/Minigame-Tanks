using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace TileLevelGeneration
{
    [CreateAssetMenu(fileName = "TileData", menuName = "TileLevelGeneration/TileData")]
    public class TileData : ScriptableObject
    {
        [Tooltip("2D tile of this TileData")]
        public TileBase tileBase;

        [Tooltip("GameObject to be spawned where this tileBase appears in the tilemap")]
        public GameObject toSpawn;
    }
}

