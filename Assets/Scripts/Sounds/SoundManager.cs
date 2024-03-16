using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    private float volumen;

    private Slider slider;

    public AudioClip[] goodClips, badClips, menuClips, random;

    public AudioSource publicReaction;

    public bool shutUpSusi = false;

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

    [Space]
    [SerializeField] private AudioSource susiSource;
    [SerializeField] private AudioClip[] susiClips;

    [Space]
    [SerializeField] private AudioSource[] clapsSources;
    [SerializeField] private AudioClip[] clapsClips;

    [Space]
    public List<AudioSource> audioSources;


    private void Awake()
    {
        slider = GameObject.Find("SliderAudio").GetComponent<Slider>();
    }
    private void Start()
    {
        DetectAllVolum();
        slider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("volumenData");
        if(SceneManager.GetActiveScene().name == "Game") StartCoroutine(PlaySusi());


    }
    private void Update()
    {
        ChangeAllVolum();
    }

    IEnumerator PlaySusi()
    {
        SusiRandomVoice();
        yield return new WaitForSeconds(5);
        PlaySusi();
    }

    public void PlayClaps()
    {
        for (int i = 0; i < clapsSources.Length; i++)
        {
            clapsSources[i].clip = clapsClips[i];
            clapsSources[i].Play();
        }
    }

    private void SusiRandomVoice()
    {
        int esta = Random.Range(0, susiClips.Length-1);

        susiSource.clip = susiClips[esta];
        susiSource.Play();
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

    private void DetectAllVolum()
    {
        audioSources.Clear();

        AudioSource[] allAudioSources = GameObject.FindObjectsOfType<AudioSource>();

        for (int i = 0; i < allAudioSources.Length; i++)
        {
            audioSources.Add(allAudioSources[i]);
        }
    }

    public void ChangeAllVolum()
    {
        for (int i = 0; i < audioSources.Count; i++)
        {
            audioSources[i].volume = PlayerPrefs.GetFloat("volumenData");
        }
    }

}
