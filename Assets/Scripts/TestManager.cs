using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TestManager : MonoBehaviour
{
    void Start()
    {
        if(PlayerPrefs.GetInt("Test") == 1){

        if(PlayerPrefs.GetInt("FileNumber") < 11){

            
            if(PlayerPrefs.GetInt("Smurfs") < 42){

                if(PlayerPrefs.GetInt("Bushes") < 42){
                    if(PlayerPrefs.GetInt("Gargamels") < 6){
                        PlayerPrefs.SetInt("Gargamels", PlayerPrefs.GetInt("Gargamels") + 1);
                    }
                    else
                    {
                        PlayerPrefs.SetInt("Bushes", PlayerPrefs.GetInt("Bushes") + 5);
                        if(PlayerPrefs.GetInt("Bushes") == 46){
                            PlayerPrefs.SetInt("Bushes", 1);
                            PlayerPrefs.SetInt("Smurfs", PlayerPrefs.GetInt("Smurfs") + 5);
                        }
                        PlayerPrefs.SetInt("Gargamels", 1);
                    }
                }
                SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);

            }
            else
            {
                Debug.Log("End of testing " + PlayerPrefs.GetInt("FileNumber"));
                PlayerPrefs.SetInt("FileNumber", PlayerPrefs.GetInt("FileNumber") + 1);
                PlayerPrefs.SetInt("Gargamels", 1);
                PlayerPrefs.SetInt("Bushes", 1);
                PlayerPrefs.SetInt("Smurfs", 1);
                
                SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
            }
        }
        else
        {
            Debug.Log("End of testing " + PlayerPrefs.GetInt("FileNumber"));
        }
        }
    }

    
}
