using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
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
                SoundManager.Instance.ClearSound();
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

    private void Update()
    {
        if (isStart)
        {
            CurTime += Time.deltaTime;
        }
    }

    public void StartSET()
    {
        OpenRendering();
        Progress = 0;
        curtime = 0;
        num = 0;

        isStart = true;
        sp.StartSet();
    }
    [SerializeField] private GameObject leftObjs;
    [SerializeField] private GameObject rightObjs;
    [SerializeField] private GameObject title;
    [SerializeField] private GameObject startBtn;
    private void OpenRendering()
    {
        startBtn.SetActive(false);
        leftObjs.transform.DOMoveX(-3f,0.5f);
        rightObjs.transform.DOMoveX(3f, 0.5f).OnComplete(()=> title.SetActive(false));

    }
    public void CloseRendering()
    {
        title.SetActive(true);
        leftObjs.transform.DOMoveX(0f, 0.5f);
        rightObjs.transform.DOMoveX(0f, 0.5f).OnComplete(() => startBtn.SetActive(true));
    }

    public void Die()
    {
        SoundManager.Instance.OverSound();
        isStart = false;
        CloseRendering();
    }

}
