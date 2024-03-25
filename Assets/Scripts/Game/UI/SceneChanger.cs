using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    [Header ("Indica si se realiza el Fade al inicio de la escena")]
    [SerializeField] private bool _isSceneStart = false;
    [SerializeField] private bool _canStartTransparent = false;

    [SerializeField] private Image _image;

    public GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (_isSceneStart) { ScreenFadeToTransparent(); } else if (_canStartTransparent == true) { DOTweenModuleUI.DOFade(_image, 0f, 0f); }
    }

    public void ScreenFadeToBlack() 
    {
        DOTweenModuleUI.DOFade(_image, 1f, 0.7f);
    }

    public void ScreenFadeToTransparent() 
    {
        DOTweenModuleUI.DOFade(_image, 0f, 0.7f).OnComplete(()=> { gameManager.StarThisGame(true); });
    }

    public void SceenFaceToSolid()
    {
        DOTweenModuleUI.DOFade(_image, 1f, 0.7f).OnComplete(() => { 
            gameManager.StarThisGame(false);
            DOTween.KillAll();  
        });
    }
}
