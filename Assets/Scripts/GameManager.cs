using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TimerBar timer;
    public ArrowSpawn arrowSpawn;

    private void Awake() => StarThisGame(false);

    public void StarThisGame(bool esta)
    {
        timer.gameObject.SetActive(esta);
        arrowSpawn.gameObject.SetActive(esta);
    }
}
