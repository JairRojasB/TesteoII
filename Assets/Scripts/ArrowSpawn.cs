using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ArrowSpawn : MonoBehaviour
{
    public List<Image> images;

    public int nImage = 0;

    public bool fail = false;
    private void Start()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            images.Add(this.transform.GetChild(i).GetComponent<Image>());
        }

        ActiveOne(nImage);
    }

    public void ActiveOne(int n)
    {
        for (int i = 0; i < images.Count; i++) DesactiveArrows(i);

        ActiveArrows(n);
    }

    public void ActiveArrows(int n) => images[n].gameObject.GetComponent<ArrowControll>().enabled = true;

    public void DesactiveArrows(int n) => images[n].gameObject.GetComponent<ArrowControll>().enabled = false;

    public void ResetArrows()
    {
        nImage = 0;

        for (int i = 0; i < images.Count - 1; i++)
        {
            images[i].gameObject.SetActive(true);
            images[i].gameObject.GetComponent<ArrowControll>().RandomArrow();
            ActiveOne(nImage);
        }

        fail = false;   
    }


    private void Update()
    {
        if (fail == true)
        {
            for (int i = 0; i < images.Count - 1; i++)
            {
                ResetArrows();
            }
        }

        if (nImage > images.Count)
        {
            for (int i = 0; i < images.Count - 1; i++)
            {
                ResetArrows();
            }
        }

        Debug.Log(nImage + "    " + images.Count);
    }

    public void AddN() => nImage += 1;
}
