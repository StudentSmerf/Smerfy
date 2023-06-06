using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartValues : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetInt("Smurfs", 10);
        PlayerPrefs.SetInt("Gargamels", 3);
        PlayerPrefs.SetInt("Bushes", 15);
        PlayerPrefs.SetFloat("Width", 20f);
        PlayerPrefs.SetFloat("Height", 20f);


        SceneManager.LoadScene("Menu", LoadSceneMode.Single);

    }
}
