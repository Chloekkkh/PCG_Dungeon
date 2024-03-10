using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "tileInfo_", menuName = "Tile/TileData")]
public class TileInfo : ScriptableObject
{
    // public Tilemap floorTilemap;

    // public Tilemap wallTilemap;

    // public Tilemap itemTilemap;

    public TileBase floorTile;
    //public TileBase shadowTile;


    //private TileBase wallTop, wallSideRight, wallSideLeft, wallbottom, wallFull;
    public TileBase up, upRight, upLeft, right, left, down, downRight, downLeft;

    public TileBase cornerUpRight, cornerUpLeft, cornerDownRight, cornerDownLeft;


    public List<TileBase> itemTileList;//应该是个list

    public int count = 10;
}
