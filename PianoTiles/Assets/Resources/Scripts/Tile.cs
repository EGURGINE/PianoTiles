using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tile : MonoBehaviour
{
    private Image img => this.GetComponent<Image>();

    public bool trueTile;
    public void StartSET(bool isTrue)
    {
        if(isTrue) img.color = Color.black;
        else img.color = Color.white;
        trueTile = isTrue;
    }
}
