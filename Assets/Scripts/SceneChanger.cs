using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    [Header ("Indica si se realiza el Fade al inicio de la escena")]
    [SerializeField] private bool _isSceneStart = false;

    [SerializeField] private Image _image;

    void Start()
    {
        if (_isSceneStart) { FadeToTransparent(); } else { DOTweenModuleUI.DOFade(_image, 0f, 0f); }
    }


    void Update()
    { 

    }

    void FadeToBlack() 
    {
        DOTweenModuleUI.DOFade(_image, 1f, 0.7f);
    }

    void FadeToTransparent() 
    {
        DOTweenModuleUI.DOFade(_image, 0f, 0.7f);
    }
}
