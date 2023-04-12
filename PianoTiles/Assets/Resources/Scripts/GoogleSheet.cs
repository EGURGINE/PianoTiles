using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class GoogleSheet : MonoBehaviour
{
    string data = "https://docs.google.com/spreadsheets/d/1cftybXIQtD555O3vO4o0oN2CBU5Z98eHxc0NbjsFWA8/export?format=tsv&range=A:A";


    [SerializeField] private AudioClip[] note;
    public List<AudioClip> musicImport = new List<AudioClip>();
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(TryDataRoad());
    }
    private IEnumerator TryDataRoad()
    {
        UnityWebRequest www = UnityWebRequest.Get(data);
        yield return www.SendWebRequest();
        SetMusicSO(www.downloadHandler.text);
    }
    void SetMusicSO(string tsv)
    {
        string[] row = tsv.Split('\n');
        int rowSize = row.Length;
        int columnSize = row[0].Split('\t').Length;

        for (int i = 0; i < rowSize; i++)
        {
            string[] column = row[i].Split('\t');
            for (int j = 0; j < columnSize; j++)
            {
                musicImport.Add(note[int.Parse(column[j])]);
            }
        }

        GameManager.Instance.music = musicImport;
    }
}
