using System.Collections;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
public class GameManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _txtScore;

    [Space]
    [SerializeField] private GameObject corgiPrefb;
    [SerializeField] private GameObject kapibaraPrefb;

    //public PermaData permaData;

    public TimerBar timer;
    public ArrowSpawn arrowSpawn;

    public GameObject[] people;
    public Cortina cortina;
    
    [Space]
    public SpriteRenderer[] lights;

    public int score;
    public int endThis = 0;

    public TextMeshProUGUI TxtMessage, TxtScore;
    public Button btnBack;

    private string lose1;
    private string exito1;

    public Animator genteAnim;
    public bool fullPublic = false;
    public int maxScore;

    private bool camShaking = false;

    private void Awake() {
        StarThisGame(false);

        lose1 = "Este es tu #1er intento. Trata de no cagarla";
        //lose2 = "Intento #2. Ya no tiene dignidad, basura. A ver si al menos usas tu odio";

        exito1 = "Este es tu intento #1. Encuentra tu dignidad y úsala";
    }
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Game1")
        {
            maxScore = 300;
        }
        else if (SceneManager.GetActiveScene().name == "Game2")
        {
            maxScore = 500;
        }

        Instantiate(kapibaraPrefb, new Vector3(0, 0, 0), Quaternion.identity);

        TxtMessage.DOFade(0, 0.1f);
        TxtScore.DOFade(0, 0.1f);
        TxtMessage.gameObject.SetActive(false);
        TxtScore.gameObject.SetActive(false);
        btnBack.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("TimeBar") != null) 
        {
            maxScore = GameObject.FindGameObjectWithTag("TimeBar").GetComponent<TimerBar>().scoreGoal;
        }
                
        if (score >= 150) 
        {
            genteAnim.SetBool("MidPublic", true);
        }
        else
        {
            genteAnim.SetBool("MidPublic", false);
        }

        if (score >= maxScore)
        {
            genteAnim.SetBool("FullPublic", true);
        }
        else
        {
            genteAnim.SetBool("FullPublic", false);
        }

        if (Camera.main.transform.position != new Vector3(0, 0, -10)) Camera.main.transform.position = new Vector3(0, 0, -10);
        else return;
    }    

    public void StarThisGame(bool esta)
    {
        TxtMessage.gameObject.SetActive(false);
        TxtScore.gameObject.SetActive(false);
        btnBack.gameObject.SetActive(false);

        timer.gameObject.SetActive(esta);
        arrowSpawn.gameObject.SetActive(esta);

        /*for (int i = 0; i < lights.Length; i++)
        {
            lights[i].DOFade(0.43f, 0.5f).OnComplete(() => { lights[i].DOFade(0.57f, 0.5f); }).SetLoops(15);
        }*/
    }

    public void RestarGame()
    {
        score = 0;
        timer.d = 0;
        timer.gameObject.SetActive(true);
        arrowSpawn.gameObject.SetActive(true);
        
    }

    public void ShakeCamera()
    {
        camShaking = true;
        Camera.main.DOShakeRotation(1,5,5,5).OnComplete(()=> { Camera.main.transform.position = new Vector3(0, 0, -10); camShaking = false; });
    }

    public void AddScore()
    {
        score += 5;
        _txtScore.text = score.ToString();
    }

    public void RestScore()
    {
        score -= 25;
        _txtScore.text = score.ToString();
        
        if(!camShaking) ShakeCamera();
    }

    public void HappyPublic()
    {
        for (int i = 0; i < people.Length; i++)
        {
            people[i].GetComponent<Animator>().SetInteger("Happy", 2);
        }

        if(endThis == 0)
        {
            if(SceneManager.GetActiveScene().name == "Game1")
            {
                TxtMessage.text = exito1;
                StartCoroutine(ShowingText());
            }

            DOTween.KillAll();
            cortina.CloseTelon();
            
            endThis = 1;
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
            cortina.CloseTelon();

            if (SceneManager.GetActiveScene().name == "Game1")
            {
                TxtMessage.text = lose1;
                StartCoroutine(ShowingText());
            }
            else
            {
                btnBack.gameObject.SetActive(true);
            }
            endThis = 1;
        }
    }

    public void ReloadGame()
    {
        if(SceneManager.GetActiveScene().name == "Game1")
        {
            SceneManager.LoadScene("Game2");
        }else if(SceneManager.GetActiveScene().name == "Game2"){
            SceneManager.LoadScene("Menu");
        }
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

        TxtMessage.DOFade(1, 1);
        TxtScore.DOFade(1, 1);
    }
}
