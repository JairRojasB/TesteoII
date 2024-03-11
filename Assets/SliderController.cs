using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public SoundManager soundManager;

    public GameObject sliderPrefab;

    PlayerPrefs volumenData;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        soundManager = GameObject.FindObjectOfType<SoundManager>();
    }

    private void Update()
    {
        if (sliderPrefab == null) sliderPrefab = GameObject.Find("SliderAudio");
        if(sliderPrefab.gameObject.activeInHierarchy) PlayerPrefs.SetFloat("volumenData", this.transform.GetComponentInChildren<Slider>().value);
    }

    public void HideOrShowBar(bool isShowing) => this.gameObject.SetActive(isShowing);
}