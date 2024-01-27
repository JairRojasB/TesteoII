using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowControll : MonoBehaviour
{
    public Sprite[] ArrowIcons;

    public ArrowSpawn arrowSpawnObj;

    private int pressValue;
    private int AIValue;

    //private bool wasPressed = false;

    
    private void Start()
    {
        RandomArrow();
        arrowSpawnObj = GameObject.Find("SpawnArrow").GetComponent<ArrowSpawn>();
    }
   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)){
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

    public void RandomArrow()
    {
        this.gameObject.GetComponent<Image>().sprite = ArrowIcons[Random.Range(0, ArrowIcons.Length)];

        for (int i = 0; i < ArrowIcons.Length; i++)
        {
            if (this.gameObject.GetComponent<Image>().sprite == ArrowIcons[i]) AIValue = i;
        }
    }

    private void AreCorrect()
    {
        if (AIValue == pressValue)
        {
            //arrowSpawnObj.fail = false;
            arrowSpawnObj.AddN();

            if(arrowSpawnObj.nImage == arrowSpawnObj.images.Count)
            {
                arrowSpawnObj.nImage = 0;
            }

            arrowSpawnObj.ActiveOne(arrowSpawnObj.nImage);
            this.gameObject.SetActive(false);
            
            //Llega gente y pasas al siguiente Acto
        }
        else if (AIValue != pressValue)
        {         
            arrowSpawnObj.fail = true;
            
            //Ocurre evento random y se repite la secuencia de flechas
        }
    }    
}