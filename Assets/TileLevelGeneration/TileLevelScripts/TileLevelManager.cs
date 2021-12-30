using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace TileLevelGeneration
{
    public class TileLevelManager : MonoBehaviour
    {
        private Tilemap objectTilemap;
        private Tilemap heightTilemap;
        private Tilemap colorTilemap;

        private TileLevelGenerator tileLevelGenerator;

        [Tooltip("True shows the tilemap renders when the level is generated")]
        [SerializeField] private bool enableTilemapRenderer;

        [Tooltip("List of all TileData used in this level")]
        [SerializeField] private List<TileData> tileDataList
            = new List<TileData>();

        [Tooltip("TileHeightmapData used in this level")]
        [SerializeField] private TileHeightmapData tileHeightmapData;

        [Tooltip("List of all tileColorData used in this level")]
        [SerializeField] private List<TileColorData> tileColorDataList
            = new List<TileColorData>();

        private Dictionary<TileBase, TileData> tileDataDictionary
            = new Dictionary<TileBase, TileData>();

        private Dictionary<TileBase, float> tileHeightmapDictionary
            = new Dictionary<TileBase, float>();

        private Dictionary<TileBase, Color> tileColorDictionary
            = new Dictionary<TileBase, Color>();

        private Dictionary<Vector3Int, Color> positionColorDictionary
            = new Dictionary<Vector3Int, Color>();

        private void Awake()
        {
            objectTilemap = GameObject.Find("ObjectTilemap").GetComponent<Tilemap>();
            heightTilemap = GameObject.Find("HeightTilemap").GetComponent<Tilemap>();
            colorTilemap = GameObject.Find("ColorTilemap").GetComponent<Tilemap>();

            objectTilemap.GetComponent<TilemapRenderer>().enabled = enableTilemapRenderer;
            heightTilemap.GetComponent<TilemapRenderer>().enabled = enableTilemapRenderer;
            colorTilemap.GetComponent<TilemapRenderer>().enabled = enableTilemapRenderer;

            ConstructTileDataDictionary();
            ConstructHieghtmapDataDictionary();
            ConstructTileColorDictionary();
            ConstructPositionColorDictionary();

            tileLevelGenerator = GetComponent<TileLevelGenerator>();
            tileLevelGenerator.Construct(this, objectTilemap, heightTilemap, positionColorDictionary);
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

        private void ConstructTileColorDictionary()
        {
            foreach (TileColorData tileColorData in tileColorDataList)
            {
                tileColorDictionary.Add(tileColorData.tileBase, tileColorData.objectColor);
            }
        }

        private void ConstructPositionColorDictionary()
        {
            colorTilemap.MapAllOccupiedTiles((tilePosition) =>
            {
                Color color = GetTileColor(tilePosition);
                positionColorDictionary.Add(tilePosition, color);
            });
        }

        public T GetDataFromTilePosition<T>(Dictionary <TileBase, T> dictionary
            , Tilemap tilemap, Vector3Int position, T defualtReturn)
        {
            TileBase tile = tilemap.GetTile(position);
            if (tile == null)
            {
                Debug.LogWarning(this + " Warning: No " + typeof(T) + " at tile position " + position);
                return defualtReturn;
            }
            return dictionary[tile];
        }

        public TileData GetTileData(Vector3Int position)
        {
            return GetDataFromTilePosition(tileDataDictionary,
                objectTilemap, position, null);
        }

        public float GetHeightmapHeight(Vector3Int position)
        {
            return GetDataFromTilePosition(tileHeightmapDictionary,
                heightTilemap, position, tileHeightmapData.minHieght);
        }

        public Color GetTileColor(Vector3Int position)
        {
            return GetDataFromTilePosition(tileColorDictionary,
                colorTilemap, position, Color.white);
        }
    }
}