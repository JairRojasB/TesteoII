using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cortina : MonoBehaviour
{
    [SerializeField] private Sprite _cortinaAbierta;
    [SerializeField] private Sprite _cortinaCerrado;
    [SerializeField] private SceneChanger _fade;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AbrirCortina());
    }

    public void CloseTelon()
    {
        StartCoroutine(CloseCortina());
    }

    IEnumerator AbrirCortina() 
    {
        yield return new WaitForSeconds(0.5f);

        gameObject.GetComponent<Image>().sprite = _cortinaAbierta;

        yield return new WaitForSeconds(0.5f);

        gameObject.transform.DOScale(new Vector2(5, 5), 0.5f).SetEase(Ease.InFlash);

        yield return new WaitForSeconds(0.5f);

        if (_fade != null) { _fade.ScreenFadeToTransparent(); } 
    }

    IEnumerator CloseCortina()
    {
        yield return new WaitForSeconds(0.5f);

        if (_fade != null) { _fade.ScreenFadeToBlack(); }

        yield return new WaitForSeconds(0.5f);

        gameObject.transform.DOScale(new Vector2(1, 1), 0.5f).SetEase(Ease.InFlash);

        yield return new WaitForSeconds(0.7f);

        gameObject.GetComponent<Image>().sprite = _cortinaCerrado;
        if (_fade != null) { _fade.SceenFaceToSolid(); }
    }
}
