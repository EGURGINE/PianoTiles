using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public void TrueSound()
    {
        GameObject go = new GameObject("sound");
        AudioSource audio = go.AddComponent<AudioSource>();
        audio.clip = GameManager.Instance.music[((int)GameManager.Instance.Progress)];
        audio.Play();
        Destroy(go,audio.clip.length);
    }
}
