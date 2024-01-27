using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    float volumen = 0;

    public AudioClip[] goodClips, badClips;

    public AudioSource publicReaction;

    [SerializeField] private AudioClip _correctKey;
    [SerializeField] private AudioClip _badKey;
    [SerializeField] private AudioSource _keyResults;

    public void PlaySelecctedListener(bool itWasGood)
    {
        if(itWasGood == true)
        {
            int estaGod = Random.Range(0, goodClips.Length);
            publicReaction.clip = goodClips[estaGod];
        }
        else
        {
            int estaBad = Random.Range(0, badClips.Length);
            publicReaction.clip = badClips[estaBad];
        }

        publicReaction.Play();
    }

    public void KeySounds(bool wasItCorrect) 
    {
        if (wasItCorrect == true)
        {
            _keyResults.clip = _correctKey;
        }
        else 
        {
            _keyResults.clip = _badKey;
        }

        _keyResults.Play();
    }
}
