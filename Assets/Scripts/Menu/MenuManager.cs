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

    public Button btnDoor;

    private bool isClicked = false;

    [SerializeField] private RectTransform _bg;

    private float timein = 3.0f;
    private float insideTime = 0.07f;

    private void Update()
    {
        timein -= Time.deltaTime;

        if (isClicked == true) btnDoor.GetComponent<Image>().sprite = doorSprites[1];

        if (timein <= 0)
        {
            StartCoroutine(Lighting());

            timein = 3.0f;
        }
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
        BG.sprite = bgAnim[1];
    }


    public void ChangeSprite(int n)
    {
        soundManager.PlayHover();
        btnDoor.GetComponent<Image>().sprite = doorSprites[n];
    }

    public void Zooming()
    {
        isClicked = true;

        soundManager.PlayBtnPressed();

        //btnDoor.transform.DOScale(new Vector2(5,5), 1).SetEase(Ease.InFlash);
        _bg.DOScale(new Vector2(5, 5), 1).SetEase(Ease.InFlash);
        //btnDoor.transform.DOMoveY(btnDoor.transform.position.y - 650, 1).SetEase(Ease.InFlash);
        _bg.DOMoveX(_bg.transform.position.x - 345, 1).SetEase(Ease.InFlash);
        _bg.DOMoveY(_bg.transform.position.y + 1450, 1).SetEase(Ease.InFlash);
        btnDoor.interactable = false;
        StartCoroutine(PerformFade());
    }

    IEnumerator PerformFade()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Game");
    }
}
