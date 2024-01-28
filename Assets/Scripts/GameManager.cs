using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public TimerBar timer;
    public ArrowSpawn arrowSpawn;

    private void Awake() => StarThisGame(false);

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ShakeCamera();
        }
    }
    public void StarThisGame(bool esta)
    {
        timer.gameObject.SetActive(esta);
        arrowSpawn.gameObject.SetActive(esta);
    }

    public void ShakeCamera()
    {
        Camera.main.DOShakeRotation(1,5,5,5).OnComplete(()=>Camera.main.transform.position = new Vector3(0,0,-10));
    }
}
