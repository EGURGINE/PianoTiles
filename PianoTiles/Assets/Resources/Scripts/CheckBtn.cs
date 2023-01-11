using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum EBtnType
{
    D,
    F,
    J,
    K
}
public class CheckBtn : MonoBehaviour
{
    [SerializeField] private EBtnType type;
    private Button btn => this.GetComponent<Button>();
    private Tile myTile => this.GetComponent<Tile>();

    private void Awake()
    {
        btn.onClick.AddListener(()=>Check());
    }
    private void Update()
    {
        switch (type)
        {
            case EBtnType.D:
                if(Input.GetKeyDown(KeyCode.UpArrow))
                Check();
                break;                     
            case EBtnType.F:
                if (Input.GetKeyDown(KeyCode.DownArrow))
                    Check();
                break;
            case EBtnType.J:
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                    Check();
                break;
            case EBtnType.K:
                if (Input.GetKeyDown(KeyCode.RightArrow))
                    Check();
                break;
        }
    }
    private void Check()
    {
        if (myTile.trueTile == true && GameManager.Instance.isStart == true)
        {
            SoundManager.Instance.TrueSound();
            GameManager.Instance.sp.Spawn();
            GameManager.Instance.Progress += 1;
        }
        else GameManager.Instance.Die();
    }
}
