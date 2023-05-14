using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Simulation : MonoBehaviour
{
    //these numbers will be set by user
    [SerializeField] private int NumberOfSmurfs = 20;
    [SerializeField] private int NumberOfGargamels = 3;
    [SerializeField] private int NumberOfBushes = 10;
    [SerializeField] private float Width = 30f;
    [SerializeField] private float Height = 15f;

    [SerializeField] private int NumberOfKlakiers = 0;

    [SerializeField] private GameObject Smurf;
    [SerializeField] private GameObject Gargamel;
    [SerializeField] private GameObject Klakier;
    [SerializeField] private GameObject Bush;
    
    [SerializeField] private List<GameObject> Smurfs;
    [SerializeField] private List<GameObject> Gargamels;
    [SerializeField] private List<GameObject> Klakiers;
    [SerializeField] private List<GameObject> Bushes;


    private void Awake() {
        List<GameObject> Smurfs = new List<GameObject>();
        List<GameObject> Gargamels = new List<GameObject>();
        List<GameObject> Klakiers = new List<GameObject>();
        List<GameObject> Bushes = new List<GameObject>();
    }

    void Start()
    {
        //Create World
        this.gameObject.GetComponent<CreateWorld>().Create(Width, Height);

        //Create Objects defined by User
        
        for(int i = 0; i < NumberOfSmurfs; i++){
            GameObject NewSmurf = Instantiate(Smurf, GetPosition(), Quaternion.identity);
            Smurfs.Add(NewSmurf);
            NewSmurf.name = "Smurf " + i;
            
        }
        for(int j = 0; j < NumberOfGargamels; j++){
            GameObject NewGargamel = Instantiate(Gargamel, GetPosition(), Quaternion.identity);
            Gargamels.Add(NewGargamel);
            NewGargamel.name = "Gargamel " + j;
            
        }
        for(int k = 0; k < NumberOfBushes; k++){
            GameObject NewBush = Instantiate(Bush, GetPosition(), Quaternion.identity);
            Bushes.Add(NewBush);
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
        Klakiers.Add(newKlakier);
        newKlakier.name = "Klakier " + Klakiers.Count;
        NumberOfKlakiers = Klakiers.Count;
    }

    IEnumerator StartSimulation(){
        
        while (true)
        {
            Debug.Log("Simulation starts with new round");
            yield return new WaitForSeconds(1);
            //Simulate Smurfs
            foreach(GameObject smurf in Smurfs){
                switch (Random.Range(1,10))
                {
                    case < 5:
                        smurf.GetComponent<Movement>().Move();
                        break;
                    case 5:
                        Debug.Log(smurf.name + " Is looking for G");
                        smurf.GetComponent<Vision>().Look("SmurfG", Gargamels);
                        smurf.GetComponent<Vision>().Look("SmurfG", Klakiers);
                        break;
                    case > 5:
                        Debug.Log(smurf.name + "Is looking for Berries");
                        smurf.GetComponent<Vision>().Look("SmurfB", Bushes);
                        break;
                    default:
                        Debug.Log("Rand not Working?");
                        break;
                }
            }
            //Simulate Gargamels
            foreach(GameObject gargamel in Gargamels){
                switch (Random.Range(1,10))
                {
                    case < 5:
                        gargamel.GetComponent<Movement>().Move();
                        break;
                    case > 5:
                        Debug.Log(gargamel.name + " Is looking for S");
                        gargamel.GetComponent<Vision>().Look("Gargamel", Smurfs);
                        break;
                    case 5:
                        AddKlakier(gargamel.GetComponent<SpawnKlakier>().Spawn(Klakier));
                        Debug.Log(gargamel.name + "Is Spawning Klakier");
                        break;
                    default:
                        Debug.Log("Rand not Working?");
                        break;
                }
            }
            //Simulate Klakiers
            foreach (GameObject klakier in Klakiers)
            {
                switch (Random.Range(1,3))
                {
                    case 1:
                        klakier.GetComponent<Movement>().Move();
                        break;
                    case 2:
                        Debug.Log(klakier.name + " Is looking for S");
                        klakier.GetComponent<Vision>().Look("Klakier", Smurfs);
                        break;
                    default:
                        Debug.Log("Rand not Working?");
                        break;
                }
            }
            
        }
    }
    
    
}
