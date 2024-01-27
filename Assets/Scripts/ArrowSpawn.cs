using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ArrowSpawn : MonoBehaviour
{
    public Image[] images;

    public int nImage = 0;

    public bool fail = false;
    private void Start()
    {
        ActiveOne(0);
    }

    public void ActiveOne(int n)
    {
        for (int i = 0; i < images.Length; i++) ActiveDesactive(false, i);

        ActiveDesactive(true, n);
    }

    public void ActiveDesactive(bool activating, int n)
    {
        if (activating == true) images[n].gameObject.GetComponent<ArrowControll>().enabled = true;
        else images[n].gameObject.GetComponent<ArrowControll>().enabled = false;
    }

    private void ResetArrows()
    {
        for (int i = 0; i < images.Length; i++)
        {
            images[i].gameObject.SetActive(true);
            ActiveDesactive(true, i);
            images[i].gameObject.GetComponent<ArrowControll>().RandomArrow();
            images[i].gameObject.GetComponent<ArrowControll>().ResetControll();
            ActiveOne(0);
        }
    }


    private void Update()
    {
        if (fail == true)
        {
            for (int i = 0; i < images.Length; i++)
            {
                ActiveDesactive(false, i);
                ResetArrows();
            }
            nImage = 0;
        }

        if (nImage == images.Length)
        {
            for (int i = 0; i < images.Length; i++)
            {
                ActiveDesactive(false, i);
                ResetArrows();
            }
        }

        Debug.Log(nImage + "    " + images.Length);
    }
}
