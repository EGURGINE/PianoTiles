using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    public List<AudioClip> music = new List<AudioClip>();
    public Spawner sp;

    public int num;

    [SerializeField] private Image progressBar;
    private float progress;
    public float Progress
    {
        get
        {
            return progress;
        }
        set
        {
            progress = value;
            progressBar.fillAmount = progress / music.Count;

            if (progress >= music.Count)
            {
                isStart = false;
            }
        }
    }

    [SerializeField] private TextMeshProUGUI timeTxt;
    private float curtime;
    public float CurTime
    {
        get { return curtime; }
        set 
        { 
            curtime = value; 
            timeTxt.text = string.Format("{0:0.000}",curtime);
        }
    }

    public bool isStart;

    private void Start()
    {
        StartSET();
    }
    private void Update()
    {
        if (isStart)
        {
            CurTime += Time.deltaTime;
        }
    }

    public void StartSET()
    {
        progress = 0;
        curtime = 0;
        num = 0;

        isStart = true;
        sp.StartSet();
    }

    public void Die()
    {
        isStart = false;
    }

}
