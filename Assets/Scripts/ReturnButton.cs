using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReturnButton : MonoBehaviour
{
    public void Return()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
