using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace TileLevelGeneration
{
    public class TileLevelGenerator : MonoBehaviour
    {
        private TileLevelManager tileLevelManager;
        private Tilemap tilemap;

        private Vector3 objectOffset;

        public void Construct(TileLevelManager tileLevelManager
            , Tilemap tilemap)
        {
            this.tileLevelManager = tileLevelManager;
            this.tilemap = tilemap;

            // objectOffset since CellToWorld strangely isn't at the center of the tile
            Vector3 tileSize = tilemap.cellSize;
            objectOffset = new Vector3(tileSize.x * 0.5f, 0
                , tileSize.y * 0.5f);

            FillTiles();
        }

        private void FillTiles()
        {
            foreach (Vector3Int tilePosition in
                tilemap.cellBounds.allPositionsWithin)
            {
                if (tilemap.HasTile(tilePosition))
                {
                    Vector3 worldPosition = tilemap.CellToWorld(tilePosition);

                    TileData tileData = tileLevelManager.GetTileData(tilePosition);

                    if (tileData != null)
                    {
                        GameObject tileObject = tileData.toSpawn;
                        if(tileObject != null)
                        {
                            Instantiate(tileObject, worldPosition + objectOffset, Quaternion.identity);
                        }
                    }
                    else
                    {
                        Debug.LogError(this + " Error: Cannot find TileData" +
                            " for tile at world position " + worldPosition);
                    }
                }
            }
        }
    }
}