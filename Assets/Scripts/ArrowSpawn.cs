using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ArrowSpawn : MonoBehaviour
{
    public List<GameObject> images;

    public int nImage = 0;

    public bool fail = false;

    private void Start()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            images.Add(this.transform.GetChild(i).gameObject);
        }

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
            images[i].gameObject.SetActive(true);
            images[i].gameObject.GetComponent<ArrowControll>().RandomArrow();
            ActiveOne(nImage);
        }

        fail = false;
    }

    //Subir un elemento de la lista NO TOCAR
    public void AddN() => nImage += 1;

    //Comportamiento inicial
    private void InitBehavior()
    {
        for (int i = 1; i < images.Count; i++)
        {
            images[i].transform.position = images[i - 1].transform.position + new Vector3(1f, 0);
        }
    }
}
