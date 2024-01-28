using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public GameObject ScorePanelObj;

    public GameObject[] Conteiners;

    string puntaje;
    string thisName;

    int nValue;

    public void LeaderBoard()
    {
        for (int i = 0; i < ScorePanelObj.transform.childCount; i++)
        {
            if(i == nValue)
            {
                Conteiners[i].transform.GetChild(0).GetComponent<TextMesh>().text = thisName;
                Conteiners[i].transform.GetChild(1).GetComponent<TextMesh>().text = puntaje;
            }
        }
    }

    public void LoadInfo()
    {
        puntaje = PlayerPrefs.GetString("Puntaje");
        thisName = PlayerPrefs.GetString("Name");
    }

    public void SaveInfo()
    {
        PlayerPrefs.SetString("Puntje" , puntaje);
        PlayerPrefs.SetString("Name", thisName);
    }


}
