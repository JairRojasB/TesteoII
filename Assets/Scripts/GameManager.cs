using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TimerBar timer;
    public ArrowSpawn arrowSpawn;

    public void StarThisGame()
    {
        timer.Starting();
        arrowSpawn.StartingGame();
    }
}
