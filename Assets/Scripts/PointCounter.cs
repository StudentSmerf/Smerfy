using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

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
                if(PlayerPrefs.GetInt("Test") == 1){
                    Debug.Log("S won, S=" + PlayerPrefs.GetInt("Smurfs") + ", B="+ PlayerPrefs.GetInt("Bushes") + ", G="+ PlayerPrefs.GetInt("Gargamels") + ", points S = " + counterS + ", points G = " + counterG);
                    TextWriter tsw = new StreamWriter(@"C:\Results\Results" + PlayerPrefs.GetInt("FileNumber") + ".txt", true);
                    tsw.WriteLine(PlayerPrefs.GetInt("Smurfs") + "\t" + PlayerPrefs.GetInt("Bushes") + "\t" + PlayerPrefs.GetInt("Gargamels") + "\t" + counterS + "\t" + counterG);
                    tsw.Close();
                }
                SceneManager.LoadScene("SsVictory", LoadSceneMode.Single);
            }
            else if(counterG==PlayerPrefs.GetInt("Smurfs"))
            {
                if(PlayerPrefs.GetInt("Test") == 1){
                    Debug.Log("G won, S=" + PlayerPrefs.GetInt("Smurfs") + ", B="+ PlayerPrefs.GetInt("Bushes") + ", G="+ PlayerPrefs.GetInt("Gargamels") + ", points S = " + counterS + ", points G = " + counterG);
                    TextWriter tsw = new StreamWriter(@"C:\Results\Results" + PlayerPrefs.GetInt("FileNumber") + ".txt", true);
                    tsw.WriteLine(PlayerPrefs.GetInt("Smurfs") + "\t" + PlayerPrefs.GetInt("Bushes") + "\t" + PlayerPrefs.GetInt("Gargamels") + "\t" + counterS + "\t" + counterG);
                    tsw.Close();
                }                
                SceneManager.LoadScene("GsVictory", LoadSceneMode.Single);
            }

            scoreText.text = "Punkty Smerfów: " + counterS + " / " + PlayerPrefs.GetInt("Bushes") + " | Punkty Gargamelów " + counterG + " / " + PlayerPrefs.GetInt("Smurfs");
        yield return new WaitForSeconds(1f);
        }
    }
}

