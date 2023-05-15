using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class Menu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI NumberOfSmurfs;
    [SerializeField] private TextMeshProUGUI NumberOfGargamels;
    [SerializeField] private TextMeshProUGUI NumberOfBushes;
    [SerializeField] private TextMeshProUGUI Width;
    [SerializeField] private TextMeshProUGUI Heigth;

    [SerializeField] private Slider SmurfsS;
    [SerializeField] private Slider GargamelsS;
    [SerializeField] private Slider BushesS;
    [SerializeField] private Slider WidthS;
    [SerializeField] private Slider HeigthS;

    void Start()
    {
        NumberOfSmurfs.text = SmurfsS.value.ToString();;
        NumberOfGargamels.text = GargamelsS.value.ToString();
        NumberOfBushes.text = BushesS.value.ToString();
        Width.text = WidthS.value.ToString();
        Heigth.text = HeigthS.value.ToString();
    }

    public void OnSmurfsChanged(){
        NumberOfSmurfs.text = SmurfsS.value.ToString();
        PlayerPrefs.SetInt("Smurfs", (int)SmurfsS.value);
    }
    public void OnGargamelsChanged(){
        NumberOfGargamels.text = GargamelsS.value.ToString();
        PlayerPrefs.SetInt("Gargamels", (int)GargamelsS.value);
    }
    public void OnBushesChanged(){
        NumberOfBushes.text = BushesS.value.ToString();
        PlayerPrefs.SetInt("Bushes", (int)BushesS.value);
    }
    public void OnWidthChanged(){
        Width.text = WidthS.value.ToString();
        PlayerPrefs.SetFloat("Width", WidthS.value);
    }
    public void OnHeigthChanged(){
        Heigth.text = HeigthS.value.ToString();
        PlayerPrefs.SetFloat("Height", HeigthS.value);
    }

    public void StartSimulation(){
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    
}
