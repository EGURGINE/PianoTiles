using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<LinedTiles> linedTiles = new List<LinedTiles>();

    private void Awake()
    {
        for (int i = 0; i < 4; i++)
        {
            linedTiles.Add(transform.GetChild(i).gameObject.GetComponent<LinedTiles>()); 
        }
    }
    public void StartSet()
    {
        for (int i = 0; i < 4; i++)
        {
            GameManager.Instance.num++;
            linedTiles[i].isTrueTile = Random.Range(0, 4);
            linedTiles[i].Setting();
        }
    }
    public void Spawn()
    {
        Sorting();
        GameManager.Instance.num++;
    }

    private void Sorting()
    {
        for (int i = 3; i >= 0; i--)
        {
            if(i == 0)
            {
                if(GameManager.Instance.num >= GameManager.Instance.music.Count) linedTiles[i].isTrueTile = 5;
                else
                {
                    linedTiles[i].isTrueTile = Random.Range(0, 4);
                }
            }
            else
            {
                int num = i - 1;
                linedTiles[i].isTrueTile = linedTiles[num].isTrueTile;
            }
            linedTiles[i].Setting();
        }   
    }
}
