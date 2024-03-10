using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using TMPro;
using UnityEngine;

public class RandomWalkMapGenerator : MapGenerator
{
    public int mapSize = 50;
    [SerializeField]
    private SimpleRandomWalkData randomWalkParameters;

    //castle
    [SerializeField] GameObject castlePrefeb;
    [SerializeField] int castleCount = 10;
    [SerializeField] float radius = 200;
    [SerializeField] LayerMask landLayer;
    [SerializeField] GameObject parentPrefeb;
    GameObject parent;

    protected override void RunProceduralGeneration()
    {
        HashSet<Vector2Int> floorPosition = RunRandomWalk(Vector2Int.zero);

        tilemapVisualizer.clear();

        floorPosition = WallGenerator.CreateWalls(floorPosition, tilemapVisualizer);
        tilemapVisualizer.PaintFloorTiles(floorPosition);
        //WallGenerator.CreateWalls(floorPosition, tilemapVisualizer);
        tilemapVisualizer.PaintItemTiles(floorPosition);
    }

    protected override void RunProceduralGeneration_HoleMap()
    {
        tilemapVisualizer.clear();
        //删除parent
        if(parent!=null)
        {
            Destroy(parent);
            DestroyImmediate(parent);
        }
         

        //传入一个随机的起始点
        List<Vector2Int> floorPositions = new List<Vector2Int>();
        foreach (var position in RandomPointGenerator.GenerateRandomPoints(mapSize))
        {
            HashSet<Vector2Int> floorPosition = RunRandomWalk(position);
            //tilemapVisualizer.clear();
            //floorposition
            //wallposition
            //tilemapVisualizer.PaintFloorTiles(floorPosition);
            floorPosition = WallGenerator.CreateWalls(floorPosition, tilemapVisualizer);
            //floor
            tilemapVisualizer.PaintFloorTiles(floorPosition);
            //items
            tilemapVisualizer.PaintItemTiles(floorPosition);
        }

        //generate castle
        parent = Instantiate(parentPrefeb, new UnityEngine.Vector3(0,0,0), UnityEngine.Quaternion.identity);
        SetRandomDungeon.GenerateCastleEntrance(castleCount, mapSize, castlePrefeb, radius, landLayer, parent.transform);

        
    }

    protected HashSet<Vector2Int> RunRandomWalk(Vector2Int startPosition)
    {
        var currentPosition = startPosition;
        HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>();
        for(int i = 0; i < randomWalkParameters.iterations; i++)
        {
            var path = ProceduralAlgorithm.SimpleRandomWalk(currentPosition, randomWalkParameters.walkLength);
            floorPositions.UnionWith(path);

            if(randomWalkParameters.startRandomlyEachIteration)
            {
                currentPosition = floorPositions.ElementAt(Random.Range(0, floorPositions.Count));
            }
        }

        return floorPositions;
    }
}
