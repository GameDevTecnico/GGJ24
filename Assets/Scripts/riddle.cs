using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Riddle : MonoBehaviour
{
    private string currentString = "";
    private List<string> wordList = new List<string> { "JUNK", "LUNA", "NAIL", "JAIL", "HALL", "HAIL", "NILL", "LIAR", "HAIR", "RUIN", "ALAN" };
    public TextMeshProUGUI ui;
    public AudioClip[] audioClips;  

    void Start()
    {
        StartCoroutine(PlayAudio(0, false));
    }

    public void WriteChar(string letter)
    {
        currentString += letter;
        if (currentString.Length > 4)
        {
            Delete();
            currentString += letter;
        }
        Debug.Log("Current String: " + currentString);

        ui.text = currentString;

        CheckWord();
    }

    public void Delete()
    {
        currentString = "";
    }

    private void CheckWord()
    {
        if (wordList.Contains(currentString))
        {
            int index = wordList.IndexOf(currentString);
            StartCoroutine(PlayAudio(index + 1, index == 10)); // change number
        }
    }

    private IEnumerator PlayAudio(int i, bool correct)
    {
        while (GetComponent<AudioSource>().isPlaying)
        {
            yield return null;
        }

        GetComponent<AudioSource>().clip = audioClips[i];
        GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(audioClips[i].length + 1);

        if (correct)
        {
            SceneManager.LoadScene("Lvl3");
        }
    }
}
