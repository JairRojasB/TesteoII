using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SusiControl : MonoBehaviour
{
    [SerializeField] private Animator _susiAnim;
    [SerializeField] private bool _willSheYeet = false;

    private void Start()
    {
        _susiAnim = gameObject.GetComponent<Animator>();
        if (_willSheYeet == true)
        {
            if (_susiAnim != null) { _susiAnim.SetBool("Butt", _willSheYeet); }
        }
    }
}
