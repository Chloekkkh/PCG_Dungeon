using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MapGenerator), true)]

public class MapGeneratorEditor : Editor
{
    MapGenerator mapGenerator;


    private void Awake()
    {
        mapGenerator = (MapGenerator)target;

    }

    override public void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if(GUILayout.Button("Generate Map"))
        {
            mapGenerator.GeneatorMap();

        }
    }
}
