using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private bool isPlayingAudio = false;
    private bool first = true;
    public AudioClip[] audioClips;
    public int linesAtStart = 2;

    private void firstTime()
    {
        if (first && !isPlayingAudio)
        {
            for (int i = 0; i < linesAtStart; i++)
            {
                StartCoroutine(PlayAudio(i));
            }
        }
    }

    private IEnumerator PlayAudio(int i)
    {
        isPlayingAudio = true;
        if (i > 0)
        {
            while (GetComponent<AudioSource>().isPlaying)
            {
                yield return null;
            }
        }

        GetComponent<AudioSource>().clip = audioClips[i];
        GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(audioClips[i].length + 1);

        isPlayingAudio = false;
        first = false;
    }

    public void play(int i)
    {
        if (first){
            firstTime();
        }
        
        if (i >= 0 && !isPlayingAudio)
        {
            StartCoroutine(PlayAudio(i));
        }
    }
}
