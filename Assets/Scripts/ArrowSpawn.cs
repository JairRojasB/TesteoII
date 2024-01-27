using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ArrowSpawn : MonoBehaviour
{
    public List<GameObject> images;

    public int nImage = 0;

    public bool fail = false;

    private float speed = 5.0f;

    private void Start()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            images.Add(this.transform.GetChild(i).gameObject);
        }

        InitBehavior();

        ActiveOne(nImage);
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
            Debug.Log(images.Count);
            for (int i = 0; i < images.Count - 1; i++)
            {
                ResetArrows();
            }
        }

        for (int i = 0; i < images.Count; i++)
        {
            images[i].transform.localPosition -= speed * Time.deltaTime * new Vector3(1, 0, 0);
        }
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
        for (int i = 0; i < images.Count; i++)
        {
            if (i == 0) {
                images[i].transform.position = new Vector2(Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x + 0.04f, Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).y + 0.4f);
            }
            else
            {
                images[i].transform.position = images[i - 1].transform.position + new Vector3(1f, 0);
            }
            
        }
    }
}
