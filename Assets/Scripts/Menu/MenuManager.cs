using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private SoundManager soundManager;

    public Image BG;

    public Sprite[] bgAnim;
    public Sprite[] doorSprites;

    public Sprite[] maImg;

    [Space]
    public Slider slider;
    public Image maObj;

    public Image bgForV;
    public Button btnKapi;

    public Button btnDoor;

    private bool isClicked = false;

    private int lala = 0;

    [SerializeField] private RectTransform _bg;

    private float timein = 3.0f;
    private float insideTime = 0.07f;

    private int randomlight;

    private void Start()
    {
        ShowVolum(false);
    }

    private void Update()
    {
        timein -= Time.deltaTime;

        if (isClicked == true) btnDoor.GetComponent<Image>().sprite = doorSprites[1];

        if (timein <= 0)
        {
            StartCoroutine(Lighting());

            timein = 3.0f;
        }

        if (slider.value>0.7f && lala == 0)
        {
            StartCoroutine(Shakingdud());
        }
        else if (slider.value > 0.3f && slider.value < 0.7f) maObj.sprite = maImg[1];
        else if (slider.value <= 0.3f) maObj.sprite = maImg[0];
        
    }

    IEnumerator Shakingdud()
    {
        lala = 1;
        maObj.sprite = maImg[2];    
        yield return new WaitForSeconds(insideTime);
        maObj.sprite = maImg[3];
        yield return new WaitForSeconds(insideTime);
        maObj.sprite = maImg[4];
        lala = 0;
    }

    IEnumerator Lighting()
    {
        BG.sprite = bgAnim[0];
        yield return new WaitForSeconds(insideTime);
        BG.sprite = bgAnim[1];
        yield return new WaitForSeconds(insideTime);
        BG.sprite = bgAnim[0];
        yield return new WaitForSeconds(insideTime);
        BG.sprite = bgAnim[1];
        yield return new WaitForSeconds(insideTime);
        BG.sprite = bgAnim[0];
        yield return new WaitForSeconds(insideTime);
        BG.sprite = bgAnim[1];
        yield return new WaitForSeconds(insideTime);
        BG.sprite = bgAnim[0];
        yield return new WaitForSeconds(insideTime);
        randomlight = Random.Range(0, 11);

        if (randomlight <= 5) BG.sprite = bgAnim[1];
        else BG.sprite = bgAnim[0];
    }


    public void ChangeSprite(int n)
    {
        soundManager.PlayHover();
        switch (n)
        {
            case 0:
                btnDoor.GetComponent<Image>().sprite = doorSprites[1];
                btnDoor.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                break;
            case 1:
                btnDoor.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                break;
            default:
                break;
        }
        
    }

    public void Zooming()
    {
        isClicked = true;

        //slider.GetComponentInParent<SliderController>().HideOrShowBar(false);
        slider.gameObject.SetActive(false);
        soundManager.PlayBtnPressed();
        
        //btnDoor.transform.DOScale(new Vector2(5,5), 1).SetEase(Ease.InFlash);

        _bg.DOScale(new Vector2(5, 5), 1).SetEase(Ease.InFlash);
        //btnDoor.transform.DOMoveY(btnDoor.transform.position.y - 650, 1).SetEase(Ease.InFlash);
        _bg.DOMoveX(_bg.transform.position.x - 345, 1).SetEase(Ease.InFlash);
        _bg.DOMoveY(_bg.transform.position.y + 1450, 1).SetEase(Ease.InFlash);
        btnDoor.interactable = false;
        btnKapi.gameObject.SetActive(false);
        StartCoroutine(PerformFade());

    }

    IEnumerator PerformFade()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Game1");
    }

    public void ShowVolum(bool isShowing)
    {
        slider.gameObject.SetActive(isShowing);
        maObj.gameObject.SetActive(isShowing);
        bgForV.gameObject.SetActive(isShowing);
    }

    public void KapiApha(bool transparent)
    {
        if(transparent) btnKapi.GetComponent<Image>().color = new Color(1, 1, 1, 0.6f);
        else btnKapi.GetComponent<Image>().color = new Color(1, 1, 1, 0.3f);

    }

}
