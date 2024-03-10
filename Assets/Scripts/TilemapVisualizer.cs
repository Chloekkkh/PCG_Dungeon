using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapVisualizer : MonoBehaviour
{
    //用素材
    [SerializeField]
    private Tilemap floorTilemap;
    [SerializeField]
    private Tilemap wallTilemap;
    [SerializeField]
    private Tilemap itemTilemap;
    // [SerializeField]
    // private TileBase floorTile;

    // [SerializeField]
    // //private TileBase wallTop, wallSideRight, wallSideLeft, wallbottom, wallFull;
    // private TileBase up, upRight, upLeft, right, left, down, downRight, downLeft;
    // [SerializeField]
    // private TileBase cornerUpRight, cornerUpLeft, cornerDownRight, cornerDownLeft;

    // [SerializeField]
    // private List<TileBase> itemTileList;//应该是个list

    // [SerializeField] int count = 10;

    //create asset
    [SerializeField]
    private TileInfo tileInfoParameters;

    public void PaintFloorTiles(IEnumerable<Vector2Int> floorPositions)
    {
        PaintTiles(floorPositions, floorTilemap, tileInfoParameters.floorTile);
    }
    public void PaintItemTiles(IEnumerable<Vector2Int> floorPositions)
    {
        PaintDecreations(floorPositions, itemTilemap);
    }
    // public void PaintShadowTiles(IEnumerable<Vector2Int> floorPositions)
    // {
    //     PaintTiles(floorPositions, floorTilemap, tileInfoParameters.shadowTile);
    // }

    private void PaintTiles(IEnumerable<Vector2Int> positions, Tilemap tilemap, TileBase tile)
    {
        foreach(var position in positions)
        {
            PaintSingleTile(tilemap, tile, position);
        }
    }

    private void PaintSingleTile(Tilemap tilemap, TileBase tile, Vector2Int position)
    {
        var tilePosition = tilemap.WorldToCell((Vector3Int)position);
        tilemap.SetTile(tilePosition, tile);
        //tile.AddComponent<TilemapCollider2D>();
    }

    //random items
    private void PaintDecreations(IEnumerable<Vector2Int> positions, Tilemap itemTilemap)
    {
        //在item的tilemap上绘制
        //随机传入一个位置和一个item
        List<Vector2Int> originalPositions = positions.ToList();
        //List<Vector2Int> itemPositions = new List<Vector2Int>();
        Vector2Int itemPosition;
        for(int i = 0; i < tileInfoParameters.count; i++)
        {
            itemPosition = originalPositions[UnityEngine.Random.Range(0, originalPositions.Count)];
            originalPositions.Remove(itemPosition);
            PaintSingleTile(itemTilemap, tileInfoParameters.itemTileList[UnityEngine.Random.Range(0, tileInfoParameters.itemTileList.Count)], itemPosition);
        }
    }

    internal void PaintSingleBasicWall(Vector2Int position , string binaryType)
    {
        int typeAsInt = Convert.ToInt32(binaryType, 2);
        TileBase tile = null;
        //8 types of wall
        //up-left
        //up-right
        //up
        //right
        //left
        //down-left
        //down-right
        //down
        if(WallTypesHelper.up.Contains(typeAsInt))
        {
            tile = tileInfoParameters.up;
        }
        else if(WallTypesHelper.upRight.Contains(typeAsInt))
        {
            tile = tileInfoParameters.upRight;
        }
        else if(WallTypesHelper.upLeft.Contains(typeAsInt))
        {
            tile = tileInfoParameters.upLeft;
        }
        else if(WallTypesHelper.down.Contains(typeAsInt))
        {
            tile = tileInfoParameters.down;
        }
        else if(WallTypesHelper.downRight.Contains(typeAsInt))
        {
            tile = tileInfoParameters.downRight;
        }
        else if(WallTypesHelper.downLeft.Contains(typeAsInt))
        {
            tile = tileInfoParameters.downLeft;
        }
        else if(WallTypesHelper.right.Contains(typeAsInt))
        {
            tile = tileInfoParameters.right;
        }
        else if(WallTypesHelper.left.Contains(typeAsInt))
        {
            tile = tileInfoParameters.left;
        }


        if(tile != null)
        {
            PaintSingleTile(wallTilemap, tile, position);
        }
        //PaintSingleTile(wallTilemap, wallTop, position);
    }

    internal void PaintSingleCornerWall(Vector2Int position, string binaryType)
    {
        //corner
        int typeAsInt = Convert.ToInt32(binaryType, 2);
        TileBase tile = null;

        if(WallTypesHelper.cornerUpRight.Contains(typeAsInt))
        {
            tile = tileInfoParameters.cornerUpRight;
        }
        else if(WallTypesHelper.cornerUpLeft.Contains(typeAsInt))
        {
            tile = tileInfoParameters.cornerUpLeft;
        }
        else if(WallTypesHelper.cornerDownRight.Contains(typeAsInt))
        {
            tile = tileInfoParameters.cornerDownRight;
        }
        else if(WallTypesHelper.cornerDownLeft.Contains(typeAsInt))
        {
            tile = tileInfoParameters.cornerDownLeft;
        }

        if(tile != null)
        {
            PaintSingleTile(wallTilemap, tile, position);
        }



    }

    public void clear()
    {
        floorTilemap.ClearAllTiles();
        wallTilemap.ClearAllTiles();
        itemTilemap.ClearAllTiles();
    }


}
