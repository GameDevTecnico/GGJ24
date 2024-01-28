using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public AudioClip[] audioClips;
    public AudioClip[] audioClipsStart;
    private AudioSource audioSource;
    private int audioIndex = 0;

    private bool playing = false;

    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            StartCoroutine(PlayAudio(i));
        }
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
        yield return new WaitForSeconds(3);
        PlayButton();
    }

    private IEnumerator PlayAudio(int i)
    {
        while (GetComponent<AudioSource>().isPlaying || playing)
        {
            yield return null;
        }

        GetComponent<AudioSource>().clip = audioClipsStart[i];
        GetComponent<AudioSource>().Play();

        playing = true;

        yield return new WaitForSeconds(audioClipsStart[i].length);
        yield return new WaitForSeconds(2.5f);

        playing = false;
    }
}
