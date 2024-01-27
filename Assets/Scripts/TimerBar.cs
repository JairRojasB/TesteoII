using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour
{
    public Slider slider;
    [SerializeField] private int _maxTime;

    void Start() => Starting();

    public void Starting()
    {
        slider.maxValue = _maxTime;
        slider.value = _maxTime;
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

    public void EndTime() 
    {
        if (slider.value == 0) 
        {
            //Invocar método perder/generar nuevas flechas/lo que tenga que pasar cuando se acabe el tiempo
            //print("AEA");
        }
    }
}
