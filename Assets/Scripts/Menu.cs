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
    [SerializeField] private TextMeshProUGUI SimSpeed;

    [SerializeField] private Slider SmurfsS;
    [SerializeField] private Slider GargamelsS;
    [SerializeField] private Slider BushesS;
    [SerializeField] private Slider WidthS;
    [SerializeField] private Slider HeigthS;
    [SerializeField] private Slider SpeedS;

    void Start()
    {
        SmurfsS.value = PlayerPrefs.GetInt("Smurfs");
        GargamelsS.value = PlayerPrefs.GetInt("Gargamels");
        BushesS.value = PlayerPrefs.GetInt("Bushes");
        WidthS.value = PlayerPrefs.GetFloat("Width");
        HeigthS.value = PlayerPrefs.GetFloat("Height");
        SpeedS.value = PlayerPrefs.GetFloat("SimSpeed");

        NumberOfSmurfs.text = SmurfsS.value.ToString();;
        NumberOfGargamels.text = GargamelsS.value.ToString();
        NumberOfBushes.text = BushesS.value.ToString();
        Width.text = WidthS.value.ToString();
        Heigth.text = HeigthS.value.ToString();
        SimSpeed.text = SpeedS.value.ToString();
        
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
    public void OnSimSpeedChanged(){
        SimSpeed.text = SpeedS.value.ToString();
        PlayerPrefs.SetFloat("SimSpeed", SpeedS.value);
    }

    public void StartSimulation(){
        PlayerPrefs.SetInt("Test", 0);
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    public void StartTesting(){
        PlayerPrefs.SetInt("Test", 1);
        PlayerPrefs.SetInt("FileNumber", 0);
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    
}
