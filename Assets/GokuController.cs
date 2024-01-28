using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GokuController : MonoBehaviour
{
    public GameObject gokuSpawn;
    [SerializeField] private Animator _gokuAnim;
    [SerializeField] private bool _willHeYeet = false;

    private void Start()
    {
        _gokuAnim = gameObject.GetComponent<Animator>();
        if (_willHeYeet == true) 
        {
            if (_gokuAnim != null) { _gokuAnim.SetInteger("isTp", 1); }
        }
    }
}
