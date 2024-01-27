using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private SoundManager soundManager;

    public Button btnDoor;

    public Sprite[] doorSprites;

    private bool isClicked = false;

    [SerializeField] private RectTransform _bg;

    private void Update()
    {
        if (isClicked == true)
        {
            btnDoor.GetComponent<Image>().sprite = doorSprites[1];
        }
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
