using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Simulation : MonoBehaviour
{
    [SerializeField] private int NumberOfSmurfs = 5;
    [SerializeField] private int NumberOfGargamels = 5;
    [SerializeField] private int NumberOfKlakiers = 0;

    [SerializeField] private GameObject Smurf;
    [SerializeField] private GameObject Gargamel;
    [SerializeField] private GameObject Klakier;
    
    [SerializeField] private GameObject[] Smurfs;
    [SerializeField] private GameObject[] Gargamels;
    [SerializeField] private List<GameObject> Klakiers;


    void Start()
    {
        Smurfs = new GameObject[NumberOfSmurfs];
        Gargamels = new GameObject[NumberOfGargamels];
        List<GameObject> Klakiers = new List<GameObject>();

        //Create First Objects
        for(int i = 0; i < NumberOfSmurfs; i++){
            Smurfs[i] = Instantiate(Smurf, Vector3.zero, Quaternion.identity);
            Smurfs[i].name = "Smurf " + i;
        }
        for(int j = 0; j < NumberOfGargamels; j++){
            Gargamels[j] = Instantiate(Gargamel, Vector3.zero, Quaternion.identity);
            Gargamels[j].name = "Gargamel " + j;
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
            yield return new WaitForSeconds(1);
            //Simulate Smurfs
            for(int i = 0; i < Smurfs.Length; i++){
                switch (Random.Range(1,4))
                {
                    case 1:
                        Smurfs[i].GetComponent<Movement>().Move();
                        break;
                    case 2:
                        Debug.Log(Smurfs[i].name + " Is looking for G");
                        break;
                    case 3:
                        Debug.Log(Smurfs[i].name + "Is looking for Berries");
                        break;
                    default:
                        Debug.Log("Rand not Working?");
                        break;
                }
            }
            //Simulate Gargamels
            for(int j = 0; j < Gargamels.Length; j++){
                switch (Random.Range(1,4))
                {
                    case 1:
                        Gargamels[j].GetComponent<Movement>().Move();
                        break;
                    case 2:
                        Debug.Log(Gargamels[j].name + " Is looking for S");
                        break;
                    case 3:
                        AddKlakier(Gargamels[j].GetComponent<SpawnKlakier>().Spawn(Klakier));
                        Debug.Log(Gargamels[j].name + "Is Spawning Klakier");
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
                        break;
                    default:
                        Debug.Log("Rand not Working?");
                        break;
                }
            }
            
        }
    }
    
    
}
