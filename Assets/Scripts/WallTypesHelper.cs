using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WallTypesHelper
{

    //my marching squares
    public static HashSet<int> up = new HashSet<int>
    {
        0b0111
    };
    public static HashSet<int> upRight = new HashSet<int>
    {
        0b0011
    };
    public static HashSet<int> upLeft = new HashSet<int>
    {
        0b0110
    };
    public static HashSet<int> right = new HashSet<int>
    {
        0b1011
    };
    public static HashSet<int> left = new HashSet<int>
    {
        0b1110
    };
    public static HashSet<int> down = new HashSet<int>
    {
        0b1101
    };
    public static HashSet<int> downRight = new HashSet<int>
    {
        0b1001
    };
    public static HashSet<int> downLeft = new HashSet<int>
    {
        0b1100
    };

    //corner
    public static HashSet<int> cornerUpRight = new HashSet<int>
    {
        0b10111111
    };
    public static HashSet<int> cornerUpLeft = new HashSet<int>
    {
        0b11111110
    };
    public static HashSet<int> cornerDownRight = new HashSet<int>
    {
        0b11101111
    };
    public static HashSet<int> cornerDownLeft = new HashSet<int>
    {
        0b11111011
    };

}