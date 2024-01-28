using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _txtScore;

    public TimerBar timer;
    public ArrowSpawn arrowSpawn;

    public Sprite[] people;

    public int score;

    private void Awake() => StarThisGame(false);

    public void StarThisGame(bool esta)
    {
        timer.gameObject.SetActive(esta);
        arrowSpawn.gameObject.SetActive(esta);
    }

    public void ShakeCamera()
    {
        Camera.main.DOShakeRotation(1,5,5,5).OnComplete(()=>Camera.main.transform.position = new Vector3(0,0,-10));
    }

    public void AddScore()
    {
        score += 5;
        _txtScore.text = score.ToString();
    }

    public void RestScore()
    {
        score -= 35;
        _txtScore.text = score.ToString();
    }
}
