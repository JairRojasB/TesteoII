using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    float volumen = 0;

    public AudioClip[] goodClips, badClips;

    public AudioSource audioSource;

    public void PlaySelecctedListener(bool itWasGood)
    {
        if(itWasGood == true)
        {
            int estaGod = Random.Range(0, goodClips.Length);
            audioSource.clip = goodClips[estaGod];
        }
        else
        {
            int estaBad = Random.Range(0, badClips.Length);
            audioSource.clip = badClips[estaBad];
        }

        audioSource.Play();
    }
}
