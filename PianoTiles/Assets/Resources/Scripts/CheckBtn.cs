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
                if(Input.GetKeyDown(KeyCode.D))
                Check();
                break;
            case EBtnType.F:
                if (Input.GetKeyDown(KeyCode.F))
                    Check();
                break;
            case EBtnType.J:
                if (Input.GetKeyDown(KeyCode.J))
                    Check();
                break;
            case EBtnType.K:
                if (Input.GetKeyDown(KeyCode.K))
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
