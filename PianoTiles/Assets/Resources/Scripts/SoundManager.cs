using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] AudioClip[] gameOver;
    [SerializeField] AudioClip[] gameClear;

    public void ClearSound()
    {
        StartCoroutine(clearSond());
    }
    private IEnumerator clearSond()
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < gameClear.Length; i++)
        {
            GameObject go = new GameObject("clear" + i);
            AudioSource audio = go.AddComponent<AudioSource>();
            audio.volume = 0.5f;
            audio.clip = gameOver[i];
            audio.Play();
            Destroy(go, audio.clip.length);
            yield return new WaitForSeconds(0.15f);
        }
        GameManager.Instance.CloseRendering();
    }
    public void OverSound()
    {
        for (int i = 0; i < gameOver.Length; i++)
        {
            GameObject go = new GameObject("over" + i);
            AudioSource audio = go.AddComponent<AudioSource>();
            audio.volume = 0.5f;
            audio.clip = gameOver[i];
            audio.Play();
            Destroy(go, audio.clip.length);
        }
    }
    public void TrueSound()
    {
        GameObject go = new GameObject("sound");
        AudioSource audio = go.AddComponent<AudioSource>();
        audio.clip = GameManager.Instance.music[((int)GameManager.Instance.Progress)];
        audio.Play();
        Destroy(go,audio.clip.length);
    }
}
