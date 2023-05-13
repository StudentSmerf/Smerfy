using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Simulation : MonoBehaviour
{
    [SerializeField] private int NumberOfSmurfs = 5;
    [SerializeField] private int NumberOfGargamels = 3;
    [SerializeField] private int NumberOfKlakiers = 0;
    [SerializeField] private int NumberOfBushes = 10;

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
        //Create Objects defined by User
        //Vector3.zero will be replaced with random position inside the field
        for(int i = 0; i < NumberOfSmurfs; i++){
            GameObject NewSmurf = Instantiate(Smurf, Vector3.zero, Quaternion.identity);
            Smurfs.Add(NewSmurf);
            NewSmurf.name = "Smurf " + i;
            
        }
        for(int j = 0; j < NumberOfGargamels; j++){
            GameObject NewGargamel = Instantiate(Gargamel, Vector3.zero, Quaternion.identity);
            Gargamels.Add(NewGargamel);
            NewGargamel.name = "Gargamel " + j;
            
        }
        for(int k = 0; k < NumberOfBushes; k++){
            GameObject NewBush = Instantiate(Bush, Vector3.zero, Quaternion.identity);
            Bushes.Add(NewBush);
            NewBush.name = "Bush " + k;
            
        }
        //GameObject S = Instantiate(Smurf, Vector3.zero, Quaternion.identity);
        //GameObject G = Instantiate(Gargamel, Vector3.zero, Quaternion.identity);
        //GameObject K = Instantiate(Klakier, Vector3.zero, Quaternion.identity);

        //SIMULATION
        
        //StartSimulation
        StartCoroutine("StartSimulation");



        /*
        S.GetComponent<Movement>().Move();
        G.GetComponent<Movement>().Move();
        K.GetComponent<Movement>().Move();

        S.GetComponent<Movement>().Move();
        */
    }

    public void AddKlakier(GameObject newKlakier){
        Klakiers.Add(newKlakier);
        newKlakier.name = "Klakier " + Klakiers.Count;
        NumberOfKlakiers = Klakiers.Count;
    }

    IEnumerator StartSimulation(){
        
        while (true)
        {
            Debug.Log("Sim");
            yield return new WaitForSeconds(1);
            //Simulate Smurfs
            foreach(GameObject smurf in Smurfs){
                switch (Random.Range(1,4))
                {
                    case 1:
                        smurf.GetComponent<Movement>().Move();
                        break;
                    case 2:
                        Debug.Log(smurf.name + " Is looking for G");
                        smurf.GetComponent<Vision>().Look("SmurfG", Gargamels);
                        smurf.GetComponent<Vision>().Look("SmurfG", Klakiers);
                        break;
                    case 3:
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
                switch (Random.Range(1,4))
                {
                    case 1:
                        gargamel.GetComponent<Movement>().Move();
                        break;
                    case 2:
                        Debug.Log(gargamel.name + " Is looking for S");
                        gargamel.GetComponent<Vision>().Look("Gargamel", Smurfs);
                        break;
                    case 3:
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
