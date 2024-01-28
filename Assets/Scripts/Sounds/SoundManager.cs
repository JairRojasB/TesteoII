using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    private float volumen;

    private SliderController slider;

    public AudioClip[] goodClips, badClips, menuClips, random;

    public AudioSource publicReaction;

    [Space]
    [SerializeField] private AudioSource peopleSource;
    [SerializeField] private AudioSource randomSource;

    [Space]
    [SerializeField] private AudioClip _correctKey;
    [SerializeField] private AudioClip _badKey;
    [SerializeField] private AudioSource _keyResults;

    [Space]
    [SerializeField] private AudioSource hoverSource;
    [SerializeField] private AudioSource pressedSource;

    private void Awake()
    {
        slider = GameObject.FindObjectOfType<SliderController>();
    }

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
        publicReaction.volume = PlayerPrefs.GetFloat("volumenData");
    }

    public void KeySounds(bool wasItCorrect) 
    {
        if (wasItCorrect == true) _keyResults.clip = _correctKey;
        else _keyResults.clip = _badKey;

        _keyResults.Play();
        _keyResults.volume = PlayerPrefs.GetFloat("volumenData");
    }

    public void PlayHover()
    {
        if (hoverSource != null) 
        {
            hoverSource.clip = menuClips[0];
            hoverSource.Play();
            hoverSource.volume = PlayerPrefs.GetFloat("volumenData");
        }
    }

    public void PlayBtnPressed()
    {
        pressedSource.clip = menuClips[1];
        pressedSource.Play();
        pressedSource.volume = PlayerPrefs.GetFloat("volumenData");
    }
}
