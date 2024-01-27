using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ArrowSpawn : MonoBehaviour
{
    public Image[] images;

    public bool fail = false;
    private void Start()
    {
        for (int i = 0; i < images.Length; i++)
        {
            ActiveDesactive(false, i);
        }

        ActiveDesactive(true, 0);
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
        }
    }

    private void Update()
    {
        if (fail)
        {
            for (int i = 0; i < images.Length; i++)
            {
                ActiveDesactive(false, i);
            }
        }
        else
        {

        }
    }
}
