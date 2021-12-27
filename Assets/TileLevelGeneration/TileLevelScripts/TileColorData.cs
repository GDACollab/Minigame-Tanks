using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace TileLevelGeneration
{
    [CreateAssetMenu(fileName = "TileColorData", menuName = "TileLevelGeneration/TileColorData")]
    public class TileColorData : ScriptableObject
    {
        [Tooltip("2D tile of this TileColorData")]
        public TileBase tileBase;

        [Tooltip("Color associated with this tile")]
        public Color objectColor;
    }
}

