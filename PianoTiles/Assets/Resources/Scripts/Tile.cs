using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tile : MonoBehaviour
{
    private Button btn=> this.GetComponent<Button>();
    private Image img => this.GetComponent<Image>();

    public bool isEndTile;
    public bool trueTile;

    private void Awake()
    {
        btn.onClick.AddListener(() => Check());
    }

    public void StartSET(bool isTrue, bool isEnd)
    {
        if(isTrue) img.color = Color.black;
        else img.color = Color.white;
        trueTile = isTrue;
        isEndTile = isEnd;
    }

    private void Check()
    {

    }
}
