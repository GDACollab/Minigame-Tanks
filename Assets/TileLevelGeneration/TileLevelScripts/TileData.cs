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

        [Tooltip("Rotation to put on toSpawn")]
        public Vector3 rotation;

        //[Tooltip("True to set toSpawn's mesh material color to meshColor")]
        //public bool overrideMeshColor;

        //[Tooltip("Color to set on toSpawn's mesh")]
        //public Color meshColor;
    }
}

