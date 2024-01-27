using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetecInteraction : MonoBehaviour
{
  /*  public BoxCollider2D boxCollider;

    void Update()
    {
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
            }
        }
    }*/
}
