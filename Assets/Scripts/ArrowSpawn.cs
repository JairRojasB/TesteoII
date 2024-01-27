using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ArrowSpawn : MonoBehaviour
{
    public Image[] images;

    private int nImage = 0;

    public bool fail = false;
    private void Start()
    {
        ActiveOne(nImage);
    }

    public void ActiveDesactive(bool activating, int n)
    {
        if (activating)
        {
            images[n].gameObject.GetComponent<ArrowControll>().enabled = true;
        }
        else
        {
            images[n].gameObject.GetComponent<ArrowControll>().enabled = false;
            images[n].gameObject.GetComponent<ArrowControll>().RandomArrow();
        }
    }

    public void ActiveOne(int n)
    {
        for (int i = 0; i < images.Length; i++)
        {
            ActiveDesactive(false, i);
        }

        ActiveDesactive(true, n);
    }

    private void Update()
    {
        /*if (fail)
        {
            for (int i = 0; i < images.Length; i++)
            {
                ActiveDesactive(false, i);
            }
        }*/
    }
}
