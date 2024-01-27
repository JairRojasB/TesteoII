using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MenuManager : MonoBehaviour
{
    public Button btnDoor;

    public Sprite[] doorSprites;

    private bool isClicked = false;
   public void ChangeSprite(int n)
    {
        btnDoor.GetComponent<Image>().sprite = doorSprites[n];
    }

    private void Update()
    {
        if (isClicked == true)
        {
            btnDoor.GetComponent<Image>().sprite = doorSprites[1];
        }
        
    }

    public void Zooming()
    {
        isClicked = true;
        btnDoor.transform.DOScale(new Vector2(15,60), 1).SetEase(Ease.InFlash);
        btnDoor.transform.DOMoveY(btnDoor.transform.position.y + 440, 1).SetEase(Ease.InFlash);
        btnDoor.interactable = false;
    }
}
