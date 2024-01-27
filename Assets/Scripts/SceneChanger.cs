using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    [Header ("Indica si se realiza el Fade al inicio de la escena")]
    [SerializeField] private bool _isSceneStart = false;

    [Header("Indica si se realiza el Fade al final de la escena")]
    [SerializeField] private bool _isSceneOver = false;

    [SerializeField] private Image _image;

    void Start()
    {
        if (_isSceneStart) { FadeOut(); }
    }


    void Update()
    {
        if(_isSceneStart) { FadeIn(); }
        
        if(Input.GetKeyUp(KeyCode.Space)) {  FadeOut(); }
    }

    void FadeIn() 
    {
        DOTweenModuleUI.DOFade(_image, 1f, 0.7f);
    }

    void FadeOut() 
    {
        DOTweenModuleUI.DOFade(_image, 0f, 0.7f);
    }
}
