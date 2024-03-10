using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GenerateBG : MonoBehaviour
{
    public Tilemap tilemap; // 你的 Tilemap 组件
    public TileBase tile; // 你的瓦片

    void Start()
    {
        GenerateTilemap();
    }

    public void GenerateTilemap()
    {
        for (int x = -30; x < 30; x++)
        {
            for (int y = -30; y < 30; y++)
            {
                Vector3Int tilePosition = new Vector3Int(x, y, 0);
                tilemap.SetTile(tilePosition, tile);
            }
        }
    }
}
