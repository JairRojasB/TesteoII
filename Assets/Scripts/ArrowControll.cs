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
    
    private void Start()
    {
        RandomArrow();
        arrowSpawnObj = GameObject.Find("SpawnArrow").GetComponent<ArrowSpawn>();
        boxCollider = GameObject.Find("Collision").GetComponent<BoxCollider2D>();
    }
   

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.LeftArrow)){
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
        }*/

        #region detecionConLaColision

        // Obtiene la posición actual del Box Collider 2D en el canvas
        Vector3 boxColliderPosition = boxCollider.transform.position;

        // Obtiene el tamaño del Box Collider 2D
        Vector2 boxColliderSize = boxCollider.size;

        // Obtiene todas las imágenes en el canvas
        Image[] images = FindObjectsOfType<Image>();

        // Verifica si cada imagen se superpone con el Box Collider 2D
        foreach (Image image in images)
        {
            // Obtiene la posición actual de la imagen en el canvas
            Vector3 imagePosition = image.transform.position;

            // Obtiene el tamaño de la imagen
            Vector2 imageSize = image.rectTransform.sizeDelta;

            // Verifica si la imagen se superpone con el Box Collider 2D
            if (imagePosition.x + imageSize.x / 2 > boxColliderPosition.x - boxColliderSize.x / 2 &&
                imagePosition.x - imageSize.x / 2 < boxColliderPosition.x + boxColliderSize.x / 2 &&
                imagePosition.y + imageSize.y / 2 > boxColliderPosition.y - boxColliderSize.y / 2 &&
                imagePosition.y - imageSize.y / 2 < boxColliderPosition.y + boxColliderSize.y / 2)
            {
                Debug.Log("La imagen " + image.name + " está dentro del área del Box Collider 2D");
                PressingButtonsC();
            }
            else
            {
                PressingButtonsW();
            }
        }

        #endregion
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

    private void PressingButtonsW()
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
            arrowSpawnObj.AddN();

            if(arrowSpawnObj.nImage == arrowSpawnObj.images.Count) arrowSpawnObj.nImage = 0;

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