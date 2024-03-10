using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class MapGenerator : MonoBehaviour
{
    [SerializeField]
    protected TilemapVisualizer tilemapVisualizer = null;
    [SerializeField]
    protected Vector2Int startPosition = Vector2Int.zero;

    void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 4)
        GenerateDungoen();
        else
        GeneatorMap();
    }
    public void GeneatorMap()
    {
        tilemapVisualizer.clear();
        //RunProceduralGeneration();
        RunProceduralGeneration_HoleMap();
        
    }
    public void GenerateDungoen()
    {
        tilemapVisualizer.clear();
        RunProceduralGeneration();
    }


    protected abstract void RunProceduralGeneration();
    protected abstract void RunProceduralGeneration_HoleMap();

}
