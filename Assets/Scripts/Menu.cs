using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public AudioClip[] audioClips;
    private AudioSource audioSource;
    private int audioIndex = 0;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("Lvl 1");
    }

    public void QuitButton()
    {
        if (audioIndex < audioClips.Length)
        {
            audioSource.PlayOneShot(audioClips[audioIndex]);
            audioIndex++;

            if (audioIndex == audioClips.Length)
            {
                StartCoroutine(DelayedPlayButton());
            }
        }
    }

    IEnumerator DelayedPlayButton()
    {
        yield return new WaitForSeconds(audioSource.clip.length);
        PlayButton();
    }
}
