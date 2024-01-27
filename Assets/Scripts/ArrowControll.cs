using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowControll : MonoBehaviour
{
    public Sprite[] ArrowIcons;

    public ArrowSpawn arrowSpawnObj;

    public BoxCollider2D boxCollider;

    private int pressValue;
    private int AIValue;

    private bool safeZone = false;
    
    private void Start()
    {
        RandomArrow();
        arrowSpawnObj = GameObject.Find("SpawnArrow2").GetComponent<ArrowSpawn>();
        boxCollider = GameObject.Find("Hitbox").GetComponent<BoxCollider2D>();
    }


    // Update is called once per frame
    void Update()
    {
        PressingButtonsC();
    }

    private void PressingButtonsC()
    {
        if(safeZone == true)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                pressValue = 0;
                AreCorrect();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                pressValue = 1;
                AreCorrect();
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                pressValue = 2;
                AreCorrect();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                pressValue = 3;
                AreCorrect();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                arrowSpawnObj.fail = true;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                arrowSpawnObj.fail = true;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                arrowSpawnObj.fail = true;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                arrowSpawnObj.fail = true;
            }   
        }
    }

    private void DesactivateMe()
    {
        this.transform.position = new Vector2(Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x + 20, Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).y + 0.4f);
        safeZone = false;
        RandomArrow();
    }

    public void RandomArrow()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = ArrowIcons[Random.Range(0, ArrowIcons.Length)];

        for (int i = 0; i < ArrowIcons.Length; i++)
        {
            if (this.gameObject.GetComponent<SpriteRenderer>().sprite == ArrowIcons[i]) AIValue = i;
        }
    }

    private void AreCorrect()
    {
        if (AIValue == pressValue)
        {
            arrowSpawnObj.AddN();

            if(arrowSpawnObj.nImage == arrowSpawnObj.images.Count) arrowSpawnObj.nImage = 0;

            arrowSpawnObj.ActiveOne(arrowSpawnObj.nImage);
            this.gameObject.SetActive(false);
            
            //Llega gente y pasas al siguiente Acto
        }
        else if (AIValue != pressValue)
        {         
            arrowSpawnObj.fail = true;
            //DesactivateMe();
            
            //Ocurre evento random y se repite la secuencia de flechas
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        safeZone = true;
        PressingButtonsC();
    }
}