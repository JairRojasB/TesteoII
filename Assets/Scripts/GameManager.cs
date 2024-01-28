using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _txtScore;

    public TimerBar timer;
    public ArrowSpawn arrowSpawn;

    public GameObject[] people;
    public Cortina cortina;

    public int score;
    public int endThis = 0;

    public TextMeshProUGUI TxtMessage, TxtScore;
    public Button btnBack;  

    private void Awake() => StarThisGame(false);

    private void Update()
    {
        if (Camera.main.transform.position != new Vector3(0, 0, -10))
        {
            Camera.main.transform.position = new Vector3(0, 0, -10);
        }
        else return;
    }

    public void StarThisGame(bool esta)
    {
        TxtMessage.gameObject.SetActive(false);
        TxtScore.gameObject.SetActive(false);
        btnBack.gameObject.SetActive(false);

        timer.gameObject.SetActive(esta);
        arrowSpawn.gameObject.SetActive(esta);
    }

    public void RestarGame()
    {
        score = 0;
        timer.gameObject.SetActive(true);
        arrowSpawn.gameObject.SetActive(true);
    }

    public void ShakeCamera()
    {
        Camera.main.DOShakeRotation(1,5,5,5).OnComplete(()=> { Camera.main.transform.position = new Vector3(0, 0, -10); });
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
        ShakeCamera();
    }

    public void HappyPublic()
    {
        for (int i = 0; i < people.Length; i++)
        {
            people[i].GetComponent<Animator>().SetInteger("Happy", 2);
        }
    }

    public void FurriusPeople()
    {
        for (int i = 0; i < people.Length; i++)
        {
            people[i].GetComponent<Animator>().SetInteger("Sad", 1);
        }

        if (endThis == 0)
        {
            DOTween.KillAll();
            //cortina.CloseTelon();
            StartCoroutine(ShowingText());
            endThis = 1;
        }
    }



    public void ReloadGame()
    {
        SceneManager.LoadScene("Game");
    }

    IEnumerator ShowingText()
    {
        yield return new WaitForSeconds(2);

        cortina.CloseTelon();

        TxtMessage.DOFade(0, 0.1f);
        TxtScore.DOFade(0, 0.1f);
        TxtMessage.gameObject.SetActive(false);
        TxtScore.gameObject.SetActive(false);
        btnBack.gameObject.SetActive(false);

        yield  return new WaitForSeconds(3);

        TxtMessage.gameObject.SetActive(true);
        TxtScore.gameObject.SetActive(true);
        btnBack.gameObject.SetActive(true);

        TxtScore.text = score.ToString();
<<<<<<< Updated upstream
        TxtMessage.text = "You know what!, it's the game's fault";
=======
        TxtMessage.text = "You know what!, it's the game's foult";
>>>>>>> Stashed changes

        TxtMessage.DOFade(1, 1);
        TxtScore.DOFade(1, 1);
    }
}
