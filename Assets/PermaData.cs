using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermaData : MonoBehaviour
{
    PlayerPrefs level;

    public TimerBar timerBar;
    public int scooreNeeded;

    private void Awake()
    {
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
                timerBar.SetMaxTime(25);
                timerBar.scoreGoal = 300;
                break;
            case 2:
                timerBar.SetMaxTime(45);
                timerBar.scoreGoal = 600;
                break;
            case 3:
                timerBar.SetMaxTime(45);
                timerBar.scoreGoal = 600;
                break;
            default:
                break;
        }
    }
}
