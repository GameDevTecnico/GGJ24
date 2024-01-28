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
    public AudioClip[] wordAudioClips;  
    public AudioSource audioSource;

    public void WriteChar(string letter)
    {
        currentString += letter;
        if (currentString.Length > 4)
        {
            Delete();
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
            PlayAudio(index);

            if (currentString.Equals("alan", System.StringComparison.OrdinalIgnoreCase))
            {
                LoadScene("Lvl3");
            }
        }
    }

    private void PlayAudio(int index)
    {
        if (index >= 0 && index < wordAudioClips.Length)
        {
            audioSource.clip = wordAudioClips[index];
            audioSource.Play();
        }
    }

    private void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
