using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace TileLevelGeneration
{
    public class TileLevelManager : MonoBehaviour
    {
        private Tilemap objectTilemap;
        private Tilemap heightTilemap;

        private TileLevelGenerator tileLevelGenerator;

        [Tooltip("True shows the tilemap renders when the level is generated")]
        [SerializeField] private bool enableTilemapRenderer;

        [Tooltip("List of all TileData used in this level")]
        [SerializeField] private List<TileData> tileDataList
            = new List<TileData>();

        [Tooltip("TileHeightmapData used in this level")]
        [SerializeField] private TileHeightmapData tileHeightmapData;

        private Dictionary<TileBase, TileData> tileDataDictionary
            = new Dictionary<TileBase, TileData>();

        private Dictionary<TileBase, float> tileHeightmapDictionary
            = new Dictionary<TileBase, float>();

        private void Awake()
        {
            objectTilemap = GameObject.Find("ObjectTilemap").GetComponent<Tilemap>();
            heightTilemap = GameObject.Find("HeightTilemap").GetComponent<Tilemap>();

            objectTilemap.GetComponent<TilemapRenderer>().enabled = enableTilemapRenderer;
            heightTilemap.GetComponent<TilemapRenderer>().enabled = enableTilemapRenderer;

            ConstructTileDataDictionary();
            ConstructHieghtmapDataDictionary();


            tileLevelGenerator = GetComponent<TileLevelGenerator>();
            tileLevelGenerator.Construct(this, objectTilemap, heightTilemap);
        }

        private void ConstructTileDataDictionary()
        {
            foreach (TileData tileData in tileDataList)
            {
                tileDataDictionary.Add(tileData.tileBase, tileData);
            }
        }

        private void ConstructHieghtmapDataDictionary()
        {
            if (tileHeightmapData == null)
            {
                Debug.LogError(this + " Error: Cannot have null tileHeightmapData");
                return;
            }

            if (tileHeightmapData.maxHieght <= tileHeightmapData.minHieght)
            {
                Debug.LogError(this + " Error: Cannot have tileHeightmapData.maxHieght <= tileHeightmapData.minHieght");
                return;
            }

            int listSize = tileHeightmapData.heighmapTileList.Count;
            float range = tileHeightmapData.maxHieght - tileHeightmapData.minHieght;
            float increment = range / (listSize - 1);

            for (int i = 0; i < listSize; ++i)
            {
                TileBase thisTileBase = tileHeightmapData.heighmapTileList[i];

                float thisHeight = tileHeightmapData.minHieght + i * increment;
                tileHeightmapDictionary.Add(thisTileBase, thisHeight);
            }
        }

        public TileData GetTileData(Vector3Int position)
        {
            TileBase tile = objectTilemap.GetTile(position);
            if(tile == null)
            {
                Debug.LogError(this + " Error: No object tile at tile position " + position);
            }
            return tileDataDictionary[tile];
        }

        public float GetHeightmapHeight(Vector3Int position)
        {
            TileBase tile = heightTilemap.GetTile(position);
            if (tile == null)
            {
                Debug.LogWarning(this + " Warning: No hieghtmap tile at tile position " + position);
                return tileHeightmapData.minHieght;
            }
            return tileHeightmapDictionary[tile];
        }
    }
}