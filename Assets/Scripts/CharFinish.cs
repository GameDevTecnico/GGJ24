using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharFinish : MonoBehaviour
{
    [SerializeField] private CharCreator charCreator;

    public AudioClip audioClip;

    public void LoadNextScene()
    {
        if (charCreator != null)
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.head = charCreator.head;
                gameManager.leg = charCreator.leg;
                gameManager.torso = charCreator.torso;
            }
        }
        StartCoroutine(PlayAudio());
    }

    private IEnumerator PlayAudio()
    {
        while (GetComponent<AudioSource>().isPlaying)
        {
            yield return null;
        }

        GetComponent<AudioSource>().clip = audioClip;
        GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(audioClip.length + 1);
        SceneManager.LoadScene("Lvl 2");
    }
}
