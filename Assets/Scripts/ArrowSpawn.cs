using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;

public class ArrowSpawn : MonoBehaviour
{
    public List<GameObject> images;

    public int nImage = 0;

    public bool fail = false;

    private void Awake()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            images.Add(this.transform.GetChild(i).gameObject);
        }
    }
    private void Start() => StartingGame();

    public void StartingGame()
    {
        nImage = 0;
        InitBehavior();
        ActiveOne(nImage);
    }

    public void NextArrow()
    {
        ActiveArrows(nImage);
    }

    public void ActiveOne(int n)
    {
        for (int i = 0; i < images.Count; i++) DesactiveArrows(i);

        ActiveArrows(n);
    }

    public void ActiveArrows(int n) => images[n].GetComponent<ArrowControll>().enabled = true;

    public void DesactiveArrows(int n) => images[n].GetComponent<ArrowControll>().enabled = false;

    public void ResetGame()
    {

        nImage = 0;

        for (int i = 0; i < images.Count; i++)
        {
            InitBehavior();
            images[i].SetActive(true);
            images[i].GetComponent<ArrowControll>().RandomArrow();
            ActiveOne(nImage);
        }

        fail = false;
    }

    //Subir un elemento de la lista NO TOCAR
    public void AddN() => nImage += 1;

    //Comportamiento inicial
    private void InitBehavior()
    {
        for (int i = 0; i < images.Count; i++)
        {
            images[i].GetComponent<SpriteRenderer>().color = Color.white;
            images[i].transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            if (i >= 1)
            {
                images[i].transform.position = images[i - 1].transform.position + new Vector3(1.3f, 0);
            }
        }

        AnimIcon();
    }

    private void AnimIcon()
    {
        for (int i = 0; i < images.Count; i++)
        {
            images[i].transform.DOScale(1, 0.5f).SetEase(Ease.InOutElastic);
            images[i].GetComponent<ArrowControll>().ChangeState();
        }
    }
}
