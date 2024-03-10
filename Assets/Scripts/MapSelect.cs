using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
public class MapSelect : MonoBehaviour
{
    public void Map1()
    {
        SceneManager.LoadScene(1);
    }

    public void Map2()
    {
        SceneManager.LoadScene(2);
    }

    public void Map3()
    {
        SceneManager.LoadScene(3);
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }
}
