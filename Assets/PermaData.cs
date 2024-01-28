using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermaData : MonoBehaviour
{
    PlayerPrefs level;

    public TimerBar timerBar;
    public GameManager gameManager;
    public int scooreNeeded;

    private void Awake()
    {
        PlayerPrefs.SetInt("level", 1);
        DontDestroyOnLoad(this.gameObject);
        Benginin(PlayerPrefs.GetInt("level"));
    }

    public void Benginin(int setLevel)
    {
        PlayerPrefs.SetInt("level",setLevel);

        int thisLevel = PlayerPrefs.GetInt("level");
        switch (thisLevel)
        {
            case 1:
                //malo1
                timerBar.SetMaxTime(25);
                timerBar.scoreGoal = 250;
                //gameManager.TxtMessage.text = "Este es tu #1er intento. Trata de no cagarla";
                break;
            case 2:
                //bueno
                timerBar.SetMaxTime(30);
                timerBar.scoreGoal = 400;
                //gameManager.TxtMessage.text = "Este es tu intento #1. Encuentra tu dignidad y úsala"; 
                break;
            case 3:
                timerBar.SetMaxTime(45);
                timerBar.scoreGoal = 600;                
                //gameManager.TxtMessage.text = "La cagaste";
                break;
            case 4:
                break;
            default:
                break;
        }
    }

    public void DefineText(int setLevel)
    {
        switch (setLevel)
        {
            case 1:
                //malo1
                gameManager.TxtMessage.text = "Este es tu #1er intento. Trata de no cagarla";
                PlayerPrefs.SetInt("level", 3);
                break;
            case 2:
                //bueno
                gameManager.TxtMessage.text = "Este es tu intento #1. Encuentra tu dignidad y úsala";
                PlayerPrefs.SetInt("level", 3);
                break;
            case 3:
                //malo2
                //gameManager.TxtMessage.text = "La cagaste";
                break;
            case 4:
                break;
            default:
                break;
        }
    }
}
