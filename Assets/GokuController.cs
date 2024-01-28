using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GokuController : MonoBehaviour
{
    public GameObject gokuSpawn;

    private void Start()
    {
        InitAnimation();
    }
    private void InitAnimation()
    {
        this.gameObject.GetComponent<Animator>().SetInteger(0, 1);
    }
}
