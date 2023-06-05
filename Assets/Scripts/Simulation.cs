using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AbstractObj.simulateResults;

public class Simulation : MonoBehaviour
{
    //these numbers will be set by user
    [SerializeField] private int NumberOfSmurfs;
    [SerializeField] private int NumberOfGargamels;
    [SerializeField] private int NumberOfBushes;
    [SerializeField] private float Width;
    [SerializeField] private float Height;

    [SerializeField] private int NumberOfKlakiers = 0;

    [SerializeField] private GameObject Smurf;
    [SerializeField] private GameObject Gargamel;
    [SerializeField] private GameObject Klakier;
    [SerializeField] private GameObject Bush;

    [SerializeField] private List<AbstractObj> ListObjects;

    [SerializeField] private List<AbstractObj> TempListObjects;


    private void Awake() {
        NumberOfSmurfs = PlayerPrefs.GetInt("Smurfs");
        NumberOfGargamels = PlayerPrefs.GetInt("Gargamels");
        NumberOfBushes = PlayerPrefs.GetInt("Bushes");
        Width = PlayerPrefs.GetFloat("Width");
        Height = PlayerPrefs.GetFloat("Height");
    }

    void Start()
    {
        ListObjects = new List<AbstractObj>();
        TempListObjects = new List<AbstractObj>();
        //Create World
        this.gameObject.GetComponent<CreateWorld>().Create(Width, Height);

        //Create Objects defined by User
        
        for(int i = 0; i < NumberOfSmurfs; i++){
            GameObject NewSmurf = Instantiate(Smurf, GetPosition(), Quaternion.identity);
            Smurf SmurfObj = new Smurf(NewSmurf);
            ListObjects.Add(SmurfObj);
            NewSmurf.name = "Smurf " + i;
        }
        for(int j = 0; j < NumberOfGargamels; j++){
            GameObject NewGargamel = Instantiate(Gargamel, GetPosition(), Quaternion.identity);
            Gargamel GargamelObj = new Gargamel(NewGargamel);
            ListObjects.Add(GargamelObj); 
            NewGargamel.name = "Gargamel " + j;
        }

        for(int k = 0; k < NumberOfBushes; k++){
            GameObject NewBush = Instantiate(Bush, GetPosition(), Quaternion.identity);
            NewBush.name = "Bush " + k;
        }

        //SIMULATION
        
        //StartSimulation
        StartCoroutine("StartSimulation");
        

    }

    private Vector3 GetPosition(){
        return new Vector3(Random.Range(0, Width), Random.Range(0, Height), 0);
    }

    public void AddKlakier(GameObject newKlakier){
        Klakier KlakierObj = new Klakier(newKlakier);
        ListKlakiers.Add(KlakierObj);
        TempListObjects.Add(KlakierObj); 
        newKlakier.name = "Klakier " + Klakiers.Count;
        NumberOfKlakiers = Klakiers.Count;
    }

    IEnumerator StartSimulation(){
        while (true)
        {
            if(TempListObjects.Count != 0){  
                ListObjects.AddRange(TempListObjects);
                TempListObjects.Clear();   
            }
            foreach (AbstractObj abstractObj in ListObjects)
            {
                if(abstractObj.Simulate() == spawnKlakier){
                    Vector3 location = abstractObj.spawnKlakier();
                    GameObject K = Instantiate(Klakier, location + Vector3.right, Quaternion.identity);
                    AddKlakier(K);
                }
            }

            yield return new WaitForSeconds(1);
        }
    }
}
