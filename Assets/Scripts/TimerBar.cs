using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TimerBar : MonoBehaviour
{
    public Slider slider;
    [SerializeField] private int _maxTime;
    public GameManager gameManager;

    public Image fill;
    void Start() => Starting();

    public void Starting()
    {
        slider.maxValue = _maxTime;
        slider.value = _maxTime;

        BarAnim(Color.blue);
    }

    void Update()
    {
        //Resta el tiempo reduciendo la barra
        slider.value -= Time.deltaTime;
        EndTime();
    }

    public void SetMaxTime(int time) 
    {
        slider.maxValue = time;
        slider.value = time;
    }


    private void BarAnim(Color colorMe)
    {
        fill.DOColor(Color.green, 1).OnComplete(()=> fill.DOColor(colorMe, 1).OnComplete(()=> fill.DOColor(Color.green, 1)).SetLoops(30));
    }

    public void EndTime() 
    {
        if (slider.value == 0) 
        {
            if(gameManager.score < 0)
            {
                Debug.Log("Perdiste");
                gameManager.FurriusPeople();
            }
            else
            {
                Debug.Log("Pasaste");
            }
            //Invocar método perder/generar nuevas flechas/lo que tenga que pasar cuando se acabe el tiempo
            //print("AEA");

        }
    }
}
