using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public SoundManager soundManager;

    PlayerPrefs volumenData;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        soundManager = GameObject.FindObjectOfType<SoundManager>();
    }

    private void Update()
    {
        if(this.transform.GetChild(0).gameObject.activeInHierarchy) PlayerPrefs.SetFloat("volumenData", this.transform.GetComponentInChildren<Slider>().value);
    }

    public void HideOrShowBar(bool isShowing) => this.gameObject.SetActive(isShowing);
}