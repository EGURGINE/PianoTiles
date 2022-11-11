using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct SetTiles
{
    public int isTrueTile;
    public bool isEnd;

}
public class LinedTiles : MonoBehaviour
{
    public SetTiles setTiles;

    public void Setting()
    {
        print(setTiles.isTrueTile);
        for (int i = 0; i < 4; i++)
        {
            bool isTrue = (i == setTiles.isTrueTile) ? true : false;
            transform.GetChild(setTiles.isTrueTile).gameObject.GetComponent<Tile>().
                StartSET(isTrue ,setTiles.isEnd);
        }
    }
}
