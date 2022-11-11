using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private int maxSpawnNum => GameManager.Instance.music.Count;
    public List<LinedTiles> linedTiles = new List<LinedTiles>();

    private void Awake()
    {
        for (int i = 0; i < 4; i++)
        {
            linedTiles.Add(transform.GetChild(i).gameObject.GetComponent<LinedTiles>()); 
        }
        StartSet();
    }
    public void StartSet()
    {
        for (int i = 0; i < 4; i++)
        {
            linedTiles[i].setTiles.isTrueTile = Random.Range(0, 4);
            linedTiles[i].Setting();
        }
    }
    public void Spawn()
    {
        Sorting();
    }

    private void Sorting()
    {
        for (int i = 4; i < 0; i--)
        {
            linedTiles[i].setTiles = linedTiles[i - 1].setTiles;
            linedTiles[i].Setting();
        }   
    }
}
