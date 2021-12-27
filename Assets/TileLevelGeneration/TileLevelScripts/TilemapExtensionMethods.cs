using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public static class TilemapExtensionMethods
{


    public static void MapAllOccupiedTiles(this Tilemap tilemapToMap, Action<Vector3Int> operation)
    {
        foreach (Vector3Int tilePosition in
            tilemapToMap.cellBounds.allPositionsWithin)
        {
            if (tilemapToMap.HasTile(tilePosition))
            {
                operation(tilePosition);
            }
        }
    }
}
