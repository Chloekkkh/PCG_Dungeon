using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class ProceduralAlgorithm
{
   public static HashSet<Vector2Int> SimpleRandomWalk(Vector2Int startPosition, int walkLength)
    {
        HashSet<Vector2Int> path = new HashSet<Vector2Int>();
        path.Add(startPosition);
        var previousposition = startPosition;

        for(int i = 0; i < walkLength; i++)
        {
            var newPostion = previousposition + Direction2D.GetRandomCarinalDirection();
            path.Add(newPostion);
            path.Add(newPostion + Direction2D.cardinalDirections[0]);
            path.Add(newPostion + Direction2D.cardinalDirections[0] + Direction2D.cardinalDirections[1]);
            path.Add(newPostion + Direction2D.cardinalDirections[0] + Direction2D.cardinalDirections[1] + Direction2D.cardinalDirections[2]);
            
            
            previousposition = newPostion;
        }
        return path;
    }
}

//directions
public static class Direction2D
{
    public static List<Vector2Int> cardinalDirections = new List<Vector2Int>
    {
        new Vector2Int(0, 1),//up
        new Vector2Int(1, 0),//right
        new Vector2Int(0, -1),//down
        new Vector2Int(-1, 0)//left
    };

    //corners
    public static List<Vector2Int> diagonalDirections = new List<Vector2Int>
    {
        new Vector2Int(1, 1),//up-right
        new Vector2Int(1, -1),//right-down
        new Vector2Int(-1, -1),//down-left
        new Vector2Int(-1, 1)//left-up
    };

    public static List<Vector2Int> eightDirectionList = new List<Vector2Int>
    {
        new Vector2Int(0, 1),//up
        new Vector2Int(1, 1),//up-right
        new Vector2Int(1, 0),//right
        new Vector2Int(1, -1),//right-down
        new Vector2Int(0, -1),//down
        new Vector2Int(-1, -1),//down-left
        new Vector2Int(-1, 0),//left
        new Vector2Int(-1, 1),//left-up
    };

    //get random direction
    public static Vector2Int GetRandomCarinalDirection()
    {
        return cardinalDirections[Random.Range(0, cardinalDirections.Count)];
    }
}