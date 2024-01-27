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

    private float speed = 5.0f;

    private bool ñaña;

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

        this.transform.position -= speed * Time.deltaTime * new Vector3(1, 0, 0);
    }

    private void PressingButtonsC()
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

    private void DesactivateMe()
    {
        this.transform.position = new Vector2(Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x + 20, Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).y + 0.4f);
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

    public void ResetArrrow()
    {   
        RandomArrow();
        this.transform.position = new Vector2(Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x + 0.04f, Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).y + 0.4f);
        this.gameObject.SetActive(true);
    }

    private bool AreCorrect()
    {
        bool estaCuosa = false;

        if (AIValue == pressValue)
        {
            arrowSpawnObj.AddN();

            if(arrowSpawnObj.nImage == arrowSpawnObj.images.Count) arrowSpawnObj.nImage = 0;

            arrowSpawnObj.fail = false;
            arrowSpawnObj.NextArrow();

            this.GetComponent<ArrowControll>().enabled = false;
            this.gameObject.SetActive(false);

            estaCuosa = true;
            //Llega gente y pasas al siguiente Acto
        }
        else
        {
            estaCuosa = false;
            Debug.Log("F");
            //arrowSpawnObj.fail = true;
            //DesactivateMe();
            
            //Ocurre evento random y se repite la secuencia de flechas
        }

        ñaña = estaCuosa;
        return  estaCuosa;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        Debug.Log(AIValue);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        PressingButtonsC();
    }
}