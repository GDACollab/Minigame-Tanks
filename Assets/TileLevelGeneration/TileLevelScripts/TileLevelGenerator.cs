using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace TileLevelGeneration
{
    public class TileLevelGenerator : MonoBehaviour
    {
        private TileLevelManager tileLevelManager;
        private Tilemap objectTilemap;
        private Tilemap heightTilemap;

        private Dictionary<Vector3Int, TileObject> tileObjectDictionary
            = new Dictionary<Vector3Int, TileObject>();

        private Dictionary<Vector3Int, Color> positionColorDictionary
            = new Dictionary<Vector3Int, Color>();

        private Vector3 objectOffset;

        public void Construct(TileLevelManager tileLevelManager
            , Tilemap objectTilemap
            , Tilemap heightTilemap
            , Dictionary<Vector3Int, Color>  positionColorDictionary)
        {
            this.tileLevelManager = tileLevelManager;
            this.objectTilemap = objectTilemap;
            this.heightTilemap = heightTilemap;
            this.positionColorDictionary = positionColorDictionary;

            // objectOffset since CellToWorld doesn't return the center of the tile
            Vector3 tileSize = objectTilemap.cellSize;
            objectOffset = new Vector3(tileSize.x * 0.5f, 0
                , tileSize.y * 0.5f);

            SpawnObjectTilemap();
            MapTileObjectHeights();
            ColorTileObjects();
        }

        private void SpawnObjectTilemap()
        {
            objectTilemap.MapAllOccupiedTiles((tilePosition) =>
            {
                Vector3 worldPosition = objectTilemap.CellToWorld(tilePosition) + objectOffset;

                TileData tileData = tileLevelManager.GetTileData(tilePosition);

                if (tileData != null)
                {
                    GameObject tileObject = tileData.toSpawn;

                    Quaternion rotation = Quaternion.Euler(tileData.rotation);
                    if (tileObject != null)
                    {
                        GameObject thisObject = Instantiate(tileObject, worldPosition, rotation);
                        TileObject thisTileObject = thisObject.GetComponent<TileObject>();
                        tileObjectDictionary.Add(tilePosition, thisTileObject);
                    }
                }
                else
                {
                    Debug.LogError(this + " Error: Cannot find TileData" +
                        " for tile at world position " + worldPosition);
                }
            });
        }

        private void MapTileObjectHeights()
        {
            heightTilemap.MapAllOccupiedTiles((tilePosition) =>
            {
                Vector3 worldPosition = heightTilemap.CellToWorld(tilePosition) + objectOffset;

                if (!tileObjectDictionary.ContainsKey(tilePosition))
                {
                    Debug.LogWarning(this + " Warning: Heightmap tile at world position "
                        + worldPosition + " has no TileObject");
                }

                float thisHeight = tileLevelManager.GetHeightmapHeight(tilePosition);

                Transform thisMeshTransform = tileObjectDictionary[tilePosition]
                    .meshTransform;

                Vector3 originalScale = thisMeshTransform.localScale;

                thisMeshTransform.localScale = new Vector3(originalScale.x,
                    originalScale.y * thisHeight, originalScale.y);
            });
        }

        private void ColorTileObjects()
        {
            foreach(KeyValuePair<Vector3Int, TileObject> positionObjectPair
                in tileObjectDictionary)
            {
                if(positionColorDictionary.ContainsKey(positionObjectPair.Key))
                {
                    Color color = positionColorDictionary[positionObjectPair.Key];
                    positionObjectPair.Value.SetColor(color);
                }
            }
        }
    }
}