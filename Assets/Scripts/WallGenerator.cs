using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WallGenerator
{
    public static HashSet<Vector2Int> CreateWalls(HashSet<Vector2Int> floorPositions, TilemapVisualizer tilemapVisualizer)
    {
        //var shadowPositions = FindShadowDirections(floorPositions, Direction2D.cardinalDirections);
        var baseicWallPositions = FindWallsInDirections(floorPositions, Direction2D.cardinalDirections);
        var cornerWallPositions = FindWallsInDirections(floorPositions, Direction2D.eightDirectionList);
        //CreateShadow(tilemapVisualizer,shadowPositions);
        CreateBaiscWall(tilemapVisualizer, baseicWallPositions, floorPositions);
        CreateCornerWall(tilemapVisualizer, cornerWallPositions, floorPositions);
        var floorPositionNew = FloorExcpetWall(floorPositions, baseicWallPositions);
        floorPositionNew = FloorExcpetWall(floorPositionNew, cornerWallPositions);

        return floorPositionNew;
    }

    public static HashSet<Vector2Int> FloorExcpetWall(HashSet<Vector2Int> floorPositions, HashSet<Vector2Int> wallPositions)
    {
        //wallPositions = FindWallsInDirections(floorPositions, Direction2D.cardinalDirections);
        floorPositions.ExceptWith(wallPositions);
        return floorPositions;
    }

    // private static void CreateShadow(TilemapVisualizer tilemapVisualizer, HashSet<Vector2Int> shadowPositions)
    // {
    //     tilemapVisualizer.PaintShadowTiles(shadowPositions);
    // }
    private static void CreateBaiscWall(TilemapVisualizer tilemapVisualizer, HashSet<Vector2Int> baseicWallPositions, HashSet<Vector2Int> floorPositions)
    {
        foreach (var position in baseicWallPositions)
        {
            string neighboursBinaryType = "";
            foreach(var direction in Direction2D.cardinalDirections)
            {
                var neighbourPosition = position + direction;
                if(floorPositions.Contains(neighbourPosition))
                {
                    neighboursBinaryType += "1";
                }
                else
                {
                    neighboursBinaryType += "0";
                }
            }
            tilemapVisualizer.PaintSingleBasicWall(position, neighboursBinaryType);
        }

        //tilemapVisualizer.PaintSingleBasicWall(baseicWallPositions, neighboursBinaryType);
    }

    //corner
    private static void CreateCornerWall(TilemapVisualizer tilemapVisualizer, HashSet<Vector2Int> cornerWallPositions, HashSet<Vector2Int> floorPositions)
    {
        foreach (var position in cornerWallPositions)
        {
            string neighboursBinaryType = "";
            foreach(var direction in Direction2D.eightDirectionList)
            {
                var neighbourPosition = position + direction;
                if(floorPositions.Contains(neighbourPosition))
                {
                    neighboursBinaryType += "1";
                }
                else
                {
                    neighboursBinaryType += "0";
                }
            }
            tilemapVisualizer.PaintSingleCornerWall(position, neighboursBinaryType);
        }
    }

    private static HashSet<Vector2Int> FindWallsInDirections(HashSet<Vector2Int> floorPositions, List<Vector2Int> directionList)
    {
        HashSet<Vector2Int> wallPositions = new HashSet<Vector2Int>();
        foreach(var position in floorPositions)
        {
            foreach(var direction in directionList)
            {
                var neighbourPosition = position + direction;
                if(floorPositions.Contains(neighbourPosition) == false)
                {
                    wallPositions.Add(position);
                    //floorPositions.Delete(position);
                    break;
                }
                    
            }
        }
        return wallPositions;
    }

    //在findwall之前
    private static HashSet<Vector2Int> FindShadowDirections(HashSet<Vector2Int> floorPositions, List<Vector2Int> directionList)
    {
        HashSet<Vector2Int> shadowPositions = new HashSet<Vector2Int>();
        foreach (var position in floorPositions)
        {
            foreach (var direction in directionList)
            {
                var neighbourPosition = position + direction;
                if (floorPositions.Contains(neighbourPosition) == false)
                    shadowPositions.Add(neighbourPosition);
            }
        }
        return shadowPositions;
    }
}
