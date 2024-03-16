using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public SoundManager soundManager;

    public GameObject sliderPrefab;

    PlayerPrefs volumenData;

    private void Awake()
    {
        soundManager = GameObject.FindObjectOfType<SoundManager>();
        HideOrShowBar(true);
    }

    private void Update()
    {
        if(sliderPrefab.gameObject.activeInHierarchy) PlayerPrefs.SetFloat("volumenData", this.transform.GetComponentInChildren<Slider>().value);
    }

    public void HideOrShowBar(bool isShowing) => this.gameObject.SetActive(isShowing);
}