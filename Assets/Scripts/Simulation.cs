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
    
    [SerializeField] private List<GameObject> Smurfs;
    [SerializeField] private List<GameObject> Gargamels;
    [SerializeField] private List<GameObject> Klakiers;
    [SerializeField] private List<GameObject> Bushes;

    //[SerializeField] private List<GameObject> Objects;

    private List<Smurf> ListSmurfs;
    private List<Gargamel> ListGargamels;
    private List<Klakier> ListKlakiers;
    private List<AbstractObj> ListObjects;

    private List<AbstractObj> TempListObjects;


    private void Awake() {
        List<GameObject> Smurfs = new List<GameObject>();
        List<GameObject> Gargamels = new List<GameObject>();
        List<GameObject> Klakiers = new List<GameObject>();

        

        List<GameObject> Bushes = new List<GameObject>();

        

        NumberOfSmurfs = PlayerPrefs.GetInt("Smurfs");
        NumberOfGargamels = PlayerPrefs.GetInt("Gargamels");
        NumberOfBushes = PlayerPrefs.GetInt("Bushes");
        Width = PlayerPrefs.GetFloat("Width");
        Height = PlayerPrefs.GetFloat("Height");
    }

    void Start()
    {
        ListSmurfs = new List<Smurf>();
        ListGargamels = new List<Gargamel>();
        ListKlakiers = new List<Klakier>();
        ListObjects = new List<AbstractObj>();
        TempListObjects = new List<AbstractObj>();
        //Create World
        this.gameObject.GetComponent<CreateWorld>().Create(Width, Height);

        //Create Objects defined by User
        
        for(int i = 0; i < NumberOfSmurfs; i++){
            GameObject NewSmurf = Instantiate(Smurf, GetPosition(), Quaternion.identity);
            Smurf SmurfObj = new Smurf(NewSmurf);
            ListSmurfs.Add(SmurfObj);
            ListObjects.Add(SmurfObj);
            //Debug.Log(ListObjects);
            //Debug.Log(ListObjects.Count);
            //Smurfs.Add(NewSmurf);
            //Objects.Add(NewSmurf);
            NewSmurf.name = "Smurf " + i;
            
        }
        for(int j = 0; j < NumberOfGargamels; j++){
            GameObject NewGargamel = Instantiate(Gargamel, GetPosition(), Quaternion.identity);
            Gargamel GargamelObj = new Gargamel(NewGargamel);
            ListGargamels.Add(GargamelObj);
            ListObjects.Add(GargamelObj); 
            //Debug.Log(GargamelObj);
            //Gargamels.Add(NewGargamel);
            //Objects.Add(NewGargamel);
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
        Klakier KlakierObj = new Klakier(newKlakier);
        ListKlakiers.Add(KlakierObj);
        TempListObjects.Add(KlakierObj); 

        //Klakiers.Add(newKlakier);
        //Objects.Add(newKlakier);

        newKlakier.name = "Klakier " + Klakiers.Count;
        NumberOfKlakiers = Klakiers.Count;
    }

    IEnumerator StartSimulation(){
        //Debug.Log(ListObjects);
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


            


            //Debug.Log("Simulation starts with new round");
            yield return new WaitForSeconds(1);
            /*
            //Simulate Smurfs
            foreach(GameObject smurf in Smurfs){
                if(smurf.transform.position.x > -100f){
                    Smurf smurfObj = new Smurf();
                    smurfObj.addGO(Smurf);
                    switch (Random.Range(1,10))
                    {
                        case < 5:
                            smurfObj.GetSpeed(false);
                            smurfObj.MoveObject(smurf);
                            break;
                        case 5:
                            //Debug.Log(smurf.name + " Is looking for G");
                            smurf.GetComponent<Vision>().LookForG(smurfObj.GetVision(), smurfObj.speed, Gargamels, Smurfs);
                            smurf.GetComponent<Vision>().LookForG(smurfObj.GetVision(), smurfObj.speed, Klakiers, Smurfs);
                            break;
                        case > 5:
                            //Debug.Log(smurf.name + "Is looking for Berries");
                            smurf.GetComponent<Vision>().Look(smurfObj.GetVision(), Bushes);
                            break;
                        default:
                            Debug.Log("Rand not Working?");
                            break;
                    }
                }
            }
            //Simulate Gargamels
            foreach(GameObject gargamel in Gargamels){
                if(gargamel.transform.position.y > -100f){
                    Gargamel gargamelObj = new Gargamel();
                    switch (Random.Range(1,10))
                    {
                        case < 5:
                            gargamelObj.GetSpeed(false);
                            gargamelObj.MoveObject(gargamel);
                            break;
                        case > 5:
                            //Debug.Log(gargamel.name + " Is looking for S");
                            gargamel.GetComponent<Vision>().Look(gargamelObj.GetVision(), Smurfs);
                            break;
                        case 5:
                            AddKlakier(gargamel.GetComponent<SpawnKlakier>().Spawn(Klakier));
                            //Debug.Log(gargamel.name + "Is Spawning Klakier");
                            break;
                        default:
                            Debug.Log("Rand not Working?");
                            break;
                    }
                }
            }
            //Simulate Klakiers
            foreach (GameObject klakier in Klakiers){
                if(klakier.transform.position.y > -100f){
                    Klakier klakierObj = new Klakier();
                    switch (Random.Range(1,3))
                    {
                        case 1:
                            klakierObj.GetSpeed(false);
                            klakierObj.MoveObject(klakier);
                            break;
                        case 2:
                            //Debug.Log(klakier.name + " Is looking for S");
                            klakier.GetComponent<Vision>().Look(klakierObj.GetVision(), Smurfs);
                            break;
                        default:
                            Debug.Log("Rand not Working?");
                            break;
                    }
                }
            }
            */
            
        }
    }
    
    
}
