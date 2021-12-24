using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace TileLevelGeneration
{
    [CreateAssetMenu(fileName = "TileHeightmapData", menuName = "TileLevelGeneration/TileHeightmapData")]
    public class TileHeightmapData : ScriptableObject
    {
        [Tooltip("In order list of 2D tiles corresponding to height from min to max range")]
        public List<TileBase> heighmapTileList = new List<TileBase>();

        [Tooltip("Lowest hieght in Unity units")]
        public float minHieght;

        [Tooltip("Highest hieght in Unity units")]
        public float maxHieght;
    }
}

