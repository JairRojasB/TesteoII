using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowControll : MonoBehaviour
{

    public Sprite[] ArrowIcons;

    public ArrowSpawn arrowSpawnObj;

    private int pressValue;
    private int AIValue;

    private bool wasPressed = false;

    
    private void Start()
    {
        RandomArrow();
        arrowSpawnObj = GameObject.Find("SpawnArrow").GetComponent<ArrowSpawn>();
    }
    private void RandomArrow()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = ArrowIcons[Random.Range(0, ArrowIcons.Length)];
        
        switch (ArrowIcons.Length)
        {
            case 0:
                if (this.gameObject.GetComponent<SpriteRenderer>().sprite == ArrowIcons[0])
                {
                    AIValue = 0;
                }
                break;
            case 1:
                if (this.gameObject.GetComponent<SpriteRenderer>().sprite == ArrowIcons[1])
                {
                    AIValue = 1;
                }
                break;
            case 2:
                if (this.gameObject.GetComponent<SpriteRenderer>().sprite == ArrowIcons[2])
                {
                    AIValue = 2;
                }
                break;
            case 3:
                if (this.gameObject.GetComponent<SpriteRenderer>().sprite == ArrowIcons[3])
                {
                    AIValue = 3;
                }
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)){
            pressValue = 0;
        }else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            pressValue = 1;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            pressValue = 2;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            pressValue = 3;
        }

        if(AIValue == pressValue && wasPressed == false)
        {
            wasPressed = true;
            arrowSpawnObj.fail = false;
        }
        else if (AIValue != pressValue && wasPressed == false)
        {
            wasPressed = true;
            arrowSpawnObj.fail = true;
        }
    }
}