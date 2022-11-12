using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinedTiles : MonoBehaviour
{
    public int isTrueTile;

    public void Setting()
    {
        for (int i = 0; i < 4; i++)
        {
            bool isTrue = (i == isTrueTile) ? true : false;
            transform.GetChild(i).gameObject.GetComponent<Tile>().
                StartSET(isTrue);
        }
    }
}
