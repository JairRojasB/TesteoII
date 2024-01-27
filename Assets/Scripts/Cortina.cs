using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cortina : MonoBehaviour
{
    [SerializeField] private Sprite _cortinaAbierta;
    [SerializeField] private SceneChanger _fade;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AbrirCortina());
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
