using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PointCounter : MonoBehaviour
{
    public static PointCounter pointcounter;
    [SerializeField] private int counterS=0;
    [SerializeField] private int counterG=0;
    [SerializeField] private TextMeshProUGUI scoreText;
    void Awake(){
        pointcounter=this;
    }
    void Start()
    {
        StartCoroutine(CheckforVictory());
    }

    public void AddingPSmurfs()
    {
        counterS++;
    }
    public void AddingPGargamel()
    {
        counterG++;
    }

    IEnumerator CheckforVictory()
    {   while(true)
        {
            if(counterS==PlayerPrefs.GetInt("Bushes"))
            {
                SceneManager.LoadScene("SsVictory", LoadSceneMode.Single);
            }
            else if(counterG==PlayerPrefs.GetInt("Smurfs"))
            {
                SceneManager.LoadScene("GsVictory", LoadSceneMode.Single);
            }

            scoreText.text = "Punkty Smerfów: " + counterS + " / " + PlayerPrefs.GetInt("Bushes") + " | Punkty Gargamelów " + counterG + " / " + PlayerPrefs.GetInt("Smurfs");
        yield return new WaitForSeconds(1f);
        }
    }
}

