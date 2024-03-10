using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RandomPointGenerator
{
    public static List<Vector2Int> GenerateRandomPoints(int size)
    {
        List<Vector2Int> points = new List<Vector2Int>();
        Vector2Int origin = Vector2Int.zero; // 原点

        points.Add(origin); // 添加原点
        for (int i = 0; i < 12; i++) // 生成 10 个点
        {

            Vector2Int randomPoint = GetRandomPoint(size); // 获取随机点

            if (IsOverlap(randomPoint, points)) // 如果有重叠
            {
                i--; // 重新生成
                continue;
            }
            points.Add(randomPoint); // 添加到列表
        }
        return points;
    }

    static Vector2Int GetRandomPoint(int size)
    {
        int randomX = (int)RandomGaussian.Range(-size, +size);
        int randomY = (int)RandomGaussian.Range(-size, +size);
        return new Vector2Int(randomX, randomY);
    }
    
    //if has point in circle
    static bool IsOverlap(Vector2Int point, List<Vector2Int> points)
    {
        foreach (var p in points)
        {
            if (Vector2.Distance(p, point) < 13)
            {
                return true;
            }
        }
        return false;
    }
}
