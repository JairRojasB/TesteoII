using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowControll : MonoBehaviour
{
    public Sprite[] ArrowIcons;

    public ArrowSpawn arrowSpawnObj;

    public SoundManager soundManager;

    private int pressValue;
    private int AIValue;

    private TimerBar timer;
    private void Start()
    {
        arrowSpawnObj = GameObject.Find("SpawnArrow2").GetComponent<ArrowSpawn>();
        soundManager = GameObject.Find("AudioManager").GetComponent<SoundManager>();
    }


    // Update is called once per frame
    void Update()
    {
        PressingButtonsC();
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
        this.gameObject.SetActive(true);
    }

    private void AreCorrect()
    {
        if (AIValue == pressValue)
        {
            arrowSpawnObj.AddN();

            if (arrowSpawnObj.nImage == arrowSpawnObj.images.Count)
            {
                soundManager.PlaySelecctedListener(true);
                arrowSpawnObj.nImage = 0;
                arrowSpawnObj.ResetGame();
            }

            arrowSpawnObj.fail = false;
            arrowSpawnObj.NextArrow();

            this.GetComponent<ArrowControll>().enabled = false;
            //Llega gente y pasas al siguiente Acto
        }
        else
        {
            soundManager.PlaySelecctedListener(false);
            timer = GameObject.FindGameObjectWithTag("TimeBar").GetComponent<TimerBar>();
            timer.slider.value -= 1;

            arrowSpawnObj.nImage = 0;
            arrowSpawnObj.ResetGame();

            Debug.Log("FALLO");
            //Ocurre evento random y se repite la secuencia de flechas
        }
    }
}