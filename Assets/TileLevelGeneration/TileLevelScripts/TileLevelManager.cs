using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace TileLevelGeneration
{
    public class TileLevelManager : MonoBehaviour
    {
        private Tilemap tilemap;

        private TileLevelGenerator tileLevelGenerator;

        [Tooltip("List of all TileData used in this level")]
        [SerializeField] private List<TileData> tileDataList
            = new List<TileData>();

        private Dictionary<TileBase, TileData> tileDataDictionary
            = new Dictionary<TileBase, TileData>();

        private void Awake()
        {
            tilemap = GetComponent<Tilemap>();

            ConstructTileDataDictionary();

            tileLevelGenerator = GetComponent<TileLevelGenerator>();
            tileLevelGenerator.Construct(this, tilemap);
        }

        private void ConstructTileDataDictionary()
        {
            foreach (TileData tileData in tileDataList)
            {
                tileDataDictionary.Add(tileData.tileBase, tileData);
            }
        }

        public TileData GetTileData(Vector3Int position)
        {
            TileBase tile = tilemap.GetTile(position);
            return tileDataDictionary[tile];
        }
    }
}