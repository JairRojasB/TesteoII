using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GokuController : MonoBehaviour
{
    public GameObject gokuSpawn;
    [SerializeField] private Animator _gokuAnim;

    private void Start()
    {
        _gokuAnim = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if (_gokuAnim != null) 
        {
            if(Input.GetKeyDown(KeyCode.G)) 
            {
                InitAnimation();
            }
        }   
    }



    private void InitAnimation()
    {
        _gokuAnim.SetInteger("isTp", 1);
    }
}
