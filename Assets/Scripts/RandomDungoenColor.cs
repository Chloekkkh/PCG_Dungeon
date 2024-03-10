using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RandomDungoenColor : MonoBehaviour
{
    public Camera camerax;
    public List<Color> Colours;
    [Range(0,1)]
    public float Hue = 0.7f;

    void Start()
    {
        for(int i = 0; i< 20; i++)
        {
            Color c = Color.HSVToRGB
            (
                Random.Range(0f,1f), 0.3f, 0.6f
            );
            Colours.Add(c);
        }
        camerax.backgroundColor = Colours[Random.Range(0, Colours.Count)];
    }

}
